using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Scheduler.Data;

namespace Scheduler
{
   public partial class LoginForm : Form
   {
      public LoginForm()
      {
         InitializeComponent();
      }

      private void LoginForm_Load(object sender, EventArgs e)
      {
         // change to spanish
         //ApplyLocalization(new CultureInfo("es"));
         ApplyLocalization(CultureInfo.CurrentUICulture);
      }

      private void ApplyLocalization(CultureInfo culture)
      {
         ResourceManager rm = new ResourceManager("Scheduler.LoginForm", typeof(LoginForm).Assembly);

         Text = rm.GetString("Title_Login", culture) ?? Text;

         lblUsername.Text = rm.GetString("Label_Username", culture) ?? lblUsername.Text;
         lblPassword.Text = rm.GetString("Label_Password", culture) ?? lblPassword.Text;

         btnLogin.Text = rm.GetString("Button_Login", culture) ?? btnLogin.Text;
         btnExit.Text = rm.GetString("Button_Exit", culture) ?? btnExit.Text;
      }



      private void btnLogin_Click(object sender, EventArgs e)
      {
         string user = txtboxUsername.Text.Trim();
         string pass = txtboxPassword.Text.Trim();

         const string sql = @"
            SELECT userId, userName
            FROM user
            WHERE userName=@u 
               AND password=@p 
               AND active=1
            LIMIT 1;
         ";

         try
         {
            using (var conn = Database.GetOpenConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
               cmd.Parameters.AddWithValue("@u", user);
               cmd.Parameters.AddWithValue("@p", pass);

               using (var reader = cmd.ExecuteReader())
               {
                  if (reader.Read())
                  {
                     int userId = reader.GetInt32("userId");
                     string userName = reader.GetString("userName");

                     // Log successful attempt
                     LoginLogger.Log(userName, true);

                     UserSession session = new UserSession(userId, userName);

                     // Create main
                     MainForm main = new MainForm(session);

                     // Hide login
                     this.Hide();

                     // Show main
                     main.Show();

                     return;

                  }
               }
            }

            // login failed
            LoginLogger.Log(user, false);
            ShowInvalidCredentials();
         }

         catch (Exception ex)
         {
            MessageBox.Show(
            ex.Message,
            "Login Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
            );
         }

      }

      private void btnExit_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void ShowInvalidCredentials()
      {
         ComponentResourceManager rm =
             new ComponentResourceManager(typeof(LoginForm));
         CultureInfo culture = CultureInfo.CurrentUICulture;

         MessageBox.Show(
             rm.GetString("Error_InvalidCredentials", culture)
                 ?? "Invalid username or password.",
             Text,
             MessageBoxButtons.OK,
             MessageBoxIcon.Error
         );
      }

   }
}
