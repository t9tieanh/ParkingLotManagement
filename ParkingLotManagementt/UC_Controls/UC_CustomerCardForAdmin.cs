using DTO;
using ParkingLotManagementt.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingLotManagementt.UC_Controls
{
    public partial class UC_CustomerCardForAdmin : UserControl
    {
        private Customer_DTO customer;
        private frmMain frmMain;
        private void SetCustomer ()
        {
            lblNameCustomer.Text = customer.FullName;
            lblCustomerID.Text = customer.CustomerId;
            lblAdress.Text = customer.Address;
            lblPhoneOfCustomer.Text = customer.Phone;
            picCustomer.Image = (customer.Picture != null) ? Image.FromStream(customer.Picture) : picCustomer.Image;
        }
        public UC_CustomerCardForAdmin()
        {
            InitializeComponent();
        }
        public UC_CustomerCardForAdmin(Customer_DTO customer,frmMain frmMain)
        {
            InitializeComponent();
            this.customer = customer;
            this.frmMain = frmMain;
            SetCustomer();
        }

        private void UC_CustomerCard_Click(object sender, EventArgs e)
        {
            frmMain.LoadContractFromCustomer (customer);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            new frmProfileCustomer(customer).ShowDialog();
        }

        private void btnViewContract_Click(object sender, EventArgs e)
        {
            frmMain.LoadContractFromCustomer(customer);
        }
    }
}
