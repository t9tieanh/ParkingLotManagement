using BUL;
using DTO;
using ParkingLotManagementt.UC_Controls;
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
    public partial class frmViewDetailParkAreaForAdmin : Form
    {
        private ParkArea_DTO myParkArea; 
        private Manager_DTO myManager;
        private void LoadData ()
        {
            LoadWorker();
            LoadContract();
            LoadParking();
            StaticParking ();
        }
        private void SetManager()
        {
            lblNameManager.Text = myManager.FullName;
            txtFullNameManager.Text = myManager.FullName;
            txtPhoneManager.Text = myManager.Phone;
            PicManager.Image = myManager.Picture == null ? PicManager.Image : Image.FromStream(myManager.Picture);
            picAvatarManager.Image = myManager.Picture == null ? picAvatarManager.Image : Image.FromStream(myManager.Picture);
            lblUserNameManager.Text = myManager.Account.UserName;
        }
        public frmViewDetailParkAreaForAdmin(Manager_DTO myManager)
        {
            InitializeComponent();
            this.myManager = myManager;
            this.myParkArea = myManager.ParkArea;
            lblAddressParkArea.Text = myParkArea.Address;
            LoadData();
            SetManager();
        }
        public frmViewDetailParkAreaForAdmin(Manager_DTO myManager, ParkArea_DTO myParkArea)
        {
            InitializeComponent();
            this.myManager = myManager;
            this.myParkArea = myParkArea;
            lblAddressParkArea.Text = myParkArea.Address;
            LoadData();
            SetManager();
        }
        #region code giao diện 
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
        #endregion
        #region code cho Worker
        private void LoadWorker ()
        {
            var workerLookLst = BUL.Worker_BUL.GetWorker("Look", myParkArea.ParkAreaId);
            var workerMaintancenLst = BUL.Worker_BUL.GetWorker ("maintenance", myParkArea.ParkAreaId);
            var workerWashLst = BUL.Worker_BUL.GetWorker("Wash", myParkArea.ParkAreaId);
            //
            lblTotalMaintenance.Text = "Maintenance: " + workerMaintancenLst.Count;
            lblTotalLook.Text = "Look: " + workerLookLst.Count;
            lblTotalWash.Text = "Wash: " + workerWashLst.Count;
            //
            int totalWorker = workerLookLst.Count + workerMaintancenLst.Count + workerWashLst.Count;
            lblTotalWorker.Text = totalWorker.ToString();
            if (totalWorker!= 0)
            {
                processWashing.Value = (int)((workerWashLst.Count * 100.0) / totalWorker*1.0);
                processRepair.Value = (int)((workerMaintancenLst.Count * 100.0) / totalWorker * 1.0);
                processLook.Value = 100 - processWashing.Value - processWashing.Value;
            }
            //
            flowWorkerLst.Controls.Clear();
            foreach (var worker in workerLookLst)
                flowWorkerLst.Controls.Add(new UC_Controls.UC_WorkerForAdmin(worker));
            foreach (var worker in workerMaintancenLst)
                flowWorkerLst.Controls.Add(new UC_Controls.UC_WorkerForAdmin(worker));
            foreach (var worker in workerWashLst)
                flowWorkerLst.Controls.Add(new UC_Controls.UC_WorkerForAdmin(worker));
        }
        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            if (cbSearchWorker.Text == "All")
            {
                LoadWorker();
                return;
            }
            var workerLst = BUL.Worker_BUL.SearchWorker(cbSearchWorker.Text,txtSearchCustomer.Text);
            flowWorkerLst.Controls.Clear();
            foreach (var worker in workerLst)
                flowWorkerLst.Controls.Add(new UC_Controls.UC_WorkerForAdmin(worker));
        }
        private void btnAddWorker_Click(object sender, EventArgs e)
        {
            frmProfileWorker frmProfileWorker = new frmProfileWorker(myParkArea);
            frmProfileWorker.ShowDialog();
            LoadWorker();
        }
        #endregion
        #region code cho phần contract 
        public void LoadContract()
        {
            try
            {
                flowContractUC.Controls.Clear();
                flowMessage.Controls.Clear();
                var myListContractCompleted = Contract_BUL.GetContract(myParkArea,3);
                var myListContractUnpaid = Contract_BUL.GetContract(myParkArea,2);
                var myListContractMaking = Contract_BUL.GetContract(myParkArea, 1);
                var myListContractUncomfimred = Contract_BUL.GetContract(myParkArea,0);
                foreach (var contractUncomfimred in myListContractUncomfimred)
                {
                    flowMessage.Controls.Add(new UC_MessageForAdmin(contractUncomfimred,this));
                }
                foreach (var contract in myListContractUnpaid)
                    flowContractUC.Controls.Add(new UC_ContractForAdmin(contract));
                foreach (var contract in myListContractMaking)
                    flowContractUC.Controls.Add(new UC_ContractForAdmin(contract));
                foreach (var contract in myListContractCompleted)
                    flowContractUC.Controls.Add(new UC_ContractForAdmin(contract));
                //
                lblNumberComplated.Text = myListContractCompleted.Count.ToString();
                lblNumberUnpaid.Text = myListContractUnpaid.Count.ToString();
                lblNumberMaking.Text = myListContractMaking.Count.ToString();
                lblNumberUncomfimred.Text = myListContractUncomfimred.Count.ToString();
            }
            catch
            {
                MessageBox.Show("Có lỗi khi lấy dữ liệu !", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadContract(int status)
        {
            try
            {
                flowContractUC.Controls.Clear();
                var contractLst = BUL.Contract_BUL.GetContract(myParkArea,status);
                foreach (var contract in contractLst)
                    flowContractUC.Controls.Add(new UC_ContractForAdmin(contract));
            }
            catch
            {
                MessageBox.Show("Có lỗi khi lấy dữ liệu !", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbContract.SelectedIndex == 0)
            {
                LoadContract();
                return;
            }
            LoadContract(cbContract.SelectedIndex);
        }
        #endregion
        #region code cho Parking 
        private void LoadParking ()
        {
            var ParkingLst = Parking_BUL.GetParkingForAdmin (myParkArea);
            flowContractUC.Controls.Clear();
            foreach (var parking in ParkingLst)
            {
                flowParkingLst.Controls.Add(new UC_Controls.UC_ParkingForAdmin(parking));
            }
            lblTotalParking.Text = ParkingLst.Count + "/" + myParkArea.Capacity;
        }
        private void dtpkTimeParking_ValueChanged(object sender, EventArgs e)
        {
            LoadParking();
        }
        private Fee_DTO myFee = BUL.Fee_BUL.GetFee(); // đối tượng dùng để tính tiền  ;
        private void StaticParking ()
        {
            var parkingLst = Parking_BUL.GetParkingCheckInForAdmin (myParkArea, DateTime.Now);
            lblTotalNumberCarEnter.Text = parkingLst.Count.ToString();
            // tính doanh thu 
            double renuve = 0;
            foreach (var parking in parkingLst) {
                if (parking.CheckOut != DateTime.MinValue) {
                    TimeSpan duration = parking.CheckOut - parking.CheckIn;
                    renuve += myFee.FeeCalculation((int)duration.TotalHours, parking.ParkArea.Type);
                }
            }
            lblTotalRevenue.Text = renuve + " $";
        }
        private void btnViewVehicleEntryAndExitHistory_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmViewVehicleEntryAndExitHistory(myParkArea).ShowDialog();//.ShowDialog;
            this.Show();
        }
        #endregion

        private void btnWorkerTypeLook_Click(object sender, EventArgs e)
        {

        }

        private void picExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool tick;
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (tick) pbxNotice.Image = Resource1.ogs_parking_lots_221;
            else
                pbxNotice.Image = Resource1._1695288013_untitled_design_min;
            tick = !tick;
        }
        #region code cho phần update manager 
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
            if (!InputCheck.CheckInput.Name(txtFullNameManager.Text)){
                wasError = false;
                error.SetError(txtFullNameManager, "full name not valid");
            }
            if (!InputCheck.CheckInput.IsValidPhoneNumber(txtPhoneManager.Text))
            {
                wasError = false;
                error.SetError(txtPhoneManager, "Phone number not valid !");
            }
            return wasError;
        }
        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;

            MemoryStream picManager = new MemoryStream();
            picAvatarManager.Image.Save(picManager, picAvatarManager.Image.RawFormat);
            myManager.FullName = txtFullNameManager.Text;
            myManager.Phone = txtPhoneManager.Text;
            myManager.Picture = picManager;
            if (Manager_BUL.UpdateManager(myManager))
            {
                lblNotice.Text = $"Updated {myManager} successfully";
                SetManager();
            }
            else
            {
                lblNotice.Text = "Update faild";
            }
        }
        
        #endregion
    }
}
