using MySql.Data.MySqlClient;
using Scheduler.Models;
using System;
using System.Collections.Generic;

namespace Scheduler.Data
{
   public static class AppointmentDAO
   {
      public static List<Appointment> GetAllAppointments()
      {
         var appts = new List<Appointment>();

         using (var conn = Database.GetConnection())
         {
            const string sql = @"
                    SELECT 
                        a.appointmentId,
                        a.customerId,
                        a.userId,
                        c.customerName,
                        a.title,
                        a.type,
                        a.start,
                        a.end
                    FROM appointment a
                    JOIN customer c ON c.customerId = a.customerId
                    ORDER BY a.start;
                ";

            using (var cmd = new MySqlCommand(sql, conn))
            using (var reader = cmd.ExecuteReader())
            {
               while (reader.Read())
               {
                  appts.Add(new Appointment
                  {
                     AppointmentId = reader.GetInt32("appointmentId"),
                     CustomerId = reader.GetInt32("customerId"),
                     UserId = reader.GetInt32("userId"),
                     CustomerName = reader.GetString("customerName"),
                     Title = reader.GetString("title"),
                     Type = reader.GetString("type"),
                     Start = reader.GetDateTime("start"),
                     End = reader.GetDateTime("end"),
                     Description = "",
                     Location = "",
                     Contact = "",
                     Url = "",
                     CreatedBy = "test",
                     LastUpdateBy = "test",
                     CreateDate = DateTime.Now,

                  });
               }
            }
         }

         return appts;
      }

      public static int Insert(Appointment appt)
      {
         using (var conn = Database.GetConnection())
         {
            const string sql = @"
               INSERT INTO appointment
               (
                   customerId,
                   userId,
                   title,
                   description,
                   location,
                   contact,
                   type,
                   url,
                   start,
                   end,
                   createDate,
                   createdBy,
                   lastUpdateBy
               )
               VALUES
               (
                   @customerId,
                   @userId,
                   @title,
                   @description,
                   @location,
                   @contact,
                   @type,
                   @url,
                   @start,
                   @end,
                   @createDate,
                   @createdBy,
                   @lastUpdateBy
               );";

            using (var cmd = new MySqlCommand(sql, conn))
            {
               cmd.Parameters.AddWithValue("@customerId", appt.CustomerId);
               cmd.Parameters.AddWithValue("@userId", appt.UserId);

               cmd.Parameters.AddWithValue("@title", appt.Title ?? appt.Type ?? "Appointment");
               cmd.Parameters.AddWithValue("@description", appt.Description ?? "");
               cmd.Parameters.AddWithValue("@location", appt.Location ?? "");
               cmd.Parameters.AddWithValue("@contact", appt.Contact ?? "");
               cmd.Parameters.AddWithValue("@type", appt.Type ?? "");
               cmd.Parameters.AddWithValue("@url", appt.Url ?? "");

               cmd.Parameters.AddWithValue("@start", appt.Start);
               cmd.Parameters.AddWithValue("@end", appt.End);

               cmd.Parameters.AddWithValue("@createDate", appt.CreateDate);
               cmd.Parameters.AddWithValue("@createdBy", appt.CreatedBy ?? "test");
               cmd.Parameters.AddWithValue("@lastUpdateBy", appt.LastUpdateBy ?? (appt.CreatedBy ?? "test"));

               cmd.ExecuteNonQuery();
               return (int)cmd.LastInsertedId;
            }
         }
      }


      public static void Update(Appointment appt)
      {
         using (var conn = Database.GetConnection())
         {
            const string sql = @"
               UPDATE appointment
               SET
                   customerId = @customerId,
                   userId = @userId,
                   title = @title,
                   description = @description,
                   location = @location,
                   contact = @contact,
                   type = @type,
                   url = @url,
                   start = @start,
                   end = @end,
                   lastUpdateBy = @lastUpdateBy
               WHERE appointmentId = @appointmentId;";

            using (var cmd = new MySqlCommand(sql, conn))
            {
               cmd.Parameters.AddWithValue("@appointmentId", appt.AppointmentId);

               cmd.Parameters.AddWithValue("@customerId", appt.CustomerId);
               cmd.Parameters.AddWithValue("@userId", appt.UserId);

               cmd.Parameters.AddWithValue("@title", appt.Title ?? appt.Type ?? "Appointment");
               cmd.Parameters.AddWithValue("@description", appt.Description ?? "");
               cmd.Parameters.AddWithValue("@location", appt.Location ?? "");
               cmd.Parameters.AddWithValue("@contact", appt.Contact ?? "");
               cmd.Parameters.AddWithValue("@type", appt.Type ?? "");
               cmd.Parameters.AddWithValue("@url", appt.Url ?? "");

               cmd.Parameters.AddWithValue("@start", appt.Start);
               cmd.Parameters.AddWithValue("@end", appt.End);

               cmd.Parameters.AddWithValue("@lastUpdateBy", appt.LastUpdateBy ?? "test");

               cmd.ExecuteNonQuery();
            }
         }
      }


      public static void Delete(int appointmentId)
      {
         using (var conn = Database.GetConnection())
         {
            const string sql = "DELETE FROM appointment WHERE appointmentId = @appointmentId;";

            using (var cmd = new MySqlCommand(sql, conn))
            {
               cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
               cmd.ExecuteNonQuery();
            }
         }
      }

      public static bool HasOverlap(int userId, DateTime newStart, DateTime newEnd, int? excludeAppointmentId)
      {
         using (var conn = Database.GetConnection())
         {
            string sql = @"
                    SELECT COUNT(*)
                    FROM appointment
                    WHERE userId = @userId
                      AND @newStart < `end`
                      AND @newEnd > `start`
                ";

            if (excludeAppointmentId.HasValue)
               sql += " AND appointmentId <> @excludeId;";

            using (var cmd = new MySqlCommand(sql, conn))
            {
               cmd.Parameters.AddWithValue("@userId", userId);
               cmd.Parameters.AddWithValue("@newStart", newStart);
               cmd.Parameters.AddWithValue("@newEnd", newEnd);

               if (excludeAppointmentId.HasValue)
                  cmd.Parameters.AddWithValue("@excludeId", excludeAppointmentId.Value);

               var count = Convert.ToInt32(cmd.ExecuteScalar());
               return count > 0;
            }
         }
      }
   }
}
