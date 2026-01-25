namespace Scheduler
{
    partial class MainForm
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
         this.dgvCustomers = new System.Windows.Forms.DataGridView();
         this.btnAddCustomer = new System.Windows.Forms.Button();
         this.btnEditCustomer = new System.Windows.Forms.Button();
         this.btnDeleteCustomer = new System.Windows.Forms.Button();
         this.dgvAppointments = new System.Windows.Forms.DataGridView();
         this.btnAddAppointment = new System.Windows.Forms.Button();
         this.btnEditAppointment = new System.Windows.Forms.Button();
         this.btnDeleteAppointment = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
         this.SuspendLayout();
         // 
         // dgvCustomers
         // 
         this.dgvCustomers.BackgroundColor = System.Drawing.SystemColors.Info;
         this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dgvCustomers.Location = new System.Drawing.Point(44, 74);
         this.dgvCustomers.Name = "dgvCustomers";
         this.dgvCustomers.Size = new System.Drawing.Size(614, 132);
         this.dgvCustomers.TabIndex = 0;
         // 
         // btnAddCustomer
         // 
         this.btnAddCustomer.Location = new System.Drawing.Point(689, 74);
         this.btnAddCustomer.Name = "btnAddCustomer";
         this.btnAddCustomer.Size = new System.Drawing.Size(75, 23);
         this.btnAddCustomer.TabIndex = 1;
         this.btnAddCustomer.Text = "Add Customer";
         this.btnAddCustomer.UseVisualStyleBackColor = true;
         this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
         // 
         // btnEditCustomer
         // 
         this.btnEditCustomer.Location = new System.Drawing.Point(689, 103);
         this.btnEditCustomer.Name = "btnEditCustomer";
         this.btnEditCustomer.Size = new System.Drawing.Size(75, 23);
         this.btnEditCustomer.TabIndex = 2;
         this.btnEditCustomer.Text = "Edit";
         this.btnEditCustomer.UseVisualStyleBackColor = true;
         this.btnEditCustomer.Click += new System.EventHandler(this.btnEditCustomer_Click);
         // 
         // btnDeleteCustomer
         // 
         this.btnDeleteCustomer.Location = new System.Drawing.Point(689, 132);
         this.btnDeleteCustomer.Name = "btnDeleteCustomer";
         this.btnDeleteCustomer.Size = new System.Drawing.Size(75, 23);
         this.btnDeleteCustomer.TabIndex = 3;
         this.btnDeleteCustomer.Text = "Delete";
         this.btnDeleteCustomer.UseVisualStyleBackColor = true;
         this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
         // 
         // dgvAppointments
         // 
         this.dgvAppointments.BackgroundColor = System.Drawing.SystemColors.Info;
         this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dgvAppointments.Location = new System.Drawing.Point(44, 264);
         this.dgvAppointments.Name = "dgvAppointments";
         this.dgvAppointments.Size = new System.Drawing.Size(614, 132);
         this.dgvAppointments.TabIndex = 4;
         // 
         // btnAddAppointment
         // 
         this.btnAddAppointment.Location = new System.Drawing.Point(689, 264);
         this.btnAddAppointment.Name = "btnAddAppointment";
         this.btnAddAppointment.Size = new System.Drawing.Size(75, 23);
         this.btnAddAppointment.TabIndex = 5;
         this.btnAddAppointment.Text = "Add Customer";
         this.btnAddAppointment.UseVisualStyleBackColor = true;
         this.btnAddAppointment.Click += new System.EventHandler(this.btnAddAppointment_Click);
         // 
         // btnEditAppointment
         // 
         this.btnEditAppointment.Location = new System.Drawing.Point(689, 293);
         this.btnEditAppointment.Name = "btnEditAppointment";
         this.btnEditAppointment.Size = new System.Drawing.Size(75, 23);
         this.btnEditAppointment.TabIndex = 6;
         this.btnEditAppointment.Text = "Edit";
         this.btnEditAppointment.UseVisualStyleBackColor = true;
         this.btnEditAppointment.Click += new System.EventHandler(this.btnEditAppointment_Click);
         // 
         // btnDeleteAppointment
         // 
         this.btnDeleteAppointment.Location = new System.Drawing.Point(689, 322);
         this.btnDeleteAppointment.Name = "btnDeleteAppointment";
         this.btnDeleteAppointment.Size = new System.Drawing.Size(75, 23);
         this.btnDeleteAppointment.TabIndex = 7;
         this.btnDeleteAppointment.Text = "Delete";
         this.btnDeleteAppointment.UseVisualStyleBackColor = true;
         this.btnDeleteAppointment.Click += new System.EventHandler(this.btnDeleteAppointment_Click);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Yu Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(293, 44);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(121, 27);
         this.label1.TabIndex = 8;
         this.label1.Text = "Customers";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(278, 231);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(150, 30);
         this.label2.TabIndex = 9;
         this.label2.Text = "Appointments";
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.btnDeleteAppointment);
         this.Controls.Add(this.btnEditAppointment);
         this.Controls.Add(this.btnAddAppointment);
         this.Controls.Add(this.dgvAppointments);
         this.Controls.Add(this.btnDeleteCustomer);
         this.Controls.Add(this.btnEditCustomer);
         this.Controls.Add(this.btnAddCustomer);
         this.Controls.Add(this.dgvCustomers);
         this.Name = "MainForm";
         this.Text = "MainForm";
         ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

      #endregion

      private System.Windows.Forms.DataGridView dgvCustomers;
      private System.Windows.Forms.Button btnAddCustomer;
      private System.Windows.Forms.Button btnEditCustomer;
      private System.Windows.Forms.Button btnDeleteCustomer;
      private System.Windows.Forms.DataGridView dgvAppointments;
      private System.Windows.Forms.Button btnAddAppointment;
      private System.Windows.Forms.Button btnEditAppointment;
      private System.Windows.Forms.Button btnDeleteAppointment;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
   }
}