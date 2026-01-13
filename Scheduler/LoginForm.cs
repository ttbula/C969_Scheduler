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
         var rm = new ResourceManager("Scheduler.LoginForm", typeof(LoginForm).Assembly);

         Text = rm.GetString("Title_Login", culture) ?? Text;

         lblUsername.Text = rm.GetString("Label_Username", culture) ?? lblUsername.Text;
         lblPassword.Text = rm.GetString("Label_Password", culture) ?? lblPassword.Text;

         btnLogin.Text = rm.GetString("Button_Login", culture) ?? btnLogin.Text;
         btnExit.Text = rm.GetString("Button_Exit", culture) ?? btnExit.Text;
      }
   


      private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
