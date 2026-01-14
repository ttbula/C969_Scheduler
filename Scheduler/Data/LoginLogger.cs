using MySql.Data.MySqlClient;
using System;

namespace Scheduler.Data
{
   internal static class LoginLogger
   {
      public static void Log(string username, bool success)
      {
         const string sql = @"
                           INSERT INTO login_activity (userName, loginTime, success)
                           VALUES (@u, @t, @s);";

         using (var conn = Database.GetOpenConnection())
         using (var cmd = new MySqlCommand(sql, conn))
         {
            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@t", DateTime.Now);
            cmd.Parameters.AddWithValue("@s", success ? 1 : 0);
            cmd.ExecuteNonQuery();
         }
      }
   }
}
