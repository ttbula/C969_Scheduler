using MySql.Data.MySqlClient;
using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Data
{
   internal static class Database
   {
      private static string ConnectionString =>
         ConfigurationManager.ConnectionStrings["client_schedule"].ConnectionString;

      public static MySqlConnection GetConnection()
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

         using (var conn = GetConnection())
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
               lastUpdate = NOW()
           WHERE customerId = @id;";

         using (var conn = GetConnection())
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
         using (var conn = GetConnection())
         using (var tx = conn.BeginTransaction())
         {
            try
            {
               int countryId = GetOrCreateCountry(conn, tx, country, userName);
               int cityId = GetOrCreateCity(conn, tx, city, countryId, userName);
               int addressId = CreateAddress(conn, tx, address, postalCode, phone, cityId, userName);

               const string insertCustomer = @"
                INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy)
                VALUES (@name, @addressId, 1, NOW(), @user, NOW(), @user);
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
           VALUES (@c, NOW(), @u, NOWP(), @u);
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
           VALUES (@c, @cid, NOW(), @u, NOW(), @u);
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
           VALUES (@a, '', @cityId, @pc, @ph, NOW(), @u, NOW(), @u);
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

      public static void UpdateCustomer(
    int customerId,
    string customerName,
    string address,
    string city,
    string country,
    string postalCode,
    string phone,
    string userName)
      {
         using (var conn = GetConnection())
         using (var tx = conn.BeginTransaction())
         {
            try
            {
               int addressId = GetAddressIdForCustomer(conn, tx, customerId);

               int countryId = GetOrCreateCountry(conn, tx, country, userName);
               int cityId = GetOrCreateCity(conn, tx, city, countryId, userName);

               const string updateAddress = @"
                UPDATE address
                SET address = @addr,
                    cityId = @cityId,
                    postalCode = @postal,
                    phone = @phone,
                    lastUpdate = NOW(),
                    lastUpdateBy = @user
                WHERE addressId = @addressId;";

               using (var cmd = new MySqlCommand(updateAddress, conn, tx))
               {
                  cmd.Parameters.Add("@addr", MySqlDbType.VarChar).Value = address;
                  cmd.Parameters.Add("@cityId", MySqlDbType.Int32).Value = cityId;
                  cmd.Parameters.Add("@postal", MySqlDbType.VarChar).Value = postalCode ?? "";
                  cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
                  cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = userName;
                  cmd.Parameters.Add("@addressId", MySqlDbType.Int32).Value = addressId;

                  cmd.ExecuteNonQuery();
               }

               const string updateCustomer = @"
                UPDATE customer
                SET customerName = @name,
                    lastUpdate = NOW(),
                    lastUpdateBy = @user
                WHERE customerId = @id;";

               using (var cmd = new MySqlCommand(updateCustomer, conn, tx))
               {
                  cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = customerName;
                  cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = userName;
                  cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = customerId;

                  cmd.ExecuteNonQuery();
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

      private static int GetAddressIdForCustomer(MySqlConnection conn, MySqlTransaction tx, int customerId)
      {
         const string sql = @"SELECT addressId FROM customer WHERE customerId = @id LIMIT 1;";

         using (var cmd = new MySqlCommand(sql, conn, tx))
         {
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = customerId;

            var result = cmd.ExecuteScalar();
            if (result == null || result == DBNull.Value)
               throw new Exception("Customer addressId not found.");

            return Convert.ToInt32(result);
         }
      }

      public static List<Appointment> GetAppointmentsForUser(int userId)
      {
         const string sql = @"
           SELECT a.appointmentId, a.customerId, c.customerName, a.type, a.start, a.end
           FROM appointment a
           JOIN customer c ON a.customerId = c.customerId
           WHERE a.userId = @uid
           ORDER BY a.start;";

         var list = new List<Appointment>();

         using (var conn = GetConnection())
         using (var cmd = new MySqlCommand(sql, conn))
         {
            cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = userId;

            using (var reader = cmd.ExecuteReader())
            {
               while (reader.Read())
               {
                  var start = reader.GetDateTime("start");
                  var end = reader.GetDateTime("end");

                  list.Add(new Appointment
                  {
                     AppointmentId = reader.GetInt32("appointmentId"),
                     CustomerId = reader.GetInt32("customerId"),
                     CustomerName = reader.GetString("customerName"),
                     Type = reader.IsDBNull(reader.GetOrdinal("type")) ? "" : reader.GetString("type"),
                     Start = start,
                     End = end
                  });
               }
            }
         }

         return list;
      }

      public static bool HasOverlappingAppointment(int userId, DateTime start, DateTime end, int? excludeAppointmentId)
      {
         const string sql = @"
           SELECT COUNT(*)
           FROM appointment
           WHERE userId = @uid
             AND (@excludeId IS NULL OR appointmentId <> @excludeId)
             AND start < @end
             AND end > @start;";

         using (var conn = GetConnection())
         using (var cmd = new MySqlCommand(sql, conn))
         {
            cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = userId;
            cmd.Parameters.Add("@start", MySqlDbType.DateTime).Value = start;
            cmd.Parameters.Add("@end", MySqlDbType.DateTime).Value = end;
            cmd.Parameters.Add("@excludeId", MySqlDbType.Int32).Value =
                excludeAppointmentId.HasValue ? (object)excludeAppointmentId.Value : DBNull.Value;

            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
         }
      }

      public static void AddAppointment(int customerId, int userId, string type, DateTime start, DateTime end, string userName)
      {
         const string sql = @"
           INSERT INTO appointment
           (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdateBy)
           VALUES
           (@customerId, @userId, '', '', '', '', @type, '', @start, @end, NOW(), @user, @user);";

         using (var conn = GetConnection())
         using (var cmd = new MySqlCommand(sql, conn))
         {
            cmd.Parameters.Add("@customerId", MySqlDbType.Int32).Value = customerId;
            cmd.Parameters.Add("@userId", MySqlDbType.Int32).Value = userId;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = type ?? "";
            cmd.Parameters.Add("@start", MySqlDbType.DateTime).Value = start;
            cmd.Parameters.Add("@end", MySqlDbType.DateTime).Value = end;
            cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = userName;

            cmd.ExecuteNonQuery();
         }
      }

      public static void UpdateAppointment(int appointmentId, int customerId, string type, DateTime start, DateTime end, string userName)
      {
         const string sql = @"
           UPDATE appointment
           SET customerId = @customerId,
               type = @type,
               start = @start,
               end = @end,
               lastUpdate = NOW(),
               lastUpdateBy = @user
           WHERE appointmentId = @id;";

         using (var conn = GetConnection())
         using (var cmd = new MySqlCommand(sql, conn))
         {
            cmd.Parameters.Add("@customerId", MySqlDbType.Int32).Value = customerId;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = type ?? "";
            cmd.Parameters.Add("@start", MySqlDbType.DateTime).Value = start;
            cmd.Parameters.Add("@end", MySqlDbType.DateTime).Value = end;
            cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = userName;
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = appointmentId;

            cmd.ExecuteNonQuery();
         }
      }

      public static void DeleteAppointment(int appointmentId)
      {
         const string sql = @"DELETE FROM appointment WHERE appointmentId = @id;";

         using (var conn = GetConnection())
         using (var cmd = new MySqlCommand(sql, conn))
         {
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = appointmentId;
            cmd.ExecuteNonQuery();
         }
      }

      public static List<Appointment> GetAppointmentsForUserAndCustomer(int userId, int customerId)
      {
         const string sql = @"
           SELECT a.appointmentId, a.customerId, c.customerName, a.type, a.start, a.end
           FROM appointment a
           JOIN customer c ON a.customerId = c.customerId
           WHERE a.userId = @uid AND a.customerId = @cid
           ORDER BY a.start;";

         var list = new List<Appointment>();

         using (var conn = GetConnection())
         using (var cmd = new MySqlCommand(sql, conn))
         {
            cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = userId;
            cmd.Parameters.Add("@cid", MySqlDbType.Int32).Value = customerId;

            using (var reader = cmd.ExecuteReader())
            {
               while (reader.Read())
               {
                  list.Add(new Appointment
                  {
                     AppointmentId = reader.GetInt32("appointmentId"),
                     CustomerId = reader.GetInt32("customerId"),
                     CustomerName = reader.GetString("customerName"),
                     Type = reader.IsDBNull(reader.GetOrdinal("type")) ? "" : reader.GetString("type"),
                     Start = reader.GetDateTime("start"),
                     End = reader.GetDateTime("end")
                  });
               }
            }
         }

         return list;
      }

   }

}
