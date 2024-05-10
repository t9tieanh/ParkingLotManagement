using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingLotManagementt.Forms
{
    public partial class frmProfileCustomer : Form
    {
        private Customer_DTO customer; 
        private void SetCustomer ()
        {
            txtFullNameCustomer.Text = customer.FullName;
            txtAddressCustomer.Text = customer.Address;
            txtIDCustomer.Text = customer.CustomerId.ToString();
            txtPhone.Text = customer.Phone; 
            txtUsername.Text = customer.Account.UserName;
            picAvatar.Image = (customer.Picture == null) ? picAvatar.Image : Image.FromStream (customer.Picture);
        }
        private void LoadContractContractCompleted ()
        {
            var contractCustomerLst = BUL.Contract_BUL.GetContractCustomer(customer,3);
            flowContract.Controls.Clear();
            foreach (var contract in contractCustomerLst)
            {
                flowContract.Controls.Add(new UC_Controls.UC_ContractForAdmin(contract));
            }
        }
        private void LoadContractContractUnfinished()
        {
            var contractCustomerLst = BUL.Contract_BUL.GetContractCustomer(customer, 0);
            contractCustomerLst = contractCustomerLst.Concat(BUL.Contract_BUL.GetContractCustomer(customer, 1)).
                Concat(BUL.Contract_BUL.GetContractCustomer(customer, 2)).ToList();
            
            flowContract.Controls.Clear();
            foreach (var contract in contractCustomerLst)
            {
                flowContract.Controls.Add(new UC_Controls.UC_ContractForAdmin(contract));
            }
        }
        public frmProfileCustomer(Customer_DTO customer)
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.customer = customer;
            SetCustomer();
            LoadContractContractUnfinished();
        }
        #region

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // width of ellipse
           int nHeightEllipse // height of ellipse
       );

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void pnTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        private void rdFinishedWork_CheckedChanged(object sender, EventArgs e)
        {
            LoadContractContractCompleted();
        }

        private void rdUnfinishedWork_CheckedChanged(object sender, EventArgs e)
        {
            LoadContractContractUnfinished();
        }
    }
}
