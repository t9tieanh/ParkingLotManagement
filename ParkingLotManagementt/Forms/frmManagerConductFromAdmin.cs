using BUL;
using DocumentFormat.OpenXml.ExtendedProperties;
using DTO;
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
    public partial class frmManagerConductFromAdmin : Form
    {
        private Manager_DTO myManager; // người đang sử dụng form này 
        public void LoadDentailManager (Manager_DTO myManager)
        {
            if (this.myManager.ManagerId == myManager.ManagerId)
                btnDeleteManager.Enabled = false;
            else if (btnAddAdmin.Enabled == false)
                btnDeleteManager.Enabled = true;
            txtPassword.Enabled = false;
            try
            {
                picAvatarManager.Image = myManager.Picture != null ? Image.FromStream(myManager.Picture) : Resource1.istockphoto_588348500_1024x1024;
            }
            catch { }
            txtIDManager.Text = myManager.ManagerId;
            txtFullNameManager.Text = myManager.FullName;
            txtPhoneManager.Text = myManager.Phone;
            if (myManager.ParkArea != null)
                cbGetParkingArea.Text = myManager.ParkArea.Address;
            else
                cbGetParkingArea.Text = "All";
            //
            txtUsername.Text = myManager.Account.UserName;
            txtEmail.Text = myManager.Account.Email;
            txtPassword.Text = "";
        }
        private void LoadParkArea ()
        {
            var parkAreaLst = BUL.ParkArea_BUL.GetParkArea();
            parkAreaLst.Add(new ParkArea_DTO("", "All"));
            cbGetParkingArea.DataSource = parkAreaLst;
            cbGetParkingArea.DisplayMember = "Address";
        }
        private void LoadManager ()
        {
            var managerLst = BUL.Manager_BUL.GetManager();
            flowPnManager.Controls.Clear();
            foreach (var manager in managerLst)
            {
                flowPnManager.Controls.Add (new UC_Controls.UC_Manager(manager,this));
            }
        }
        public frmManagerConductFromAdmin(Manager_DTO myManager)
        {
            InitializeComponent();
            LoadManager();
            LoadParkArea();
            this.myManager = myManager;
        }

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
            this.Close();
        }
        private void ResetControl ()
        {
            picAvatarManager.Image = Resource1.istockphoto_588348500_1024x1024;
            txtIDManager.Text = "";
            txtFullNameManager.Text = "";
            txtPhoneManager.Text = "";
            //
            /*cbGetParkingArea.DataSource = null;
            cbGetParkingArea.Items.Clear();*/
            //
            txtUsername.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
        }

        private void ToggleSwitchParkArea_CheckedChanged(object sender, EventArgs e)
        {
            ResetControl();
            if (ToggleSwitchParkArea.Checked)
            {
                // khi ở mode thêm manager
                txtIDManager.ReadOnly = false;
                txtUsername.ReadOnly = false;
                txtPassword.Enabled = true;
                txtEmail.ReadOnly = false;
            }
            else
            {
                txtIDManager.ReadOnly = true ;
                txtPassword.Enabled = false;
                txtEmail.ReadOnly = true ;
                txtUsername.ReadOnly = true ;
            }
            btnAddAdmin.Enabled = !btnAddAdmin.Enabled;
            btnDeleteManager.Enabled = !btnAddAdmin.Enabled;
            btnUpdateManager.Enabled = !btnAddAdmin.Enabled;
        }

        private void lblChangeAva_Click(object sender, EventArgs e)
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
                picAvatarManager.ImageLocation = filePath;
            }
        }
        private bool CheckInput ()
        {
            error.Clear();
            bool wasError = true;
            if (!InputCheck.CheckInput.IsInteger(txtIDManager.Text))
            {
                wasError = false;
                error.SetError(txtIDManager, "Id Not valid !");
            }
            if (!InputCheck.CheckInput.Name(txtFullNameManager.Text))
            {
                wasError = false;
                error.SetError(txtFullNameManager, "full name not valid");
            }
            if (!InputCheck.CheckInput.IsValidPhoneNumber(txtPhoneManager.Text))
            {
                wasError = false;
                error.SetError(txtPhoneManager,"Phone Number not valid");
            }
            if (!InputCheck.CheckInput.IsValidUsername(txtUsername.Text))
            {
                wasError = false;
                error.SetError(txtUsername, "UserName not valid");
            }
            if (!InputCheck.CheckInput.IsValidEmail(txtEmail.Text) ){
                wasError = false;
                error.SetError(txtEmail, "Email not valid");
            }
            return wasError;
        }
        private Manager_DTO GetManager ()
        {
            MemoryStream picManager = new MemoryStream();
            picAvatarManager.Image.Save(picManager, picAvatarManager.Image.RawFormat);
            var account = new Account_DTO(txtUsername.Text, txtEmail.Text, txtPassword.Text, txtIDManager.Text, "Manager");
            ParkArea_DTO myParkArea =(ParkArea_DTO)cbGetParkingArea.SelectedItem;
            if (myParkArea.ParkAreaId != "")
                return new Manager_DTO(txtIDManager.Text, txtFullNameManager.Text,picManager, txtPhoneManager.Text, true, account, myParkArea);
            else
                return new Manager_DTO(txtIDManager.Text, txtFullNameManager.Text, picManager, txtPhoneManager.Text, true, account, null);
        }
        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;
            Manager_DTO manager = GetManager();
            if (Manager_BUL.InsertManager(manager))
            {
                lblNotice.Text = "Add " + manager + " successfully!";
                LoadManager();
            }
            else
            {
                lblNotice.Text = $"(system error) Unable to add employee {manager}, please try again";
            }
        }

        private void btnUpdateManager_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;
            Manager_DTO manager = GetManager();
            if (Manager_BUL.UpdateManager(manager))
            {
                lblNotice.Text = "Update " + manager + " successfully!";
                LoadManager() ;
            }
            else
            {
                lblNotice.Text = $"(system error) Unable to update {manager}, please try again";
            }
        }

        private void btnDeleteManager_Click(object sender, EventArgs e)
        {
            Manager_DTO manager = GetManager();
            if (Manager_BUL.DeleteManager(manager))
            {
                lblNotice.Text = "Delete " + manager + " successfully!";
                ResetControl();
                LoadManager();
            }
            else
            {
                lblNotice.Text = $"(system error) Unable to delete {manager}, please try again";
            }
        }
    }
}
