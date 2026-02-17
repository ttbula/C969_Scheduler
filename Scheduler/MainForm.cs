using MySql.Data.MySqlClient;
using Scheduler.Data;
using Scheduler.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Scheduler
{
   public partial class MainForm : Form
   {
      private readonly UserSession _session;

      private bool _alertShown;
      private bool _isLoadingCustomers;

      private readonly BindingSource _customerBinding = new BindingSource();
      private readonly BindingSource _apptBinding = new BindingSource();

      public MainForm(UserSession session)
      {
         InitializeComponent();
         _session = session;

         Text = $"Scheduler - {_session.UserName}";

         Load += MainForm_Load;
         dgvCustomers.SelectionChanged += dgvCustomers_SelectionChanged;
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         ShowUpcomingAppointmentAlertOnce();
         RefreshCustomers(selectFirst: true);
      }

      private void RefreshCustomers(bool selectFirst)
      {
         _isLoadingCustomers = true;

         try
         {
            var customers = Database.GetCustomers();
            _customerBinding.DataSource = customers;

            dgvCustomers.AutoGenerateColumns = true;
            dgvCustomers.DataSource = _customerBinding;

            if (selectFirst && dgvCustomers.Rows.Count > 0)
            {
               dgvCustomers.ClearSelection();
               dgvCustomers.Rows[0].Selected = true;
            }
         }
         finally
         {
            _isLoadingCustomers = false;
         }

         RefreshAppointmentsForSelectedCustomer();
      }

      private Customer GetSelectedCustomer()
      {
         if (dgvCustomers.CurrentRow == null || dgvCustomers.CurrentRow.DataBoundItem == null)
            return null;

         return dgvCustomers.CurrentRow.DataBoundItem as Customer;
      }

      private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
      {
         if (_isLoadingCustomers) return;
         RefreshAppointmentsForSelectedCustomer();
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

               RefreshCustomers(selectFirst: false);
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Add Failed",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }

      private void btnEditCustomer_Click(object sender, EventArgs e)
      {
         var selected = GetSelectedCustomer();
         if (selected == null) return;

         using (var form = new CustomerForm(selected))
         {
            if (form.ShowDialog(this) != DialogResult.OK)
               return;

            try
            {
               Database.UpdateCustomer(
                   selected.CustomerId,
                   form.CustomerName,
                   form.Address,
                   form.City,
                   form.Country,
                   form.PostalCode,
                   form.Phone,
                   _session.UserName);

               RefreshCustomers(selectFirst: false);
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Update Failed",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }

      private void btnDeleteCustomer_Click(object sender, EventArgs e)
      {
         var selected = GetSelectedCustomer();
         if (selected == null) return;

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
            RefreshCustomers(selectFirst: true);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "Delete Failed",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void RefreshAppointmentsForSelectedCustomer()
      {
         var cust = GetSelectedCustomer();

         if (cust == null)
         {
            _apptBinding.DataSource = null;
            dgvAppointments.DataSource = _apptBinding;
            return;
         }

         var appts = Database.GetAppointmentsForUserAndCustomer(_session.UserId, cust.CustomerId);

         _apptBinding.DataSource = appts;
         dgvAppointments.AutoGenerateColumns = true;
         dgvAppointments.DataSource = _apptBinding;
      }

      private Appointment GetSelectedAppointment()
      {
         if (dgvAppointments.CurrentRow == null || dgvAppointments.CurrentRow.DataBoundItem == null)
            return null;

         return dgvAppointments.CurrentRow.DataBoundItem as Appointment;
      }

      private void ShowUpcomingAppointmentAlertOnce()
      {
         if (_alertShown) return;

         DateTime now = DateTime.Now;
         DateTime plus15 = now.AddMinutes(15);

         const string sql = @"
                SELECT appointmentId, start
                FROM appointment
                WHERE userId = @userId
                  AND start >= @now
                  AND start <= @plus15
                ORDER BY start
                LIMIT 1;";

         try
         {
            using (var conn = Database.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
               cmd.Parameters.Add("@userId", MySqlDbType.Int32).Value = _session.UserId;
               cmd.Parameters.Add("@now", MySqlDbType.DateTime).Value = now;
               cmd.Parameters.Add("@plus15", MySqlDbType.DateTime).Value = plus15;

               using (var reader = cmd.ExecuteReader())
               {
                  if (!reader.Read())
                     return;

                  int apptId = Convert.ToInt32(reader["appointmentId"]);
                  DateTime startLocal = Convert.ToDateTime(reader["start"]);

                  MessageBox.Show(
                      this,
                      $"You have an appointment within 15 minutes.\n\n" +
                      $"Appointment ID: {apptId}\n" +
                      $"Start: {startLocal:g} (Local Time)",
                      "Upcoming Appointment",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);

                  _alertShown = true;
               }
            }
         }
         catch (Exception ex)
         {
            Debug.WriteLine(ex);
         }
      }

      private void btnAddAppointment_Click(object sender, EventArgs e)
      {
         var cust = GetSelectedCustomer();
         if (cust == null)
         {
            MessageBox.Show("Select a customer first.", "Appointments",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
         }

         using (var form = new AppointmentForm(_session.UserId))
         {
            if (form.ShowDialog(this) != DialogResult.OK)
               return;

            RefreshAppointmentsForSelectedCustomer();
         }
      }

      private void btnEditAppointment_Click(object sender, EventArgs e)
      {
         var cust = GetSelectedCustomer();
         if (cust == null) return;

         var selected = GetSelectedAppointment();
         if (selected == null) return;

         using (var form = new AppointmentForm(selected))
         {
            if (form.ShowDialog(this) != DialogResult.OK)
               return;

            RefreshAppointmentsForSelectedCustomer();
         }
      }

      private void btnDeleteAppointment_Click(object sender, EventArgs e)
      {
         var selected = GetSelectedAppointment();
         if (selected == null) return;

         var confirm = MessageBox.Show(
             $"Delete appointment {selected.AppointmentId} ({selected.Type})?",
             "Confirm Delete",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Warning);

         if (confirm != DialogResult.Yes)
            return;

         try
         {
            Database.DeleteAppointment(selected.AppointmentId);
            RefreshAppointmentsForSelectedCustomer();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "Delete Failed",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
      {
         DateTime selectedDate = e.Start.Date;

         var allAppointments = AppointmentDAO.GetAllAppointments();

         // Filter appointments for selected date
         var dailyAppointments = allAppointments
             .Where(a => a.Start.Date == selectedDate)
             .OrderBy(a => a.Start)
             .ToList();

         _apptBinding.DataSource = dailyAppointments;
         dgvAppointments.DataSource = _apptBinding;

         if (dailyAppointments.Count == 0)
         {
            MessageBox.Show($"No appointments scheduled for {selectedDate:D}",
                "Calendar View", MessageBoxButtons.OK, MessageBoxIcon.Information);
         }
      }

      private void btnReports_Click(object sender, EventArgs e)
      {
         using (var reportsForm = new ReportsForm())
         {
            reportsForm.ShowDialog(this);
         }
      }
   }
}
