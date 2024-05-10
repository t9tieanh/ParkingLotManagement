using BUL;
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
    public partial class frmChangePassword : Form
    {
        private string email; 
        public frmChangePassword(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtRePassword.Text)
            {
                lblNotice.Text = "Password and RePassword must match";
                return;
            }
            var account = new Account_DTO("",email,txtPassword.Text,"","");
            if (Account_BUL.ChangePassword(account))
            {
                MessageBox.Show("changed password successfully!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else lblNotice.Text = "(System error) password change not successful!";
        }

        #region code cho giao diện 
        /// <summary>
        /// code thanh panel trượt 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void picBackGround_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void iconHide1_Click(object sender, EventArgs e)
        {
            iconShow.BringToFront();
            txtRePassword.PasswordChar = '\0';
        }

        private void iconShow1_Click(object sender, EventArgs e)
        {
            iconHide1.BringToFront();
            txtRePassword.PasswordChar = '\0';
        }
        #endregion
    }
}
