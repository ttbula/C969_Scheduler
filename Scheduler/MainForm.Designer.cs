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
         ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
         this.SuspendLayout();
         // 
         // dgvCustomers
         // 
         this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dgvCustomers.Location = new System.Drawing.Point(243, 115);
         this.dgvCustomers.Name = "dgvCustomers";
         this.dgvCustomers.Size = new System.Drawing.Size(240, 150);
         this.dgvCustomers.TabIndex = 0;
         // 
         // btnAddCustomer
         // 
         this.btnAddCustomer.Location = new System.Drawing.Point(243, 292);
         this.btnAddCustomer.Name = "btnAddCustomer";
         this.btnAddCustomer.Size = new System.Drawing.Size(75, 23);
         this.btnAddCustomer.TabIndex = 1;
         this.btnAddCustomer.Text = "Add Customer";
         this.btnAddCustomer.UseVisualStyleBackColor = true;
         this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
         // 
         // btnEditCustomer
         // 
         this.btnEditCustomer.Location = new System.Drawing.Point(243, 321);
         this.btnEditCustomer.Name = "btnEditCustomer";
         this.btnEditCustomer.Size = new System.Drawing.Size(75, 23);
         this.btnEditCustomer.TabIndex = 2;
         this.btnEditCustomer.Text = "Edit";
         this.btnEditCustomer.UseVisualStyleBackColor = true;
         // 
         // btnDeleteCustomer
         // 
         this.btnDeleteCustomer.Location = new System.Drawing.Point(243, 350);
         this.btnDeleteCustomer.Name = "btnDeleteCustomer";
         this.btnDeleteCustomer.Size = new System.Drawing.Size(75, 23);
         this.btnDeleteCustomer.TabIndex = 3;
         this.btnDeleteCustomer.Text = "Delete";
         this.btnDeleteCustomer.UseVisualStyleBackColor = true;
         this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.btnDeleteCustomer);
         this.Controls.Add(this.btnEditCustomer);
         this.Controls.Add(this.btnAddCustomer);
         this.Controls.Add(this.dgvCustomers);
         this.Name = "MainForm";
         this.Text = "MainForm";
         ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
         this.ResumeLayout(false);

        }

      #endregion

      private System.Windows.Forms.DataGridView dgvCustomers;
      private System.Windows.Forms.Button btnAddCustomer;
      private System.Windows.Forms.Button btnEditCustomer;
      private System.Windows.Forms.Button btnDeleteCustomer;
   }
}