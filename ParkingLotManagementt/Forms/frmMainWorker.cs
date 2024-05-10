using DTO;
using Guna.UI2.WinForms;
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
    public partial class frmMainWorker : Form
    {
        private Worker_DTO myWorker;
        private ContractDetail_DTO contractDetailSelected;
        private void SetMyWorker ()
        {
            lblWorkerID.Text = myWorker.WorkerId;
            txtNameWorker.Text = myWorker.FullName;
            picAvatarOfWorker.Image = (myWorker.Picture != null) ? Image.FromStream(myWorker.Picture) : picAvatarOfWorker.Image;
            //infor 
            picAvartarCustomer.Image = (myWorker.Picture != null) ? Image.FromStream(myWorker.Picture) : picAvartarCustomer.Image;
            txtIDWorker.Text = myWorker.WorkerId;
            txtCustomerFullName.Text = myWorker.FullName;
            txtParAreaCustomer.Text = myWorker.ParkArea.Address;
            txtTypeWorker.Text = myWorker.Type;
            txtAddressWorker.Text = myWorker.Address;
            if (myWorker.Account != null)
            {
                txtUserName.Text = myWorker.Account.UserName;
                txtGmail.Text = myWorker.Account.Email;
            }
        }
        private void LoadContractDetail (int status)
        {
            flowContractDetail.Controls.Clear();
            List<ContractDetail_DTO> myContractDetail = BUL.ContractDetail_BUL.GetContractDetail(myWorker,status);
            foreach (var contractDetail in myContractDetail)
            {
                flowContractDetail.Controls.Add (new UC_Controls.UC_ContractDetailFromWorker(contractDetail,this));
            }
        }
        /// <summary>
        /// load Data ContractDetail lên panel pnDetailContractDetail
        /// </summary>
        public void LoadDataContractDetail (ContractDetail_DTO contractDetail)
        {
            btnRecept.Enabled = rdUnfinishedWork.Checked;
            //
            pnDetailContractDetail.Enabled = true;
            contractDetailSelected = contractDetail;
            lblContractDetailID.Text = contractDetail.ContractDetailId;
            txtReceiptDate.Text = contractDetailSelected.Contract.ReceiptDate.ToString("yyyy-MM-dd");
            txtDeadline.Text = contractDetailSelected.Contract.DeliveryDate.ToString("yyyy-MM-dd");
            // customer 
            txtCustomerName.Text = contractDetailSelected.Contract.Customer.FullName;
            txtPhone.Text = contractDetail.Contract.Customer.Phone;
            try
            {
                picCustomer.Image = (contractDetail.Contract.Customer.Picture == null) ? picAvatarOfWorker.Image : Image.FromStream(contractDetail.Contract.Customer.Picture);
            }
            catch { }
            //vehicle 
            txtIdVehicle.Text = contractDetail.Contract.MyVehical.VehicalId;
            txtModelVehicle.Text = contractDetail.Contract.MyVehical.Model;
            txtTypeVehicle.Text = contractDetail.Contract.MyVehical.Type;
            try
            {
                picAvatarCar.Image = (contractDetail.Contract.MyVehical.Picture == null) ? picAvatarCar.Image : Image.FromStream(contractDetail.Contract.MyVehical.Picture);
            }
            catch { }
            //service 
            txtIDService.Text = contractDetail.Service.ServiceId;
            txtNameService.Text = contractDetail.Service.NameService;
            lblPrice.Text = contractDetail.Service.Price.ToString();
            txtDescriptionService.Text = contractDetail.Service.Description;

            if (contractDetailSelected.Contract.DeliveryDate.Date < DateTime.Now.Date && rdUnfinishedWork.Checked)
            {
                lblNoticeContractDetail.Text = "Completion of work could not be confirmed due to deadline exceeded";
                btnRecept.Enabled = false;  
            }
        }
        public frmMainWorker()
        {
            InitializeComponent();
            ChangeButton(btnDashboard, btnSetting);
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        public frmMainWorker(Worker_DTO myWorker)
        {
            InitializeComponent();
            ChangeButton(btnDashboard, btnSetting);
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.myWorker = myWorker;
            SetMyWorker();
            rdUnfinishedWork.Checked = true;
        }

        #region code giao diện 
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

        // Hàm thay đổi giao diện nút khi click
        private void ChangeButton(Guna2Button btnChoose, Guna2Button btnNotOne)
        {
            btnNotOne.ForeColor = Color.FromArgb(9, 132, 227);
            btnNotOne.FillColor = Color.White;

            btnChoose.ForeColor = Color.White;
            btnChoose.FillColor = Color.FromArgb(9, 132, 227);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ChangeButton(btnDashboard, btnSetting);

            pnDashboard.Show();
            pnSetting.Hide();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            ChangeButton(btnSetting, btnDashboard);

            pnDashboard.Hide();
            pnSetting.Show();
        }
        #endregion



        private void btnRecept_Click(object sender, EventArgs e)
        {
            contractDetailSelected.Status = 1;
            if (BUL.ContractDetail_BUL.UpdateContractDetailStatus(contractDetailSelected))
            {
                pnDetailContractDetail.Enabled = false;
                contractDetailSelected = null;
                rdFinishedWork.Checked = true;
            }
            else lblNotice.Text = "(system error) The completion of this job could not be verified!";
        }

        private void rdFinishedWork_CheckedChanged(object sender, EventArgs e)
        {
            LoadContractDetail(1);
        }

        private void rdUnfinishedWork_CheckedChanged(object sender, EventArgs e)
        {
            LoadContractDetail(0);
        }

        private void pnDashboard_Paint(object sender, PaintEventArgs e)
        {

        }
        // save lưu thông tin 
        #region code cho phần chỉnh sửa thông tin
        private bool CheckInput ()
        {
            bool wasError = true;
            if (!InputCheck.CheckInput.Name(txtCustomerFullName.Text))
            {
                wasError = false;
                error.SetError(txtCustomerFullName, "Full name not valid!");
            }
            if (!InputCheck.CheckInput.AddressIsValid(txtAddressWorker.Text) ){
                wasError = false;
                error.SetError(txtAddressWorker, "Address not valid !");
            }
            return wasError;
        }
        private void GetCustomer ()
        {
            myWorker.FullName = txtCustomerName.Text;
            myWorker.Address = txtAddressWorker.Text;
            MemoryStream picWorker = new MemoryStream();
            picAvartarCustomer.Image.Save(picWorker, picAvartarCustomer.Image.RawFormat);
            myWorker.Picture = picWorker;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;
            GetCustomer();
            if (BUL.Worker_BUL.UpdateWorker(myWorker))
            {
                lblNoticeInfo.Text = "Edited information successfully!";
                SetMyWorker();
            }
            else
            {
                lblNoticeInfo.Text = "(system error) failed to edit information";
            }
        }

        private void lblChangeImage_Click(object sender, EventArgs e)
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
                picAvartarCustomer.ImageLocation = filePath;
            }
        }
        #endregion 
    }
}
