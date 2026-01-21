using MySql.Data.MySqlClient;
using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Data
{
   internal static class Database
   {
      private static string ConnectionString =>
         ConfigurationManager.ConnectionStrings["client_schedule"].ConnectionString;

      public static MySqlConnection GetOpenConnection()
      {
         var conn = new MySqlConnection(ConnectionString);
         conn.Open();
         return conn;
      }

      public static List<Customer> GetCustomers()
      {
         const string sql = @"
           SELECT 
               c.customerId,
               c.customerName,
               a.address,
               a.address2,
               a.postalCode,
               a.phone,
               ci.city,
               co.country
           FROM customer c
           JOIN address a ON c.addressId = a.addressId
           JOIN city ci ON a.cityId = ci.cityId
           JOIN country co ON ci.countryId = co.countryId
           WHERE c.active = 1
           ORDER BY c.customerName;";

         var list = new List<Customer>();

         using (var conn = GetOpenConnection())
         using (var cmd = new MySqlCommand(sql, conn))
         using (var reader = cmd.ExecuteReader())
         {
            while (reader.Read())
            {
               list.Add(new Customer
               {
                  CustomerId = reader.GetInt32("customerId"),
                  CustomerName = reader.GetString("customerName"),
                  Address = reader.GetString("address"),
                  PostalCode = reader.IsDBNull(reader.GetOrdinal("postalCode")) ? "" : reader.GetString("postalCode"),
                  Phone = reader.GetString("phone"),
                  City = reader.GetString("city"),
                  Country = reader.GetString("country")
               });
            }
         }

         return list;
      }

      public static void DeleteCustomer(int customerId, string userName)
      {
         const string sql = @"
           UPDATE customer
           SET active = 0,
               lastUpdateBy = @user,
               lastUpdate = UTC_TIMESTAMP()
           WHERE customerId = @id;";

         using (var conn = GetOpenConnection())
         using (var cmd = new MySqlCommand(sql, conn))
         {
            cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = userName;
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = customerId;
            cmd.ExecuteNonQuery();
         }
      }

      public static void AddCustomer(
          string customerName,
          string address,
          string city,
          string country,
          string postalCode,
          string phone,
          string userName)
      {
         using (var conn = GetOpenConnection())
         using (var tx = conn.BeginTransaction())
         {
            try
            {
               int countryId = GetOrCreateCountry(conn, tx, country, userName);
               int cityId = GetOrCreateCity(conn, tx, city, countryId, userName);
               int addressId = CreateAddress(conn, tx, address, postalCode, phone, cityId, userName);

               const string insertCustomer = @"
                INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy)
                VALUES (@name, @addressId, 1, UTC_TIMESTAMP(), @user, UTC_TIMESTAMP(), @user);
                SELECT LAST_INSERT_ID();";

               using (var cmd = new MySqlCommand(insertCustomer, conn, tx))
               {
                  cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = customerName;
                  cmd.Parameters.Add("@addressId", MySqlDbType.Int32).Value = addressId;
                  cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = userName;

                  cmd.ExecuteScalar(); 
               }

               tx.Commit();
            }
            catch
            {
               tx.Rollback();
               throw;
            }
         }
      }

      private static int GetOrCreateCountry(MySqlConnection conn, MySqlTransaction tx, string country, string userName)
      {
         const string selectSql = @"SELECT countryId FROM country WHERE country = @c LIMIT 1;";
         using (var select = new MySqlCommand(selectSql, conn, tx))
         {
            select.Parameters.Add("@c", MySqlDbType.VarChar).Value = country;
            var existing = select.ExecuteScalar();
            if (existing != null && existing != DBNull.Value)
               return Convert.ToInt32(existing);
         }

         const string insertSql = @"
           INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy)
           VALUES (@c, UTC_TIMESTAMP(), @u, UTC_TIMESTAMP(), @u);
           SELECT LAST_INSERT_ID();";

         using (var insert = new MySqlCommand(insertSql, conn, tx))
         {
            insert.Parameters.Add("@c", MySqlDbType.VarChar).Value = country;
            insert.Parameters.Add("@u", MySqlDbType.VarChar).Value = userName;
            return Convert.ToInt32(insert.ExecuteScalar());
         }
      }

      private static int GetOrCreateCity(MySqlConnection conn, MySqlTransaction tx, string city, int countryId, string userName)
      {
         const string selectSql = @"SELECT cityId FROM city WHERE city = @c AND countryId = @cid LIMIT 1;";
         using (var select = new MySqlCommand(selectSql, conn, tx))
         {
            select.Parameters.Add("@c", MySqlDbType.VarChar).Value = city;
            select.Parameters.Add("@cid", MySqlDbType.Int32).Value = countryId;
            var existing = select.ExecuteScalar();
            if (existing != null && existing != DBNull.Value)
               return Convert.ToInt32(existing);
         }

         const string insertSql = @"
           INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy)
           VALUES (@c, @cid, UTC_TIMESTAMP(), @u, UTC_TIMESTAMP(), @u);
           SELECT LAST_INSERT_ID();";

         using (var insert = new MySqlCommand(insertSql, conn, tx))
         {
            insert.Parameters.Add("@c", MySqlDbType.VarChar).Value = city;
            insert.Parameters.Add("@cid", MySqlDbType.Int32).Value = countryId;
            insert.Parameters.Add("@u", MySqlDbType.VarChar).Value = userName;
            return Convert.ToInt32(insert.ExecuteScalar());
         }
      }

      private static int CreateAddress(MySqlConnection conn, MySqlTransaction tx, string address, string postalCode, string phone, int cityId, string userName)
      {
         const string insertSql = @"
           INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy)
           VALUES (@a, '', @cityId, @pc, @ph, UTC_TIMESTAMP(), @u, UTC_TIMESTAMP(), @u);
           SELECT LAST_INSERT_ID();";

         using (var cmd = new MySqlCommand(insertSql, conn, tx))
         {
            cmd.Parameters.Add("@a", MySqlDbType.VarChar).Value = address;
            cmd.Parameters.Add("@cityId", MySqlDbType.Int32).Value = cityId;
            cmd.Parameters.Add("@pc", MySqlDbType.VarChar).Value = postalCode ?? "";
            cmd.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            cmd.Parameters.Add("@u", MySqlDbType.VarChar).Value = userName;

            return Convert.ToInt32(cmd.ExecuteScalar());
         }
      }


   }

}
