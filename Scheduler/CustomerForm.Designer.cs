namespace Scheduler
{
   partial class CustomerForm
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
         this.txtName = new System.Windows.Forms.TextBox();
         this.txtAddress = new System.Windows.Forms.TextBox();
         this.txtCity = new System.Windows.Forms.TextBox();
         this.txtCountry = new System.Windows.Forms.TextBox();
         this.txtPostal = new System.Windows.Forms.TextBox();
         this.txtPhone = new System.Windows.Forms.TextBox();
         this.btnSave = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // txtName
         // 
         this.txtName.Location = new System.Drawing.Point(199, 81);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(100, 20);
         this.txtName.TabIndex = 0;
         // 
         // txtAddress
         // 
         this.txtAddress.Location = new System.Drawing.Point(393, 85);
         this.txtAddress.Name = "txtAddress";
         this.txtAddress.Size = new System.Drawing.Size(100, 20);
         this.txtAddress.TabIndex = 1;
         // 
         // txtCity
         // 
         this.txtCity.Location = new System.Drawing.Point(199, 150);
         this.txtCity.Name = "txtCity";
         this.txtCity.Size = new System.Drawing.Size(100, 20);
         this.txtCity.TabIndex = 2;
         // 
         // txtCountry
         // 
         this.txtCountry.Location = new System.Drawing.Point(393, 154);
         this.txtCountry.Name = "txtCountry";
         this.txtCountry.Size = new System.Drawing.Size(100, 20);
         this.txtCountry.TabIndex = 3;
         // 
         // txtPostal
         // 
         this.txtPostal.Location = new System.Drawing.Point(199, 237);
         this.txtPostal.Name = "txtPostal";
         this.txtPostal.Size = new System.Drawing.Size(100, 20);
         this.txtPostal.TabIndex = 4;
         // 
         // txtPhone
         // 
         this.txtPhone.Location = new System.Drawing.Point(393, 237);
         this.txtPhone.Name = "txtPhone";
         this.txtPhone.Size = new System.Drawing.Size(100, 20);
         this.txtPhone.TabIndex = 5;
         // 
         // btnSave
         // 
         this.btnSave.Location = new System.Drawing.Point(224, 330);
         this.btnSave.Name = "btnSave";
         this.btnSave.Size = new System.Drawing.Size(75, 23);
         this.btnSave.TabIndex = 6;
         this.btnSave.Text = "Save";
         this.btnSave.UseVisualStyleBackColor = true;
         this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(393, 330);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 7;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(132, 88);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(35, 13);
         this.label1.TabIndex = 8;
         this.label1.Text = "Name";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(143, 157);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(24, 13);
         this.label2.TabIndex = 9;
         this.label2.Text = "City";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(131, 237);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(36, 13);
         this.label3.TabIndex = 10;
         this.label3.Text = "Postal";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(338, 237);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(38, 13);
         this.label4.TabIndex = 11;
         this.label4.Text = "Phone";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(333, 157);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(43, 13);
         this.label5.TabIndex = 12;
         this.label5.Text = "Country";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(331, 88);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(45, 13);
         this.label6.TabIndex = 13;
         this.label6.Text = "Address";
         // 
         // CustomerForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnSave);
         this.Controls.Add(this.txtPhone);
         this.Controls.Add(this.txtPostal);
         this.Controls.Add(this.txtCountry);
         this.Controls.Add(this.txtCity);
         this.Controls.Add(this.txtAddress);
         this.Controls.Add(this.txtName);
         this.Name = "CustomerForm";
         this.Text = "CustomerForm";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox txtName;
      private System.Windows.Forms.TextBox txtAddress;
      private System.Windows.Forms.TextBox txtCity;
      private System.Windows.Forms.TextBox txtCountry;
      private System.Windows.Forms.TextBox txtPostal;
      private System.Windows.Forms.TextBox txtPhone;
      private System.Windows.Forms.Button btnSave;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label6;
   }
}