using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Scheduler
{
   public partial class CustomerForm : Form
   {
      public string CustomerName => txtName.Text.Trim();
      public string Address => txtAddress.Text.Trim();
      public string City => txtCity.Text.Trim();
      public string Country => txtCountry.Text.Trim();
      public string PostalCode => txtPostal.Text.Trim();
      public string Phone => txtPhone.Text.Trim();

      public int CustomerId { get; private set; }

      public CustomerForm()
      {
         InitializeComponent();
         this.Text = "Add Customer";
         btnSave.Text = "Save";
      }

      public CustomerForm(Customer customer)
      {
         InitializeComponent();
         CustomerId = customer.CustomerId;

         txtName.Text = customer.CustomerName;
         txtAddress.Text = customer.Address;
         txtCity.Text = customer.City;
         txtCountry.Text = customer.Country;
         txtPostal.Text = customer.PostalCode;
         txtPhone.Text = customer.Phone;

         this.Text = "Edit Customer";
         btnSave.Text = "Update";
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         string error;
         if (!ValidateInputs(out error))
         {
            MessageBox.Show(error, "Invalid Customer",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         DialogResult = DialogResult.OK;
         Close();
      }

      private bool ValidateInputs(out string error)
      {
         var name = CustomerName;
         var address = Address;
         var phone = Phone;

         if (string.IsNullOrWhiteSpace(name) ||
             string.IsNullOrWhiteSpace(address) ||
             string.IsNullOrWhiteSpace(phone))
         {
            error = "Name, address, and phone are required.";
            return false;
         }

         foreach (char ch in phone)
         {
            if (!(char.IsDigit(ch) || ch == '-'))
            {
               error = "Phone can contain only digits and dashes.";
               return false;
            }
         }

         if (string.IsNullOrWhiteSpace(City) || string.IsNullOrWhiteSpace(Country))
         {
            error = "City and country are required.";
            return false;
         }

         error = null;
         return true;
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.Cancel;
         Close();
      }
   }
}
