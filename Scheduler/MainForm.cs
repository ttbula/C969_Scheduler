using MySql.Data.MySqlClient;
using Scheduler.Data;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

namespace Scheduler
{
   public partial class MainForm : Form
   {
      private readonly UserSession _session;
      private bool alertShown = false;

      public MainForm(UserSession session)
      {
         InitializeComponent();
         _session = session;
         Text = $"Scheduler - {_session.UserName}";
         this.Load += MainForm_Load;
         Debug.WriteLine($"Local: {DateTime.Now}");
         Debug.WriteLine($"UTC:   {DateTime.UtcNow}");

      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         GetUpcomingAppointments();
      }

      private void GetUpcomingAppointments()
      {
         if (alertShown) return;

         // Convert local time to UTC
         DateTime utcNow = DateTime.UtcNow;
         DateTime utcPlus15 = utcNow.AddMinutes(15);

         const string sql = @"
              SELECT appointmentId, start
              FROM appointment
              WHERE userId = @userId
                AND start >= @utcNow
                AND start <= @utcPlus15
              ORDER BY start
              LIMIT 1;";

         try
         {
            using (var conn = Database.GetOpenConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
               cmd.Parameters.Add("@userId", MySqlDbType.Int32).Value = _session.UserId;
               cmd.Parameters.Add("@utcNow", MySqlDbType.DateTime).Value = utcNow;
               cmd.Parameters.Add("@utcPlus15", MySqlDbType.DateTime).Value = utcPlus15;

               using (var reader = cmd.ExecuteReader())
               {
                  if (!reader.Read())
                     return; 

                  int apptId = Convert.ToInt32(reader["appointmentId"]);
                  DateTime utcStart = Convert.ToDateTime(reader["start"]);

                  // Convert for display
                  DateTime localStart = DateTime.SpecifyKind(utcStart, DateTimeKind.Utc).ToLocalTime();

                  MessageBox.Show(
                      this,
                      $"You have an appointment within 15 minutes.\n\n" +
                      $"Appointment ID: {apptId}\n" +
                      $"Start: {localStart:g} (Local Time)",
                      "Upcoming Appointment",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);

                  alertShown = true;
               }
            }
         }
         catch (Exception ex)
         {
            // todo: log exception
         }
      }

   }
}