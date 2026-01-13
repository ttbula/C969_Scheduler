namespace Scheduler
{
    partial class LoginForm
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
         this.lblUsername = new System.Windows.Forms.Label();
         this.lblPassword = new System.Windows.Forms.Label();
         this.txtboxUsername = new System.Windows.Forms.TextBox();
         this.txtboxPassword = new System.Windows.Forms.TextBox();
         this.btnLogin = new System.Windows.Forms.Button();
         this.btnExit = new System.Windows.Forms.Button();
         this.lblLocation = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // lblUsername
         // 
         this.lblUsername.AutoSize = true;
         this.lblUsername.Location = new System.Drawing.Point(21, 38);
         this.lblUsername.Name = "lblUsername";
         this.lblUsername.Size = new System.Drawing.Size(55, 13);
         this.lblUsername.TabIndex = 0;
         this.lblUsername.Text = "Username";
         // 
         // lblPassword
         // 
         this.lblPassword.AutoSize = true;
         this.lblPassword.Location = new System.Drawing.Point(21, 103);
         this.lblPassword.Name = "lblPassword";
         this.lblPassword.Size = new System.Drawing.Size(53, 13);
         this.lblPassword.TabIndex = 1;
         this.lblPassword.Text = "Password";
         // 
         // txtboxUsername
         // 
         this.txtboxUsername.Location = new System.Drawing.Point(208, 38);
         this.txtboxUsername.Name = "txtboxUsername";
         this.txtboxUsername.Size = new System.Drawing.Size(100, 20);
         this.txtboxUsername.TabIndex = 0;
         // 
         // txtboxPassword
         // 
         this.txtboxPassword.Location = new System.Drawing.Point(208, 103);
         this.txtboxPassword.Name = "txtboxPassword";
         this.txtboxPassword.Size = new System.Drawing.Size(100, 20);
         this.txtboxPassword.TabIndex = 1;
         // 
         // btnLogin
         // 
         this.btnLogin.Location = new System.Drawing.Point(233, 296);
         this.btnLogin.Name = "btnLogin";
         this.btnLogin.Size = new System.Drawing.Size(75, 23);
         this.btnLogin.TabIndex = 2;
         this.btnLogin.Text = "Login";
         this.btnLogin.UseVisualStyleBackColor = true;
         this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
         // 
         // btnExit
         // 
         this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnExit.Location = new System.Drawing.Point(469, 296);
         this.btnExit.Name = "btnExit";
         this.btnExit.Size = new System.Drawing.Size(75, 23);
         this.btnExit.TabIndex = 3;
         this.btnExit.Text = "Exit";
         this.btnExit.UseVisualStyleBackColor = true;
         this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
         // 
         // lblLocation
         // 
         this.lblLocation.AutoSize = true;
         this.lblLocation.Location = new System.Drawing.Point(466, 110);
         this.lblLocation.Name = "lblLocation";
         this.lblLocation.Size = new System.Drawing.Size(0, 13);
         this.lblLocation.TabIndex = 6;
         // 
         // LoginForm
         // 
         this.AcceptButton = this.btnLogin;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnExit;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.lblLocation);
         this.Controls.Add(this.btnExit);
         this.Controls.Add(this.btnLogin);
         this.Controls.Add(this.txtboxPassword);
         this.Controls.Add(this.txtboxUsername);
         this.Controls.Add(this.lblPassword);
         this.Controls.Add(this.lblUsername);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "LoginForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Login";
         this.Load += new System.EventHandler(this.LoginForm_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtboxUsername;
        private System.Windows.Forms.TextBox txtboxPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblLocation;
    }
}

