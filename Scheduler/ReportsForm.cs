using System;
using System.Linq;
using System.Windows.Forms;
using Scheduler.Data;

namespace Scheduler
{
   public partial class ReportsForm : Form
   {
      public ReportsForm()
      {
         InitializeComponent();
      }

      // REPORT 1: Number of appointment types by month
      private void btnTypesByMonth_Click(object sender, EventArgs e)
      {
         try
         {
            var appointments = AppointmentDAO.GetAllAppointments();

            // Lambda expression to group and count
            var report = appointments
               .GroupBy(a => new {
                  Month = a.Start.ToString("MMMM yyyy"),
                  Type = a.Type
               })
               .Select(g => new {
                  Month = g.Key.Month,
                  AppointmentType = g.Key.Type,
                  Count = g.Count()
               })
               .OrderBy(x => DateTime.Parse("01 " + x.Month))
               .ThenBy(x => x.AppointmentType)
               .ToList();

            dgvReport.DataSource = report;

            if (report.Count == 0)
            {
               MessageBox.Show("No appointments found.", "Report",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show($"Error generating report: {ex.Message}", "Report Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      // REPORT 2: Schedule for each user
      private void btnUserSchedules_Click(object sender, EventArgs e)
      {
         try
         {
            var appointments = AppointmentDAO.GetAllAppointments();

            // Lambda expression to organize by user
            var report = appointments
               .OrderBy(a => a.UserId)
               .ThenBy(a => a.Start)
               .Select(a => new {
                  UserId = a.UserId,
                  CustomerName = a.CustomerName,
                  Type = a.Type,
                  Start = a.Start.ToString("g"),
                  End = a.End.ToString("g")
               })
               .ToList();

            dgvReport.DataSource = report;

            if (report.Count == 0)
            {
               MessageBox.Show("No appointments found.", "Report",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show($"Error generating report: {ex.Message}", "Report Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      // REPORT 3: Appointments by customer (custom report)
      private void btnCustomerAppointments_Click(object sender, EventArgs e)
      {
         try
         {
            var appointments = AppointmentDAO.GetAllAppointments();

            // Lambda expression to count appointments per customer
            var report = appointments
               .GroupBy(a => new {
                  a.CustomerId,
                  a.CustomerName
               })
               .Select(g => new {
                  CustomerId = g.Key.CustomerId,
                  CustomerName = g.Key.CustomerName,
                  TotalAppointments = g.Count(),
                  UpcomingAppointments = g.Count(a => a.Start > DateTime.Now),
                  PastAppointments = g.Count(a => a.Start <= DateTime.Now)
               })
               .OrderByDescending(x => x.TotalAppointments)
               .ToList();

            dgvReport.DataSource = report;

            if (report.Count == 0)
            {
               MessageBox.Show("No appointments found.", "Report",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show($"Error generating report: {ex.Message}", "Report Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
   }
}