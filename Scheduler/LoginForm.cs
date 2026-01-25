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
         string password = txtboxPassword.Text.Trim();

         if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password))
         {
            ShowInvalidCredentials();
            return;
         }

         try
         {
            if (!TryAuthenticate(user, password, out int userId, out string userName))
            {
               LoginLogger.Log(user, false);
               ShowInvalidCredentials();
               return;
            }

            UserSession.Start(userId, userName);
            LoginLogger.Log(userName, true);
            OpenMainForm();
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


      private bool TryAuthenticate(string user, string password, out int userId, out string userName)
      {
         userId = 0;
         userName = null;

         const string sql = @"
           SELECT userId, userName
           FROM `user`
           WHERE userName = @u
             AND password = @p
             AND active = 1
           LIMIT 1;
         ";

         using (MySqlConnection conn = Database.GetConnection())
         using (MySqlCommand cmd = new MySqlCommand(sql, conn))
         {
            cmd.Parameters.AddWithValue("@u", user);
            cmd.Parameters.AddWithValue("@p", password);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
               if (!reader.Read())
                  return false;

               userId = reader.GetInt32("userId");
               userName = reader.GetString("userName");
               return true;
            }
         }
      }



      private void OpenMainForm()
      {
         MainForm main = new MainForm(UserSession.Current);

         main.FormClosed += (s, args) => Application.Exit();

         this.Hide();
         main.Show();
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
