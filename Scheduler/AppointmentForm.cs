using Scheduler.Data;
using Scheduler.Models;
using System;
using System.Windows.Forms;

namespace Scheduler
{
   public partial class AppointmentForm : Form
   {
      private const int DefaultUserId = 1;

      private readonly int _userId;
      private readonly int? _appointmentId;

      private Appointment _prefill;

      public Appointment ResultAppointment { get; private set; }

      public DateTime Start => StartLocal;
      public DateTime End => EndLocal;
      public string TypeText => cboType.Text;
      public int CustomerId => cboCustomer.SelectedValue == null ? 0 : (int)cboCustomer.SelectedValue;

      // Use eastern time zone
      private static readonly TimeZoneInfo Eastern =
          TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

      public AppointmentForm() : this(DefaultUserId, null) { }

      public AppointmentForm(Appointment appt) : this(DefaultUserId, appt) { }

      public AppointmentForm(int userId, Appointment appt = null)
      {
         InitializeComponent();

         _userId = userId;
         _appointmentId = appt?.AppointmentId;
         _prefill = appt;

         Text = appt == null ? "New Appointment" : "Edit Appointment";
         btnSave.Text = appt == null ? "Save" : "Update";

         dtpStartDate.ValueChanged += (_, __) => KeepEndAfterStart();
         dtpStartTime.ValueChanged += (_, __) => KeepEndAfterStart();
         dtpEndDate.ValueChanged += (_, __) => KeepEndAfterStart();
         dtpEndTime.ValueChanged += (_, __) => KeepEndAfterStart();

         Load += AppointmentForm_Load;
      }

      private void AppointmentForm_Load(object sender, EventArgs e)
      {
         LoadCustomers();
         LoadTypes();

         dtpStartTime.Format = DateTimePickerFormat.Custom;
         dtpStartTime.CustomFormat = "hh:mm tt";
         dtpStartTime.ShowUpDown = true;

         dtpEndTime.Format = DateTimePickerFormat.Custom;
         dtpEndTime.CustomFormat = "hh:mm tt";
         dtpEndTime.ShowUpDown = true;

         if (_prefill == null)
         {
            var now = DateTime.Now;
            dtpStartDate.Value = now.Date;
            dtpStartTime.Value = now;
            dtpEndDate.Value = now.Date;
            dtpEndTime.Value = now.AddMinutes(30);
            return;
         }

         var startLocal = _prefill.Start;
         var endLocal = _prefill.End;

         dtpStartDate.Value = startLocal.Date;
         dtpStartTime.Value = startLocal;

         dtpEndDate.Value = endLocal.Date;
         dtpEndTime.Value = endLocal;

         SnapMinutes(dtpStartTime, 5);
         SnapMinutes(dtpEndTime, 5);

         cboCustomer.SelectedValue = _prefill.CustomerId;
         cboType.SelectedItem = _prefill.Type;
      }

      private void LoadCustomers()
      {
         var customers = CustomerDAO.GetAllCustomers();
         cboCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
         cboCustomer.DisplayMember = "CustomerName";
         cboCustomer.ValueMember = "CustomerId";
         cboCustomer.DataSource = customers;
      }

      private void LoadTypes()
      {
         cboType.DropDownStyle = ComboBoxStyle.DropDownList;

         cboType.Items.Clear();
         cboType.Items.AddRange(new object[]
         {
            "Planning",
            "Review",
            "Scrum",
            "Consultation",
            "Follow-up"
         });

         if (cboType.Items.Count > 0)
            cboType.SelectedIndex = 0;
      }

      private DateTime StartLocal => dtpStartDate.Value.Date + dtpStartTime.Value.TimeOfDay;
      private DateTime EndLocal => dtpEndDate.Value.Date + dtpEndTime.Value.TimeOfDay;

      private void KeepEndAfterStart()
      {
         if (EndLocal <= StartLocal)
         {
            var newEnd = StartLocal.AddMinutes(30);
            dtpEndDate.Value = newEnd.Date;
            dtpEndTime.Value = newEnd;
         }
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         if (cboCustomer.SelectedValue == null)
         {
            MessageBox.Show("Customer is required.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         if (cboType.SelectedItem == null || string.IsNullOrWhiteSpace(cboType.SelectedItem.ToString()))
         {
            MessageBox.Show("Type is required.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         if (EndLocal <= StartLocal)
         {
            MessageBox.Show("End must be after Start.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         if (!IsWithinBusinessHoursEastern(StartLocal, EndLocal))
         {
            MessageBox.Show("Appointment must be within business hours: 9:00 AM–5:00 PM Eastern, Mon–Fri.",
                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         if (AppointmentDAO.HasOverlap(_userId, StartLocal, EndLocal, _appointmentId))
         {
            MessageBox.Show("This appointment overlaps an existing appointment.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         int customerId = (int)cboCustomer.SelectedValue;
         string type = cboType.SelectedItem.ToString();

         var appt = new Appointment
         {
            AppointmentId = _appointmentId ?? 0,
            CustomerId = customerId,
            UserId = _userId,
            Type = type,
            Start = StartLocal,
            End = EndLocal,
            Title = type,        
            Description = "",
            Location = "",
            Contact = "",
            Url = "",
            CreatedBy = "test",
            LastUpdateBy = "test",
            CreateDate = DateTime.Now,

         };

         if (_appointmentId == null)
            AppointmentDAO.Insert(appt);
         else
            AppointmentDAO.Update(appt);

         ResultAppointment = appt;

         DialogResult = DialogResult.OK;
         Close();
      }

      private static bool IsWithinBusinessHoursEastern(DateTime startLocal, DateTime endLocal)
      {
         var startUtc = TimeZoneInfo.ConvertTimeToUtc(startLocal, TimeZoneInfo.Local);
         var endUtc = TimeZoneInfo.ConvertTimeToUtc(endLocal, TimeZoneInfo.Local);

         var startEastern = TimeZoneInfo.ConvertTimeFromUtc(
             DateTime.SpecifyKind(startUtc, DateTimeKind.Utc), Eastern);

         var endEastern = TimeZoneInfo.ConvertTimeFromUtc(
             DateTime.SpecifyKind(endUtc, DateTimeKind.Utc), Eastern);

         if (startEastern.Date != endEastern.Date) return false;

         if (startEastern.DayOfWeek == DayOfWeek.Saturday ||
             startEastern.DayOfWeek == DayOfWeek.Sunday)
         {
            return false;
         }

         TimeSpan open = new TimeSpan(9, 0, 0);
         TimeSpan close = new TimeSpan(17, 0, 0);

         return startEastern.TimeOfDay >= open && endEastern.TimeOfDay <= close;
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.Cancel;
         Close();
      }

      private void SnapMinutes(DateTimePicker picker, int intervalMinutes = 5)
      {
         var dt = picker.Value;
         int snappedMinutes = (dt.Minute / intervalMinutes) * intervalMinutes;

         var snapped = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, snappedMinutes, 0);

         if (picker.Value != snapped)
            picker.Value = snapped;
      }

      private void dtpStartTime_ValueChanged(object sender, EventArgs e)
      {
         SnapMinutes(dtpStartTime, 5);
      }

      private void dtpEndTime_ValueChanged(object sender, EventArgs e)
      {
         SnapMinutes(dtpEndTime, 5);
      }
   }
}
