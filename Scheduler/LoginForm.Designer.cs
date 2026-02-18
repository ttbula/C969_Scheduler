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
         this.lblTitle = new System.Windows.Forms.Label();
         this.lblUsername = new System.Windows.Forms.Label();
         this.lblPassword = new System.Windows.Forms.Label();
         this.txtboxUsername = new System.Windows.Forms.TextBox();
         this.txtboxPassword = new System.Windows.Forms.TextBox();
         this.btnLogin = new System.Windows.Forms.Button();
         this.btnExit = new System.Windows.Forms.Button();
         this.lblLocation = new System.Windows.Forms.Label();
         this.panel1 = new System.Windows.Forms.Panel();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // lblTitle
         // 
         this.lblTitle.AutoSize = true;
         this.lblTitle.Font = new System.Drawing.Font("Yu Gothic", 18F,
                                       System.Drawing.FontStyle.Bold,
                                       System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTitle.Location = new System.Drawing.Point(95, 20);
         this.lblTitle.Name = "lblTitle";
         this.lblTitle.Size = new System.Drawing.Size(85, 31);
         this.lblTitle.TabIndex = 10;
         this.lblTitle.Text = "LogIn";
         this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // panel1
         // 
         this.panel1.BackColor = System.Drawing.SystemColors.Info;
         this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel1.Location = new System.Drawing.Point(30, 70);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(300, 220);
         this.panel1.TabIndex = 11;
         // 
         // lblUsername
         // 
         this.lblUsername.AutoSize = true;
         this.lblUsername.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F,
                                         System.Drawing.FontStyle.Regular,
                                         System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblUsername.Location = new System.Drawing.Point(20, 40);
         this.lblUsername.Name = "lblUsername";
         this.lblUsername.Size = new System.Drawing.Size(70, 17);
         this.lblUsername.TabIndex = 0;
         this.lblUsername.Text = "Username";
         // 
         // lblPassword
         // 
         this.lblPassword.AutoSize = true;
         this.lblPassword.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F,
                                         System.Drawing.FontStyle.Regular,
                                         System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblPassword.Location = new System.Drawing.Point(20, 100);
         this.lblPassword.Name = "lblPassword";
         this.lblPassword.Size = new System.Drawing.Size(68, 17);
         this.lblPassword.TabIndex = 1;
         this.lblPassword.Text = "Password";
         // 
         // txtboxUsername
         // 
         this.txtboxUsername.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F);
         this.txtboxUsername.Location = new System.Drawing.Point(110, 38);
         this.txtboxUsername.Name = "txtboxUsername";
         this.txtboxUsername.Size = new System.Drawing.Size(160, 24);
         this.txtboxUsername.TabIndex = 0;
         // 
         // txtboxPassword
         // 
         this.txtboxPassword.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F);
         this.txtboxPassword.Location = new System.Drawing.Point(110, 98);
         this.txtboxPassword.Name = "txtboxPassword";
         this.txtboxPassword.PasswordChar = '●';
         this.txtboxPassword.Size = new System.Drawing.Size(160, 24);
         this.txtboxPassword.TabIndex = 1;
         // 
         // btnLogin
         // 
         this.btnLogin.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F);
         this.btnLogin.Location = new System.Drawing.Point(50, 160);
         this.btnLogin.Name = "btnLogin";
         this.btnLogin.Size = new System.Drawing.Size(85, 30);
         this.btnLogin.TabIndex = 2;
         this.btnLogin.Text = "Login";
         this.btnLogin.UseVisualStyleBackColor = true;
         this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
         // 
         // btnExit
         // 
         this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnExit.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F);
         this.btnExit.Location = new System.Drawing.Point(165, 160);
         this.btnExit.Name = "btnExit";
         this.btnExit.Size = new System.Drawing.Size(85, 30);
         this.btnExit.TabIndex = 3;
         this.btnExit.Text = "Exit";
         this.btnExit.UseVisualStyleBackColor = true;
         this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
         // 
         // lblLocation
         // 
         this.lblLocation.AutoSize = true;
         this.lblLocation.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F,
                                          System.Drawing.FontStyle.Italic);
         this.lblLocation.ForeColor = System.Drawing.Color.Gray;
         this.lblLocation.Location = new System.Drawing.Point(30, 300);
         this.lblLocation.Name = "lblLocation";
         this.lblLocation.Size = new System.Drawing.Size(0, 15);
         this.lblLocation.TabIndex = 6;
         // 
         // LoginForm
         // 
         this.panel1.Controls.Add(this.lblUsername);
         this.panel1.Controls.Add(this.lblPassword);
         this.panel1.Controls.Add(this.txtboxUsername);
         this.panel1.Controls.Add(this.txtboxPassword);
         this.panel1.Controls.Add(this.btnLogin);
         this.panel1.Controls.Add(this.btnExit);
         this.AcceptButton = this.btnLogin;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnExit;
         this.ClientSize = new System.Drawing.Size(369, 340);
         this.Controls.Add(this.lblTitle);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.lblLocation);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "LoginForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Login";
         this.Load += new System.EventHandler(this.LoginForm_Load);
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();
      }

      #endregion

      private System.Windows.Forms.Label lblTitle;
      private System.Windows.Forms.Label lblUsername;
      private System.Windows.Forms.Label lblPassword;
      private System.Windows.Forms.TextBox txtboxUsername;
      private System.Windows.Forms.TextBox txtboxPassword;
      private System.Windows.Forms.Button btnLogin;
      private System.Windows.Forms.Button btnExit;
      private System.Windows.Forms.Label lblLocation;
      private System.Windows.Forms.Panel panel1;
   }
}