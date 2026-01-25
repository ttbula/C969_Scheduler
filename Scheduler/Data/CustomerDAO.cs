using MySql.Data.MySqlClient;
using Scheduler.Models;
using System.Collections.Generic;

namespace Scheduler.Data
{
   public static class CustomerDAO
   {
      public static List<Customer> GetAllCustomers()
      {
         var customers = new List<Customer>();

         const string sql = @"
            SELECT 
                c.customerId,
                c.customerName,
                a.address,
                ci.city,
                co.country,
                a.postalCode,
                a.phone
            FROM customer c
            JOIN address a  ON c.addressId = a.addressId
            JOIN city ci    ON a.cityId = ci.cityId
            JOIN country co ON ci.countryId = co.countryId
            ORDER BY c.customerName;";

         using (var conn = Database.GetConnection())
         using (var cmd = new MySqlCommand(sql, conn))
         using (var reader = cmd.ExecuteReader())
         {
            while (reader.Read())
            {
               customers.Add(new Customer
               {
                  CustomerId = reader.GetInt32("customerId"),
                  CustomerName = reader.GetString("customerName"),
                  Address = reader.GetString("address"),
                  City = reader.GetString("city"),
                  Country = reader.GetString("country"),
                  PostalCode = reader.GetString("postalCode"),
                  Phone = reader.GetString("phone")
               });
            }
         }

         return customers;
      }
   }
}
