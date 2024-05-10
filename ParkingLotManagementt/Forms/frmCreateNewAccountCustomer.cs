using BUL;
using DTO;
using InputCheck;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingLotManagementt.Forms
{
    public partial class frmCreateNewAccountCustomer : Form
    {
        Customer_DTO myCustomer = new Customer_DTO ("","");
        string email; 
        public frmCreateNewAccountCustomer(string email)
        {
            InitializeComponent();
            txtEmail.Text = email;
        }

        private void frmCreateNewAccountCustomer_Load(object sender, EventArgs e)
        {

        }
        private bool CheckInputEmail ()
        {
            return true;
        }
        private void btnSendOtp_Click(object sender, EventArgs e)
        {

        }

        private void btnContinue_Click(object sender, EventArgs e)
        {

        }

        private void lblImportYourPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn file PNG";

            // Thiết lập bộ lọc để chỉ hiển thị file PNG
            openFileDialog.Filter = "PNG Files|*.png";

            // Thiết lập loại file mặc định
            openFileDialog.DefaultExt = "png";

            // Cho phép chọn nhiều file
            openFileDialog.Multiselect = false;
            DialogResult result = openFileDialog.ShowDialog(); // chọn chỗ lưu
            if (result == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                picCustomer.ImageLocation = filePath;
            }
        }
        private bool CheckInput()
        {
            bool wasErrol = true;
            error.Clear();
            if (txtPassword.Text != txtRePassword.Text)
            {
                lblNotice.Text = "Password and RePassword must match";
                return false;
            }
            if (!InputCheck.CheckInput.Name (txtFullNameCustomer.Text))
            {
                error.SetError(txtFullNameCustomer,"Full name customer not valid !");
                wasErrol = false;
            }
            if (!InputCheck.CheckInput.IsValidPhoneNumber(txtPhone.Text))
            {
                error.SetError(txtPhone, "Phone number not valid");
                wasErrol = false;
            }
            if (!InputCheck.CheckInput.AddressIsValid (txtAddressCustomer.Text))
            {
                error.SetError(txtAddressCustomer, "Address not valid");
                wasErrol = false;
            }
            if (!InputCheck.CheckInput.IsValidUsername(txtUsername.Text) ){
                error.SetError(txtUsername, "UserName not valid !");
                wasErrol = false;
            }
            // email đã check rồi 
            return wasErrol;
        }
        private void GetCustomer ()
        {
            
            myCustomer.CustomerId = txtUsername.Text;
            myCustomer.FullName = txtFullNameCustomer.Text;
            myCustomer.Address = txtAddressCustomer.Text;
            myCustomer.Phone = txtPhone.Text;
            MemoryStream picWorker = new MemoryStream();
            picCustomer.Image.Save(picWorker, picCustomer.Image.RawFormat);
            myCustomer.Picture = picWorker;
            myCustomer.Status = true;

            myCustomer.Account = new Account_DTO(txtUsername.Text, txtEmail.Text, txtPassword.Text, txtUsername.Text, "Customer");
        }
        private void btnSendOtp_Click_1(object sender, EventArgs e)
        {
            if (!CheckInput()) return;
            GetCustomer();
            if (Customer_BUL.InsertCustomer(myCustomer))
            {
                MessageBox.Show("You have successfully created an account! , please log in again to continue, have fun !","Notice",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                lblNotice.Text = "User name already exists, please choose another user name !";
            }
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
        private void guna2PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        private void picExit_Click_1(object sender, EventArgs e)
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
