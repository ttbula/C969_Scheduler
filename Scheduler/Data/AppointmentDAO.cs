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
                     Type = reader.GetString("type"),
                     Start = reader.GetDateTime("start"),
                     End = reader.GetDateTime("end")
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
                    INSERT INTO appointment (customerId, userId, type, start, end)
                    VALUES (@customerId, @userId, @type, @start, @end);
                    SELECT LAST_INSERT_ID();
                ";

            using (var cmd = new MySqlCommand(sql, conn))
            {
               cmd.Parameters.AddWithValue("@customerId", appt.CustomerId);
               cmd.Parameters.AddWithValue("@userId", appt.UserId);
               cmd.Parameters.AddWithValue("@type", appt.Type);
               cmd.Parameters.AddWithValue("@start", appt.Start);
               cmd.Parameters.AddWithValue("@end", appt.End);

               return Convert.ToInt32(cmd.ExecuteScalar());
            }
         }
      }

      public static void Update(Appointment appt)
      {
         using (var conn = Database.GetConnection())
         {
            const string sql = @"
                    UPDATE appointment
                    SET customerId = @customerId,
                        userId = @userId,
                        type = @type,
                        start = @start,
                        end = @end
                    WHERE appointmentId = @appointmentId;
                ";

            using (var cmd = new MySqlCommand(sql, conn))
            {
               cmd.Parameters.AddWithValue("@customerId", appt.CustomerId);
               cmd.Parameters.AddWithValue("@userId", appt.UserId);
               cmd.Parameters.AddWithValue("@type", appt.Type);
               cmd.Parameters.AddWithValue("@start", appt.Start);
               cmd.Parameters.AddWithValue("@end", appt.End);
               cmd.Parameters.AddWithValue("@appointmentId", appt.AppointmentId);

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
                      AND @newStart < end
                      AND @newEnd > start
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
