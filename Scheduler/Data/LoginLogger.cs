using System;
using System.IO;

namespace Scheduler.Data
{
   internal static class LoginLogger
   {
      private const string LogFileName = "Login_History.txt";

      public static void Log(string username, bool success)
      {
         string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
         string status = success ? "Success" : "Failed";
         string logEntry = $"{timestamp}\t{username}\t{status}";

         try
         {
            File.AppendAllText(LogFileName, logEntry + Environment.NewLine);
         }
         catch (Exception ex)
         {
            System.Diagnostics.Debug.WriteLine($"Login logging failed: {ex.Message}");
         }
      }
   }
}