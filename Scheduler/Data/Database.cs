using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
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
   }
}
