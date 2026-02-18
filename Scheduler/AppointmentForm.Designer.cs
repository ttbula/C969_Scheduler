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
         this.lblTitle = new System.Windows.Forms.Label();
         this.panel1 = new System.Windows.Forms.Panel();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.label1 = new System.Windows.Forms.Label();
         this.cboCustomer = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this.cboType = new System.Windows.Forms.ComboBox();
         this.label3 = new System.Windows.Forms.Label();
         this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
         this.label4 = new System.Windows.Forms.Label();
         this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
         this.label5 = new System.Windows.Forms.Label();
         this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
         this.label6 = new System.Windows.Forms.Label();
         this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
         this.label7 = new System.Windows.Forms.Label();
         this.btnSave = new System.Windows.Forms.Button();
         this.panel1.SuspendLayout();
         this.tableLayoutPanel2.SuspendLayout();
         this.SuspendLayout();
         // 
         // lblTitle
         // 
         this.lblTitle.AutoSize = true;
         this.lblTitle.Font = new System.Drawing.Font("Yu Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTitle.Location = new System.Drawing.Point(329, 31);
         this.lblTitle.Name = "lblTitle";
         this.lblTitle.Size = new System.Drawing.Size(165, 31);
         this.lblTitle.TabIndex = 20;
         this.lblTitle.Text = "Appointment";
         // 
         // panel1
         // 
         this.panel1.BackColor = System.Drawing.SystemColors.Info;
         this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel1.Controls.Add(this.tableLayoutPanel2);
         this.panel1.Controls.Add(this.label7);
         this.panel1.Controls.Add(this.btnSave);
         this.panel1.Location = new System.Drawing.Point(30, 65);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(740, 360);
         this.panel1.TabIndex = 21;
         // 
         // tableLayoutPanel2
         // 
         this.tableLayoutPanel2.ColumnCount = 2;
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
         this.tableLayoutPanel2.Controls.Add(this.cboCustomer, 1, 0);
         this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
         this.tableLayoutPanel2.Controls.Add(this.cboType, 1, 1);
         this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
         this.tableLayoutPanel2.Controls.Add(this.dtpStartDate, 1, 2);
         this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
         this.tableLayoutPanel2.Controls.Add(this.dtpStartTime, 1, 3);
         this.tableLayoutPanel2.Controls.Add(this.label5, 0, 4);
         this.tableLayoutPanel2.Controls.Add(this.dtpEndDate, 1, 4);
         this.tableLayoutPanel2.Controls.Add(this.label6, 0, 5);
         this.tableLayoutPanel2.Controls.Add(this.dtpEndTime, 1, 5);
         this.tableLayoutPanel2.Location = new System.Drawing.Point(20, 20);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 6;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
         this.tableLayoutPanel2.Size = new System.Drawing.Size(695, 276);
         this.tableLayoutPanel2.TabIndex = 0;
         // 
         // label1
         // 
         this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(3, 14);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(64, 17);
         this.label1.TabIndex = 7;
         this.label1.Text = "Customer";
         // 
         // cboCustomer
         // 
         this.cboCustomer.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cboCustomer.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F);
         this.cboCustomer.FormattingEnabled = true;
         this.cboCustomer.Location = new System.Drawing.Point(113, 10);
         this.cboCustomer.Name = "cboCustomer";
         this.cboCustomer.Size = new System.Drawing.Size(250, 25);
         this.cboCustomer.TabIndex = 5;
         // 
         // label2
         // 
         this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(3, 60);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(35, 17);
         this.label2.TabIndex = 8;
         this.label2.Text = "Type";
         // 
         // cboType
         // 
         this.cboType.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cboType.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F);
         this.cboType.FormattingEnabled = true;
         this.cboType.Location = new System.Drawing.Point(113, 56);
         this.cboType.Name = "cboType";
         this.cboType.Size = new System.Drawing.Size(250, 25);
         this.cboType.TabIndex = 6;
         // 
         // label3
         // 
         this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(3, 106);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(66, 17);
         this.label3.TabIndex = 11;
         this.label3.Text = "Start Date";
         // 
         // dtpStartDate
         // 
         this.dtpStartDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.dtpStartDate.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F);
         this.dtpStartDate.Location = new System.Drawing.Point(113, 102);
         this.dtpStartDate.Name = "dtpStartDate";
         this.dtpStartDate.Size = new System.Drawing.Size(250, 25);
         this.dtpStartDate.TabIndex = 0;
         // 
         // label4
         // 
         this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(3, 152);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(67, 17);
         this.label4.TabIndex = 12;
         this.label4.Text = "Start Time";
         // 
         // dtpStartTime
         // 
         this.dtpStartTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.dtpStartTime.CustomFormat = "hh:mm tt";
         this.dtpStartTime.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F);
         this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
         this.dtpStartTime.Location = new System.Drawing.Point(113, 148);
         this.dtpStartTime.Name = "dtpStartTime";
         this.dtpStartTime.ShowUpDown = true;
         this.dtpStartTime.Size = new System.Drawing.Size(150, 25);
         this.dtpStartTime.TabIndex = 9;
         this.dtpStartTime.ValueChanged += new System.EventHandler(this.dtpStartTime_ValueChanged);
         // 
         // label5
         // 
         this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.Location = new System.Drawing.Point(3, 198);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(61, 17);
         this.label5.TabIndex = 13;
         this.label5.Text = "End Date";
         // 
         // dtpEndDate
         // 
         this.dtpEndDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.dtpEndDate.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F);
         this.dtpEndDate.Location = new System.Drawing.Point(113, 194);
         this.dtpEndDate.Name = "dtpEndDate";
         this.dtpEndDate.Size = new System.Drawing.Size(250, 25);
         this.dtpEndDate.TabIndex = 2;
         // 
         // label6
         // 
         this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label6.AutoSize = true;
         this.label6.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label6.Location = new System.Drawing.Point(3, 244);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(62, 17);
         this.label6.TabIndex = 14;
         this.label6.Text = "End Time";
         // 
         // dtpEndTime
         // 
         this.dtpEndTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.dtpEndTime.CustomFormat = "hh:mm tt";
         this.dtpEndTime.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F);
         this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
         this.dtpEndTime.Location = new System.Drawing.Point(113, 240);
         this.dtpEndTime.Name = "dtpEndTime";
         this.dtpEndTime.ShowUpDown = true;
         this.dtpEndTime.Size = new System.Drawing.Size(150, 25);
         this.dtpEndTime.TabIndex = 10;
         this.dtpEndTime.ValueChanged += new System.EventHandler(this.dtpEndTime_ValueChanged);
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Italic);
         this.label7.ForeColor = System.Drawing.Color.Gray;
         this.label7.Location = new System.Drawing.Point(17, 326);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(270, 13);
         this.label7.TabIndex = 15;
         this.label7.Text = "Business hours are 9:00 AM–5:00 PM Eastern, Mon–Fri";
         // 
         // btnSave
         // 
         this.btnSave.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F);
         this.btnSave.Location = new System.Drawing.Point(630, 315);
         this.btnSave.Name = "btnSave";
         this.btnSave.Size = new System.Drawing.Size(90, 32);
         this.btnSave.TabIndex = 3;
         this.btnSave.Text = "Save";
         this.btnSave.UseVisualStyleBackColor = true;
         this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
         // 
         // AppointmentForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 460);
         this.Controls.Add(this.lblTitle);
         this.Controls.Add(this.panel1);
         this.Name = "AppointmentForm";
         this.Text = "Appointment Form";
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel2.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label lblTitle;
      private System.Windows.Forms.Panel panel1;
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