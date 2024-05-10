using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace ParkingLotManagementt.Forms
{
    public partial class frmProfileWorker : Form
    {
        #region 
        private Worker_DTO myWorker;
        private bool checkInput ()
        {
            error.Clear ();
            bool waserror = true;
            if (!InputCheck.CheckInput.Name(txtFullNameWorker.Text))
            {
                waserror = false;
                error.SetError(txtFullNameWorker, "Full name not valid");
            }
            if (!InputCheck.CheckInput.AddressIsValid (txtAddressWorker.Text)) 
            {
                waserror = false;
                error.SetError(txtAddressWorker, "address not valid");
            }
            if (!InputCheck.CheckInput.IsInteger(txtIDWorker.Text))
            {
                waserror = false;
                error.SetError(txtIDWorker, "Id worker not valid!");
            }
            if (!InputCheck.CheckInput.IsValidUsername(txtUsername.Text))
            {
                waserror = false;
                error.SetError(txtUsername, "UserName not valid");
            }
            return waserror;    
        }
        public Worker_DTO MyWorker { get => myWorker; set => myWorker = value; }
        private void LoadcbGetParkingArea()
        {
            var parkAreaLst = BUL.ParkArea_BUL.GetParkArea();
            cbGetParkingArea.DataSource = parkAreaLst;
            cbGetParkingArea.DisplayMember = "Address";
        }

        public frmProfileWorker(Worker_DTO myWorker)
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            MyWorker = myWorker;

            txtIDWorker.Enabled = true;
            btnInsert.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            pnPassWord.Visible = false;

            LoadcbGetParkingArea();
            SetWorker();
        }
        public frmProfileWorker()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            btnInsert.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;

            LoadcbGetParkingArea();
        }
        public frmProfileWorker(ParkArea_DTO myParkArea)
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            btnInsert.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;

            //LoadcbGetParkingArea();
            cbGetParkingArea.DataSource = new List<ParkArea_DTO> { myParkArea }; //myParkArea;
            cbGetParkingArea.DisplayMember  = "Address";
        }
        /// <summary>
        /// set thông tin cho form worker 
        /// </summary>
        private void SetWorker ()
        {
            txtIDWorker.Text = MyWorker.WorkerId;
            txtFullNameWorker.Text = MyWorker.FullName;
            cbGetParkingArea.Text = MyWorker.ParkArea.Address;
            picAvatarCustomer.Image = MyWorker.Picture != null ? Image.FromStream(MyWorker.Picture) : picAvatarCustomer.Image;
            txtAddressWorker.Text = MyWorker.Address;
            txtUsername.Text = myWorker.Account.UserName;

            if (MyWorker.Type.Trim() == "Look")
                rbtnLookAfter.Checked = true;
            else if (MyWorker.Type.Trim() == "maintenance") 
                rbtnRepair.Checked = true;
            else 
                rbtnWashing.Checked = true;
        }
        private void GetWorker ()
        {
            string typeWorker ;
            if (rbtnLookAfter.Checked) typeWorker = rbtnLookAfter.Text;
            else if (rbtnRepair.Checked) typeWorker = rbtnRepair.Text;
            else typeWorker = rbtnWashing.Text;

            MemoryStream picWorker = new MemoryStream();
            picAvatarCustomer.Image.Save(picWorker, picAvatarCustomer.Image.RawFormat);

            Account_DTO myAccount;
            if (pnPassWord.Visible)
                // đang ở trong trạng thái add 
                myAccount = new Account_DTO(txtUsername.Text,"",txtPassword.Text,txtIDWorker.Text,"Worker");
            else
                myAccount = MyWorker.Account;

            MyWorker = new Worker_DTO(txtIDWorker.Text, txtFullNameWorker.Text, txtAddressWorker.Text, picWorker, typeWorker,(ParkArea_DTO)cbGetParkingArea.SelectedValue,true,myAccount);
        }

        #region Code cho phần thêm worker
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!checkInput())  return;
            GetWorker();
            if (Worker_BUL.InsertWorker(myWorker))
                lblNotice.Text = "Insert " + myWorker.ToString() + " successfully!";
            else
                lblNotice.Text = "Insert " + myWorker.ToString() + " failed!";
        }
        #endregion 


        private void picChange_Click(object sender, EventArgs e)
        {
            GetWorker();
            if (Worker_BUL.UpdateWorker(myWorker))
                lblNotice.Text = "Update " + myWorker.ToString() + " successfully!";
            else
                lblNotice.Text = "Update " + myWorker.ToString() + " failed!";
        }

        #endregion
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void pnTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
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

        private void frmProfileWorker_Load(object sender, EventArgs e)
        {

        }

        private void picExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        private void txtIDWorker_TextChanged(object sender, EventArgs e)
        {
            txtUsername.Text = "Worker" + txtIDWorker.Text;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            GetWorker();
            DialogResult result = MessageBox.Show("Xác nhận xóa " + myWorker.ToString() + " ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;
            if (BUL.Worker_BUL.DeleteWorker(myWorker))
            {
                MessageBox.Show("Delete" + txtIDWorker.Text + " successfully!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                lblNotice.Text = "Delete " + txtIDWorker.Text + " failed! ";
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
                picAvatarCustomer.ImageLocation = filePath;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!checkInput()) return;
            GetWorker();
            if (Worker_BUL.UpdateWorker(myWorker))
                lblNotice.Text = "Update " + myWorker.ToString() + " successfully!";
            else
                lblNotice.Text = "Update " + myWorker.ToString() + " failed!";
        }
    }
}