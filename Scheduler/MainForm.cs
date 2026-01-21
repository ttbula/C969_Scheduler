using MySql.Data.MySqlClient;
using Scheduler.Data;
using Scheduler.Models;
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

      private BindingSource _customerBinding = new BindingSource();

      private void MainForm_Load(object sender, EventArgs e)
      {
         GetUpcomingAppointments();
         LoadCustomers();
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
            Debug.WriteLine(ex);
         }
      }

      private void LoadCustomers()
      {
         var customers = Database.GetCustomers();
         _customerBinding.DataSource = customers;
         dgvCustomers.AutoGenerateColumns = true;
         dgvCustomers.DataSource = _customerBinding;
      }

      private bool ValidateCustomerInputs(string name, string address, string phone, out string error)
      {
         name = (name ?? "").Trim();
         address = (address ?? "").Trim();
         phone = (phone ?? "").Trim();

         if (string.IsNullOrWhiteSpace(name) ||
             string.IsNullOrWhiteSpace(address) ||
             string.IsNullOrWhiteSpace(phone))
         {
            error = "Name, address, and phone are required.";
            return false;
         }

         // digits and dashes only
         foreach (char ch in phone)
         {
            if (!(char.IsDigit(ch) || ch == '-'))
            {
               error = "Phone can contain only digits and dashes.";
               return false;
            }
         }

         error = null;
         return true;
      }

      private void btnDeleteCustomer_Click(object sender, EventArgs e)
      {
         if (dgvCustomers.CurrentRow == null || dgvCustomers.CurrentRow.DataBoundItem == null)
            return;

         var selected = dgvCustomers.CurrentRow.DataBoundItem as Customer;
         if (selected == null)
            return;

         var confirm = MessageBox.Show(
             $"Delete customer '{selected.CustomerName}'?",
             "Confirm Delete",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Warning);

         if (confirm != DialogResult.Yes)
            return;

         try
         {
            Database.DeleteCustomer(selected.CustomerId, _session.UserName);
            LoadCustomers();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "Delete Failed",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void btnAddCustomer_Click(object sender, EventArgs e)
      {
         using (var form = new CustomerForm())
         {
            if (form.ShowDialog(this) != DialogResult.OK)
               return;

            try
            {
               Database.AddCustomer(
                   form.CustomerName,
                   form.Address,
                   form.City,
                   form.Country,
                   form.PostalCode,
                   form.Phone,
                   _session.UserName);

               LoadCustomers();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Add Failed",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }

   }
}