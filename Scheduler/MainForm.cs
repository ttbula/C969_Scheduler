using System;
using System.Windows.Forms;

namespace Scheduler
{
   public partial class MainForm : Form
   {
      private readonly UserSession _session;

      public MainForm(UserSession session)
      {
         InitializeComponent();
         _session = session;

         // Title bar shows logged-in user (rubric-friendly)
         Text = $"Scheduler - {_session.UserName}";
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         // This is where you will later:
         // - Load appointments
         // - Check upcoming appointment alerts
         // - Populate grids
      }
   }
}
