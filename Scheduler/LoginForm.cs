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
         string pass = txtboxPassword.Text;

         const string sql = @"
SELECT userId
FROM user
WHERE userName=@u AND password=@p AND active=1
LIMIT 1;";

         using (MySqlConnection conn = Database.GetOpenConnection())
         using (MySqlCommand cmd = new MySqlCommand(sql, conn))
         {
            cmd.Parameters.AddWithValue("@u", user);
            cmd.Parameters.AddWithValue("@p", pass);

            var userId = cmd.ExecuteScalar();
            if (userId != null)
            {
               MessageBox.Show("You are being signed in");
               // TODO: open main form
               return;
            }
         }

         // login failed -> show localized error
         //ShowInvalidCredentials();


         ComponentResourceManager rm = new ComponentResourceManager(typeof(LoginForm));
         CultureInfo culture = CultureInfo.CurrentUICulture;

         MessageBox.Show(
             rm.GetString("Error_InvalidCredentials", culture) ?? "Invalid username/password.",
             Text,
             MessageBoxButtons.OK,
             MessageBoxIcon.Error
         );

      }

      private void btnExit_Click(object sender, EventArgs e)
      {
         this.Close();
      }
   }
}
