namespace Scheduler
{
   partial class AppointmentForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
         this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
         this.btnSave = new System.Windows.Forms.Button();
         this.cboCustomer = new System.Windows.Forms.ComboBox();
         this.cboType = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
         this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.tableLayoutPanel2.SuspendLayout();
         this.SuspendLayout();
         // 
         // dtpStartDate
         // 
         this.dtpStartDate.Location = new System.Drawing.Point(223, 94);
         this.dtpStartDate.Name = "dtpStartDate";
         this.dtpStartDate.Size = new System.Drawing.Size(200, 20);
         this.dtpStartDate.TabIndex = 0;
         // 
         // dtpEndDate
         // 
         this.dtpEndDate.Location = new System.Drawing.Point(223, 208);
         this.dtpEndDate.Name = "dtpEndDate";
         this.dtpEndDate.Size = new System.Drawing.Size(200, 20);
         this.dtpEndDate.TabIndex = 2;
         // 
         // btnSave
         // 
         this.btnSave.Location = new System.Drawing.Point(359, 392);
         this.btnSave.Name = "btnSave";
         this.btnSave.Size = new System.Drawing.Size(75, 23);
         this.btnSave.TabIndex = 3;
         this.btnSave.Text = "Save";
         this.btnSave.UseVisualStyleBackColor = true;
         // 
         // cboCustomer
         // 
         this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cboCustomer.FormattingEnabled = true;
         this.cboCustomer.Location = new System.Drawing.Point(223, 3);
         this.cboCustomer.Name = "cboCustomer";
         this.cboCustomer.Size = new System.Drawing.Size(121, 21);
         this.cboCustomer.TabIndex = 5;
         // 
         // cboType
         // 
         this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cboType.FormattingEnabled = true;
         this.cboType.Location = new System.Drawing.Point(223, 52);
         this.cboType.Name = "cboType";
         this.cboType.Size = new System.Drawing.Size(121, 21);
         this.cboType.TabIndex = 6;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(51, 13);
         this.label1.TabIndex = 7;
         this.label1.Text = "Customer";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(3, 49);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(31, 13);
         this.label2.TabIndex = 8;
         this.label2.Text = "Type";
         // 
         // dtpStartTime
         // 
         this.dtpStartTime.CustomFormat = "hh:mm tt";
         this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
         this.dtpStartTime.Location = new System.Drawing.Point(223, 154);
         this.dtpStartTime.Name = "dtpStartTime";
         this.dtpStartTime.Size = new System.Drawing.Size(200, 20);
         this.dtpStartTime.TabIndex = 9;
         // 
         // dtpEndTime
         // 
         this.dtpEndTime.CustomFormat = "hh:mm tt";
         this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
         this.dtpEndTime.Location = new System.Drawing.Point(223, 272);
         this.dtpEndTime.Name = "dtpEndTime";
         this.dtpEndTime.Size = new System.Drawing.Size(200, 20);
         this.dtpEndTime.TabIndex = 10;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(3, 91);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(55, 13);
         this.label3.TabIndex = 11;
         this.label3.Text = "Start Date";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(3, 151);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(55, 13);
         this.label4.TabIndex = 12;
         this.label4.Text = "Start Time";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(3, 205);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(52, 13);
         this.label5.TabIndex = 13;
         this.label5.Text = "End Date";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(3, 269);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(52, 13);
         this.label6.TabIndex = 14;
         this.label6.Text = "End Time";
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(263, 362);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(266, 13);
         this.label7.TabIndex = 15;
         this.label7.Text = "Business hours are 9:00 AM–5:00 PM Eastern, Mon–Fri";
         // 
         // tableLayoutPanel2
         // 
         this.tableLayoutPanel2.ColumnCount = 2;
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.5F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.5F));
         this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
         this.tableLayoutPanel2.Controls.Add(this.cboCustomer, 1, 0);
         this.tableLayoutPanel2.Controls.Add(this.dtpEndTime, 1, 5);
         this.tableLayoutPanel2.Controls.Add(this.label6, 0, 5);
         this.tableLayoutPanel2.Controls.Add(this.dtpStartTime, 1, 3);
         this.tableLayoutPanel2.Controls.Add(this.cboType, 1, 1);
         this.tableLayoutPanel2.Controls.Add(this.dtpEndDate, 1, 4);
         this.tableLayoutPanel2.Controls.Add(this.label5, 0, 4);
         this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
         this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
         this.tableLayoutPanel2.Controls.Add(this.dtpStartDate, 1, 2);
         this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
         this.tableLayoutPanel2.Location = new System.Drawing.Point(173, 24);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 6;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.78788F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.21212F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
         this.tableLayoutPanel2.Size = new System.Drawing.Size(437, 320);
         this.tableLayoutPanel2.TabIndex = 16;
         // 
         // AppointmentForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.tableLayoutPanel2);
         this.Controls.Add(this.label7);
         this.Controls.Add(this.btnSave);
         this.Name = "AppointmentForm";
         this.Text = "Appointment Form";
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel2.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.DateTimePicker dtpStartDate;
      private System.Windows.Forms.DateTimePicker dtpEndDate;
      private System.Windows.Forms.Button btnSave;
      private System.Windows.Forms.ComboBox cboCustomer;
      private System.Windows.Forms.ComboBox cboType;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.DateTimePicker dtpStartTime;
      private System.Windows.Forms.DateTimePicker dtpEndTime;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
   }
}