using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingLotManagementt.Forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        #region Code giao diện 
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

        /// <summary>
        /// code thanh panel trượt 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        private void iconHide_Click(object sender, EventArgs e)
        {
            iconShow.BringToFront();
            txtPassword.PasswordChar = '*';
        }

        private void iconShow_Click(object sender, EventArgs e)
        {
            iconHide.BringToFront();
            txtPassword.PasswordChar = '\0';
        }
        #endregion

        // Forgot password
        private void lblForget_Click(object sender, EventArgs e)
        {
            /* grbFirstLogin.Hide();
             grbForgot.Show();*/
            new frmComfirmEmail(false).ShowDialog();
        }
        private void lblCreateAccount_Click(object sender, EventArgs e)
        {
            new frmComfirmEmail(true).ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            Account_DTO newLogin = new Account_DTO(txtUsername.Text, txtPassword.Text);
            newLogin = BUL.Account_BUL.ProcessLogin(newLogin);
            if (newLogin == null) {
                lblErr.Text = "Invalid username or password!";
                return;
            }
            this.Hide();
            if (newLogin.TypeUser == "Worker")
            {
                var myWorker = BUL.Worker_BUL.GetWorker(newLogin.IdUser);
                if (myWorker.Type == "Look")
                    new frmMainWorkerPaking(myWorker).ShowDialog();
                else
                    new frmMainWorker(myWorker).ShowDialog();
            }
            else if (newLogin.TypeUser == "Customer")
                new frmMainCustomer(BUL.Customer_BUL.GetCustomer(newLogin.IdUser)).ShowDialog();
            else
            {
                var manager = BUL.Manager_BUL.GetManager(newLogin.IdUser);
                if (manager.ParkArea == null)
                    new frmMain(manager).ShowDialog();
                else 
                    new frmViewDetailParkAreaForAdmin(manager).ShowDialog();
            }
            txtUsername.Text = "";
            txtPassword.Text = "";
            this.Show();
        }

    }
}
