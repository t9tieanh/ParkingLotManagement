using BUL;
using DocumentFormat.OpenXml.Vml;
using DTO;
using MiniExcelLibs.OpenXml;
using MiniSoftware;
using ParkingLotManagementt.UC_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingLotManagementt.Forms
{
    public partial class frmMain : Form
    {
        public Manager_DTO manager;
        public void LoadData ()
        {
            LoadWorker();
            LoadContract();
            LoadParkArea();
            LoadService();
            LoadCustomer();
        }
        private void SetManager ()
        {
            txtUsername.Text = manager.Account.UserName;
            txtEmail.Text = manager.Account.Email;
            picAvatarAdmin.Image = (manager.Picture == null) ? picAvatarAdmin.Image : Image.FromStream(manager.Picture);
            txtIDAdmin.Text = manager.ManagerId;
            txtFullNameAdmin.Text = manager.FullName;
            txtPhoneAdmin.Text = manager.Phone;
        }
        public frmMain()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            // lấy dữ liệu từ database 
            LoadData();
        }
        public frmMain(Manager_DTO manager)
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            // lấy dữ liệu từ database 
            this.manager = manager;
            SetManager();
            LoadData();
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

        #region Click control

        private void picVehicle_Click(object sender, EventArgs e)
        {
            Setup.ChangeControl.ChangeLocationOfControl(pnCurrent, 122, 48);
            pnCurrent.Location = new Point(106, 34);
            pnVehicle.Show();
            pnWorker.Hide();
            pnContract.Hide();
            pnCustomer.Hide();
            pnSetting.Hide();
            pnPartArea.Hide();
        }

        private void picWorker_Click(object sender, EventArgs e)
        {
            Setup.ChangeControl.ChangeLocationOfControl(pnCurrent, 122, 179);
            pnCurrent.Location = new Point(106, 137);
            pnVehicle.Hide();
            pnWorker.Show();
            pnContract.Hide();
            pnCustomer.Hide();
            pnSetting.Hide();
            pnPartArea.Hide();
        }

        private void picCustomer_Click(object sender, EventArgs e)
        {
            Setup.ChangeControl.ChangeLocationOfControl(pnCurrent, 122, 310);
            pnCurrent.Location = new Point(109, 248);
            pnVehicle.Hide();
            pnWorker.Hide();
            pnContract.Hide();
            pnCustomer.Show();
            pnSetting.Hide();
            pnPartArea.Hide();
        }

        private void picContract_Click(object sender, EventArgs e)
        {
            Setup.ChangeControl.ChangeLocationOfControl(pnCurrent, 122, 441);
            pnCurrent.Location = new Point(106, 347);
            pnVehicle.Hide();
            pnWorker.Hide();
            pnContract.Show();
            pnCustomer.Hide();
            pnSetting.Hide();
            pnPartArea.Hide();
        }

        private void picArea_Click(object sender, EventArgs e)
        {
            Setup.ChangeControl.ChangeLocationOfControl(pnCurrent, 122, 572);
            pnCurrent.Location = new Point(109, 446);
            pnVehicle.Hide();
            pnWorker.Hide();
            pnContract.Hide();
            pnCustomer.Hide();
            pnSetting.Hide();
            pnPartArea.Show();
        }

        private void picSetting_Click(object sender, EventArgs e)
        {
            Setup.ChangeControl.ChangeLocationOfControl(pnCurrent, 122, 703);
            pnCurrent.Location = new Point (108, 556);
            pnVehicle.Hide();
            pnWorker.Hide();
            pnContract.Hide();
            pnCustomer.Hide();
            pnSetting.Show();
            pnPartArea.Hide();
        }

        #endregion

        private void picExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Start()
        {
            Setup.ChangeControl.ChangeLocationOfControl(pnCurrent, 120, 45);
            pnVehicle.Show();
            pnWorker.Hide();
            pnContract.Hide();
            pnCustomer.Hide();
            pnSetting.Hide();
            pnPartArea.Hide();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Start();
        }
        #endregion

        #region code cho phần worker 
        private List<Worker_DTO> workerLstSelected = new List<Worker_DTO>();
        private void LoadWorker()
        {
            var workerLookLst = BUL.Worker_BUL.GetWorkerWithType("Look");
            var workerMaintancenLst = BUL.Worker_BUL.GetWorkerWithType("maintenance");
            var workerWashLst = BUL.Worker_BUL.GetWorkerWithType("Wash");
            //
            lblTotalMaintenance.Text = "Maintenance: " + workerMaintancenLst.Count;
            lblTotalLook.Text = "Look: " + workerLookLst.Count;
            lblTotalWash.Text = "Wash: " + workerWashLst.Count; 
            //
            int totalWorker = workerLookLst.Count + workerMaintancenLst.Count + workerWashLst.Count;
            lblTotalWorker.Text = totalWorker.ToString();
            if (totalWorker != 0)
            {
                processWashing.Value = (int)((workerWashLst.Count * 100.0) / totalWorker * 1.0);
                processRepair.Value = (int)((workerMaintancenLst.Count * 100.0) / totalWorker * 1.0);
                processLook.Value = 100 - processWashing.Value - processWashing.Value;
            }
            //
            flowWorkerLst.Controls.Clear();
            workerLstSelected.Clear();
            foreach (var worker in workerLookLst)
            {
                flowWorkerLst.Controls.Add(new UC_Controls.UC_Worker(worker));
                workerLstSelected.Add(worker);
            }
            foreach (var worker in workerMaintancenLst)
            {
                flowWorkerLst.Controls.Add(new UC_Controls.UC_Worker(worker));
                workerLstSelected.Add(worker);
            }
            foreach (var worker in workerWashLst)
            {
                flowWorkerLst.Controls.Add(new UC_Controls.UC_Worker(worker));
                workerLstSelected.Add(worker);
            }
            // 
            cbParkAreaFromWorker.DataSource = ParkArea_BUL.GetParkArea();
            cbParkAreaFromWorker.DisplayMember = "Address";
        }
        private void btnAddWorker_Click(object sender, EventArgs e)
        {
            frmProfileWorker frmProfileWorker = new frmProfileWorker ();
            frmProfileWorker.ShowDialog();
            LoadWorker();
        }
        private void btnSearchWorker_Click(object sender, EventArgs e)
        {
            if (cbSearchWorker.Text == "All")
            {
                LoadWorker();
                return;
            }
            var workerLst = BUL.Worker_BUL.SearchWorker(cbSearchWorker.Text, txtSearchCustomer.Text);
            flowWorkerLst.Controls.Clear();
            workerLstSelected.Clear();
            foreach (var worker in workerLst)
            {
                flowWorkerLst.Controls.Add(new UC_Controls.UC_Worker(worker));
                workerLstSelected.Add(worker);
            }
        }
        private void cbParkAreaFromWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var workerLst = BUL.Worker_BUL.GetWorker((ParkArea_DTO)cbParkAreaFromWorker.SelectedItem);
            flowWorkerLst.Controls.Clear();
            workerLstSelected.Clear();
            foreach (var worker in workerLst)
            {
                flowWorkerLst.Controls.Add(new UC_Controls.UC_Worker(worker));
                workerLstSelected.Add(worker);
            }
        }
        public string PATH_TEMPLATE_Worker = Application.StartupPath + "\\Template\\WorkerTemplate.docx";
        public string PATH_EXPORT_Worker = Application.StartupPath + "\\export.docx";
        private void PrintWorker ()
        {
            try
            {
                var data = workerLstSelected.ToArray();
                var config = new OpenXmlConfiguration()
                {
                    IgnoreTemplateParameterMissing = false,
                };
                var value = new
                {
                    Worker = data,
                    PrintDay = DateTime.Now.ToString("yyyy-MM-dd"),
                };

                MiniWord.SaveAsByTemplate(PATH_EXPORT_Worker, PATH_TEMPLATE_Worker, value);

                Process.Start(PATH_EXPORT_Worker);
            }
            catch 
            {
                MessageBox.Show("export file is being accessed elsewhere", "Notice",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }   
        }
        private void lblPrint_Click(object sender, EventArgs e)
        {
            PrintWorker();
        }
        #endregion

        #region code cho phần ParkArea
        private ParkArea_DTO getParkArea ()
        {
            string type;
            if (rbtnBicycle.Checked) type = "Bicycle";
            else if (rbtnCar.Checked) type = "Car";
            else type = "Moto";

            return new ParkArea_DTO(txtIDParkArea.Text, txtAddressParkArea.Text
                , (int)numCapacity.Value, type);
        }
        private bool CheckInputParkArea ()
        {
            bool wasError = true;
            error.Clear();  
            if (!InputCheck.CheckInput.IsInteger(txtIDParkArea.Text))
            {
                error.SetError(txtIDParkArea , "Id ParkArea not valid!");
                wasError = false;
            }
            if (!InputCheck.CheckInput.Name(txtAddressParkArea.Text))
            {
                error.SetError(txtAddressParkArea,"Address not valid");
                wasError = false;
            }
            return wasError;
        }
        private void resetControlParkArea ()
        {
            txtIDParkArea.Text = "";
            txtAddressParkArea.Text = "";
            numCapacity.Value = 100;
            rbtnBicycle.Checked = true;
        }
        private void LoadParkArea ()
        {
            try
            {
                dgvListParkArea.DataSource = BUL.ParkArea_BUL.GetParkArea();
                flowChoosePark.Controls.Clear();
            }
            catch
            {
                MessageBox.Show("Có lỗi khi lấy dữ liệu !", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ToggleSwitchParkArea.Checked = false;
        }

        private void dgvListParkArea_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            flowChoosePark.Controls.Clear();
            string parkAreaId = dgvListParkArea.Rows[dgvListParkArea.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim();
            ParkArea_DTO myParkArea = ParkArea_BUL.GetParkArea (parkAreaId,true);
            flowChoosePark.Controls.Add(new UC_ParkAreaForAdmin(myParkArea,this));
            //
            txtIDParkArea.Text = myParkArea.ParkAreaId;
            txtAddressParkArea.Text =myParkArea.Address;
            numCapacity.Value = myParkArea.Capacity;
            if (myParkArea.Type == "Bicycle") rbtnBicycle.Checked = true;
            else if (myParkArea.Type == "Moto") rbtnMotobike.Checked = true;
            else rbtnCar.Checked = true;
        }

        private void ToggleSwitchParkArea_CheckedChanged(object sender, EventArgs e)
        {
            btnAddParkArea.Enabled = ToggleSwitchParkArea.Checked;
            btnDeleteParkArea.Enabled = !ToggleSwitchParkArea.Checked;
            btnChangeParkArea.Enabled = !ToggleSwitchParkArea.Checked;
            txtIDParkArea.Enabled = ToggleSwitchParkArea.Checked;
            txtAddressParkArea.Enabled = ToggleSwitchParkArea.Checked;
            pnTypeWorker.Enabled = ToggleSwitchParkArea.Checked;
            // set lại các control 
            resetControlParkArea();
        }

        private void btnDeleteParkArea_Click(object sender, EventArgs e)
        {
            lblNoticeParkArea.Text = "";
            if (!CheckInputParkArea()) return;
            if (BUL.ParkArea_BUL.DeleteParkArea(txtIDParkArea.Text.Trim())) {
                lblNoticeParkArea.Text = "Delete parking successfully!";
                resetControlParkArea();
                LoadParkArea();
            }
            else lblNoticeParkArea.Text = "This parking lot has a contract with the customer and cannot be deleted!";
        }

        private void btnAddParkArea_Click(object sender, EventArgs e)
        {
            lblNoticeParkArea.Text = "";
            if (!CheckInputParkArea()) return;
            if (!BUL.ParkArea_BUL.checkAddress(txtAddressParkArea.Text.Trim()))
            {
                lblNoticeParkArea.Text = "The parking address already exists, please choose another address!";
                return;
            }
            ParkArea_DTO newParkArea = getParkArea();
            if (BUL.ParkArea_BUL.InsertParkArea(newParkArea))
            {
                lblNoticeParkArea.Text = "added parking successfully!";
                resetControlParkArea ();
                LoadParkArea();
            }
            else lblNoticeParkArea.Text = "added parking failed!";
        }

        private void btnChangeParkArea_Click(object sender, EventArgs e)
        {
            lblNoticeParkArea.Text = "";
            if (!CheckInputParkArea()) return;
            ParkArea_DTO newParkArea = getParkArea();
            if (BUL.ParkArea_BUL.UpdateParkArea(newParkArea))
            {
                lblNoticeParkArea.Text = "update parking successfully!";
                resetControlParkArea();
                LoadParkArea();
            }
            else lblNoticeParkArea.Text = "update parking failed!";
        }
        private void btnManagementAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmManagerConductFromAdmin(manager).ShowDialog();
            this.Show();
        }
        private void btnChangePriceParking_Click(object sender, EventArgs e)
        {
            new frmChangePriceParking().ShowDialog();
        }
        #endregion
        #region code cho phần Contract
        public void LoadContract()
        {
            try
            {
                flowContractUC.Controls.Clear();
                flowMessage.Controls.Clear();
                var myListContractCompleted = Contract_BUL.GetContract(3);
                var myListContractUnpaid = Contract_BUL.GetContract(2);
                var myListContractMaking = Contract_BUL.GetContract(1);
                var myListContractUncomfimred = Contract_BUL.GetContract(0);
                foreach (var contractUncomfimred in myListContractUncomfimred)
                {
                    flowMessage.Controls.Add(new UC_MessageForAdmin(contractUncomfimred, this));
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
                var contractLst = BUL.Contract_BUL.GetContract(status);
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
        private void btnVewDentailContract_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmViewContractParkArea ().ShowDialog();
            this.Show();
        }
        private void btnViewStaticContract_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmStaticContract().ShowDialog();
            this.Show();
        }
        #endregion
        #region code cho phần service
        private List<Service_DTO> myServiceSelected = new List<Service_DTO> (); 
        public void LoadService ()
        {
            flowRental.Controls.Clear();
            flowMaintenance.Controls.Clear();
            flowWashing.Controls.Clear();   
            flowBorrow.Controls.Clear();
            myServiceSelected.Clear();
            List<Service_DTO> servicesRent = BUL.Service_BUL.GetServicesByType("rent");
            foreach (Service_DTO service in servicesRent)
            {
                flowRental.Controls.Add(new UC_Controls.UC_ServiceForAdmin(service, this));
                myServiceSelected.Add(service);
            }
            List<Service_DTO> serviceWash = BUL.Service_BUL.GetServicesByType("wash");
            foreach (Service_DTO service in serviceWash)
            {
                flowWashing.Controls.Add(new UC_Controls.UC_ServiceForAdmin(service, this));
                myServiceSelected.Add(service);
            }
            List<Service_DTO> serviceMaintenance = BUL.Service_BUL.GetServicesByType("maintenance");
            foreach (Service_DTO service in serviceMaintenance) {
                myServiceSelected.Add(service);
                flowMaintenance.Controls.Add(new UC_Controls.UC_ServiceForAdmin(service, this));
            }
            List<Service_DTO> serviceBorrow = BUL.Service_BUL.GetServicesByType("borrow");
            foreach (Service_DTO service in serviceBorrow) {
                flowBorrow.Controls.Add(new UC_Controls.UC_ServiceForAdmin(service, this));
                myServiceSelected.Add(service);
            }
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            new frmServiceDetail().ShowDialog();
            LoadService();
        }
        private void cbTypeVehicleService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTypeVehicleService.SelectedIndex == 0)
            {
                LoadService();
                return;
            }
            flowRental.Controls.Clear();
            flowMaintenance.Controls.Clear();
            flowWashing.Controls.Clear();
            flowBorrow.Controls.Clear();
            myServiceSelected.Clear();
            List<Service_DTO> servicesRent = BUL.Service_BUL.GetService(cbTypeVehicleService.Text,"rent");
            foreach (Service_DTO service in servicesRent)
            {
                flowRental.Controls.Add(new UC_Controls.UC_ServiceForAdmin(service, this));
                myServiceSelected.Add(service);
            }
            List<Service_DTO> serviceWash = BUL.Service_BUL.GetService(cbTypeVehicleService.Text,"wash");
            foreach (Service_DTO service in serviceWash)
            {
                flowWashing.Controls.Add(new UC_Controls.UC_ServiceForAdmin(service, this));
                myServiceSelected.Add(service);
            }
            List<Service_DTO> serviceMaintenance = BUL.Service_BUL.GetService(cbTypeVehicleService.Text, "maintenance");
            foreach (Service_DTO service in serviceMaintenance)
            {
                flowMaintenance.Controls.Add(new UC_Controls.UC_ServiceForAdmin(service, this));
                myServiceSelected.Add(service);
            }
            List<Service_DTO> serviceBorrow = BUL.Service_BUL.GetService(cbTypeVehicleService.Text, "borrow");
            foreach (Service_DTO service in serviceBorrow)
            {
                flowBorrow.Controls.Add(new UC_Controls.UC_ServiceForAdmin(service, this));
                myServiceSelected.Add(service);
            }
        }
        public string PATH_TEMPLATE_Service = Application.StartupPath + "\\Template\\ServiceTemplate.docx";
        public string PATH_EXPORT_Service = Application.StartupPath + "\\export.docx";
        private void PrintService()
        {
            try
            {
                var data = myServiceSelected.ToArray();
                var config = new OpenXmlConfiguration()
                {
                    IgnoreTemplateParameterMissing = false,
                };
                var value = new
                {
                    Service = data,
                    PrintDay = DateTime.Now.ToString("yyyy-MM-dd"),
                };

                MiniWord.SaveAsByTemplate(PATH_EXPORT_Service, PATH_TEMPLATE_Service, value);

                Process.Start(PATH_EXPORT_Service);
            }
            catch
            {
                MessageBox.Show("export file is being accessed elsewhere", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnPrintService_Click(object sender, EventArgs e)
        {
            PrintService();
        }
        #endregion code cho phần service
        #region code cho phần customer
        // code cho phần customer 
        private void LoadCustomer ()
        {
            flowCustomerList.Controls.Clear();
            var customerLst = Customer_BUL.GetCustomer();
            lblTotalCustomer.Text = customerLst.Count.ToString();
            foreach (var customer in customerLst)
            {
                flowCustomerList.Controls.Add(new UC_CustomerCardForAdmin(customer,this));
            }
        }
        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            flowCustomerList.Controls.Clear();
            var customerLst = Customer_BUL.SearchCustomer (txtSearchCustomer.Text);
            foreach (var customer in customerLst)
            {
                flowCustomerList.Controls.Add(new UC_CustomerCardForAdmin(customer, this));
            }
        }
        /// <summary>
        /// load các contract từ khách hàng 
        /// </summary>
        public void LoadContractFromCustomer (Customer_DTO customer)
        {
            flowContractOfCustomer.Controls.Clear ();
            var ContractFromCustomerUnComfirm = BUL.Contract_BUL.GetContractCustomer(customer,0);
            var ContractFromCustomerProcess = BUL.Contract_BUL.GetContractCustomer(customer, 1);
            var ContractFromCustomerWaitPay = BUL.Contract_BUL.GetContractCustomer(customer, 2); 
            var ContractFromCustomerCompleted = BUL.Contract_BUL.GetContractCustomer(customer, 3);
            var ContractFromCustomer = ContractFromCustomerUnComfirm.Concat(ContractFromCustomerProcess).Concat(ContractFromCustomerWaitPay).Concat(ContractFromCustomerCompleted).ToList();
            foreach (var contract in ContractFromCustomer)
            {
                flowContractOfCustomer.Controls.Add(new UC_Controls.UC_ContractForAdmin(contract));
            } 
            lblTotalCustomerContract.Text = ContractFromCustomerProcess.Count.ToString();
            lblTotalCustomerCompleteContract.Text = ContractFromCustomerCompleted.Count.ToString();
            lblTotalCustomerProcedContract.Text = ContractFromCustomerProcess.Count.ToString();
            lblTotalCustomerUncomfirmContract.Text = ContractFromCustomerUnComfirm.Count.ToString();
        }
        #endregion code cho phần 
        #region code cho phần Setting Manager 
        private bool CheckInputMangager ()
        {
            error.Clear();
            bool wasError = true;
            if (InputCheck.CheckInput.Name(txtFullNameAdmin.Text))
            {
                error.SetError(txtFullNameAdmin, "Full name not valid!");
                wasError = false;
            }
            if (InputCheck.CheckInput.IsValidPhoneNumber(txtPhoneAdmin.Text) ){
                error.SetError(txtPhoneAdmin, "Phone number not valid !");
                wasError = false;
            }
            return wasError;
        }
        private void getManager ()
        {
            manager.Phone = txtPhoneAdmin.Text;
            manager.FullName = txtFullNameAdmin.Text;
            MemoryStream picManager = new MemoryStream();
            picAvatar.Image.Save(picManager, picAvatar.Image.RawFormat);
            manager.Picture = picManager;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckInputMangager()) return ;
            getManager();
            if (BUL.Manager_BUL.UpdateManager(manager))
                lblNotice.Text = "Successfully updated manager information";
            else lblNotice.Text = "Update manager information failed";
        }

        private void btnUpPicAdmin_Click(object sender, EventArgs e)
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
                picAvatar.ImageLocation = filePath;
            }
        }
        #endregion
        // Chọn để mở form phân lịch
        private void btnSchedule_Click(object sender, EventArgs e)
        {
            Hide();
            new frmScheduler().ShowDialog();
            Show();
        }
    }
}
