using BUL;
using InputCheck;
using ParkingLotManagementt.Forms;
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

namespace ParkingLotManagementt
{
    public partial class frmComfirmEmail : Form
    {
        private bool isCreateAccount = false;
        private bool isForgetPassword = false;
        public frmComfirmEmail (bool isCreateAccount)
        {
            InitializeComponent();
            this.isCreateAccount = isCreateAccount;
            isForgetPassword = !isCreateAccount;
        }

        private void frmCreateNewAccountCustomer_Load(object sender, EventArgs e)
        {

        }
        private bool CheckInputEmail()
        {
            lblNotice.Text = ".."; 
            if (!CheckInput.IsValidEmail(txtEmail.Text))
            {
                error.SetError(txtEmail, "Email not valid");
                return false;
            }
            return true; 
        }
        private void btnSendOtp_Click(object sender, EventArgs e)
        {
            if (!CheckInputEmail()) return;
            //có thể có các bước check trước đó (check email đã tồn tại !) để tạo tài khoản 
            //              cũng có thể check email chưa tồn tại, khi quên mật khẩu
            //     
            bool checkEmail = Account_BUL.CheckEmail(txtEmail.Text.Trim());
            if (isCreateAccount)
            {
                if (checkEmail == true)
                {
                    lblNotice.Text = "This email already exists in the system, please choose another email !";
                    txtEmail.Text = "";
                    return;
                }
            }
            else if (isForgetPassword)
            {
                if (checkEmail == false)
                {
                    lblNotice.Text = "This email does not exist in the system, please choose another email";
                    txtEmail.Text = "";
                    return;
                }
            }
            //
            if (Account_BUL.SendCodeConfirm(txtEmail.Text))
            {
                lblNotice.Text = "OTP code has been sent successfully, please check your email to continue !";
                btnContinue.Enabled = true;
            }
            else
            {
                lblNotice.Text = "(system error) otp code has not been sent, please try again!";
                btnContinue.Enabled = false;
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (Account_BUL.ConFirmCode(txtCodeOtp.Text) == true)
            {
                if (isCreateAccount)
                {
                    new frmCreateNewAccountCustomer(txtEmail.Text).ShowDialog();
                    this.Close();
                }
                else if (isForgetPassword)
                {
                    new frmChangePassword(txtEmail.Text).ShowDialog();
                    this.Close();
                }
            }
            else lblNotice.Text = "otp code is not correct, please try again!";
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
        private void picExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
