namespace Scheduler
{
   partial class ReportsForm
   {
      private System.ComponentModel.IContainer components = null;

      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      private void InitializeComponent()
      {
         this.btnTypesByMonth = new System.Windows.Forms.Button();
         this.btnUserSchedules = new System.Windows.Forms.Button();
         this.btnCustomerAppointments = new System.Windows.Forms.Button();
         this.dgvReport = new System.Windows.Forms.DataGridView();
         this.lblReportTitle = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
         this.SuspendLayout();
         // 
         // btnTypesByMonth
         // 
         this.btnTypesByMonth.Location = new System.Drawing.Point(30, 60);
         this.btnTypesByMonth.Name = "btnTypesByMonth";
         this.btnTypesByMonth.Size = new System.Drawing.Size(200, 40);
         this.btnTypesByMonth.TabIndex = 0;
         this.btnTypesByMonth.Text = "Appointment Types by Month";
         this.btnTypesByMonth.UseVisualStyleBackColor = true;
         this.btnTypesByMonth.Click += new System.EventHandler(this.btnTypesByMonth_Click);
         // 
         // btnUserSchedules
         // 
         this.btnUserSchedules.Location = new System.Drawing.Point(316, 60);
         this.btnUserSchedules.Name = "btnUserSchedules";
         this.btnUserSchedules.Size = new System.Drawing.Size(200, 40);
         this.btnUserSchedules.TabIndex = 1;
         this.btnUserSchedules.Text = "User Schedules";
         this.btnUserSchedules.UseVisualStyleBackColor = true;
         this.btnUserSchedules.Click += new System.EventHandler(this.btnUserSchedules_Click);
         // 
         // btnCustomerAppointments
         // 
         this.btnCustomerAppointments.Location = new System.Drawing.Point(570, 60);
         this.btnCustomerAppointments.Name = "btnCustomerAppointments";
         this.btnCustomerAppointments.Size = new System.Drawing.Size(200, 40);
         this.btnCustomerAppointments.TabIndex = 2;
         this.btnCustomerAppointments.Text = "Appointments by Customer";
         this.btnCustomerAppointments.UseVisualStyleBackColor = true;
         this.btnCustomerAppointments.Click += new System.EventHandler(this.btnCustomerAppointments_Click);
         // 
         // dgvReport
         // 
         this.dgvReport.BackgroundColor = System.Drawing.SystemColors.Info;
         this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dgvReport.Location = new System.Drawing.Point(30, 120);
         this.dgvReport.Name = "dgvReport";
         this.dgvReport.ReadOnly = true;
         this.dgvReport.Size = new System.Drawing.Size(740, 330);
         this.dgvReport.TabIndex = 3;
         // 
         // lblReportTitle
         // 
         this.lblReportTitle.AutoSize = true;
         this.lblReportTitle.Font = new System.Drawing.Font("Yu Gothic", 18F, System.Drawing.FontStyle.Bold);
         this.lblReportTitle.Location = new System.Drawing.Point(362, 26);
         this.lblReportTitle.Name = "lblReportTitle";
         this.lblReportTitle.Size = new System.Drawing.Size(105, 31);
         this.lblReportTitle.TabIndex = 4;
         this.lblReportTitle.Text = "Reports";
         // 
         // ReportsForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 475);
         this.Controls.Add(this.lblReportTitle);
         this.Controls.Add(this.dgvReport);
         this.Controls.Add(this.btnCustomerAppointments);
         this.Controls.Add(this.btnUserSchedules);
         this.Controls.Add(this.btnTypesByMonth);
         this.Name = "ReportsForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Reports";
         ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button btnTypesByMonth;
      private System.Windows.Forms.Button btnUserSchedules;
      private System.Windows.Forms.Button btnCustomerAppointments;
      private System.Windows.Forms.DataGridView dgvReport;
      private System.Windows.Forms.Label lblReportTitle;
   }
}