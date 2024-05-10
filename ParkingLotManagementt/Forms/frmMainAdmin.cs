using BUL;
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
    public partial class frmMainAdmin : Form
    {
        public frmMainAdmin()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            // lấy dữ liệu từ database 
            loadWorker();
            loadContract();
            loadParkArea();
            LoadService();
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
            pnVehicle.Hide();
            pnWorker.Hide();
            pnContract.Hide();
            pnCustomer.Hide();
            pnSetting.Show();
            pnPartArea.Hide();
        }

        #endregion

        //#region Panel cho Park area

        //private void PanelOfParkArea()
        //{
        //    Setup.ChangeControl.ChangeSizeOfControl(pnItemOne, 253, 354);
        //    Setup.ChangeControl.ChangeLocationOfControl(pnItemOne, 115, 157);

        //    Setup.ChangeControl.ChangeSizeOfControl(pnThree, 253, 354);
        //    Setup.ChangeControl.ChangeLocationOfControl(pnThree, 700, 157);

        //    Setup.ChangeControl.ChangeSizeOfControl(pnItemTwo, 253, 390);
        //    Setup.ChangeControl.ChangeLocationOfControl(pnItemTwo, 410, 140);

        //    Setup.ChangeControl.ChangeLocationOfControl(picPrevius, 20, 335);
        //    Setup.ChangeControl.ChangeLocationOfControl(picNext, 993, 335);
        //    Setup.ChangeControl.ChangeSizeOfControl(lblTitleParkArea, 752, 65);
        //    Setup.ChangeControl.ChangeLocationOfControl(lblTitleParkArea, 140, 42);

        //}

        //#endregion

        //#region Panel cho Worker

        //private void PanleOfWorker()
        //{
        //    Setup.ChangeControl.ChangeSizeOfControl(uC_Worker_Choose, 695, 78);
        //    Setup.ChangeControl.ChangeLocationOfControl(uC_Worker_Choose, 318, 55);
        //    Setup.ChangeControl.ChangeLocationOfControl(lblChooed, 318, 18);


        //    Setup.ChangeControl.ChangeSizeOfControl(dgvListOfWorker, 695, 370);
        //    Setup.ChangeControl.ChangeLocationOfControl(dgvListOfWorker, 318,248);

        //    Setup.ChangeControl.ChangeSizeOfControl(btnAddWorker, 102, 36);
        //    Setup.ChangeControl.ChangeLocationOfControl(btnAddWorker, 910, 199);

        //    Setup.ChangeControl.ChangeSizeOfControl(cbChooseSort, 246, 42);
        //    Setup.ChangeControl.ChangeLocationOfControl(cbChooseSort, 32, 55);
        //    Setup.ChangeControl.ChangeLocationOfControl(lblSortWorker, 32, 18);


        //    Setup.ChangeControl.ChangeSizeOfControl(txtInfomationForSeacrh, 246, 42);
        //    Setup.ChangeControl.ChangeLocationOfControl(txtInfomationForSeacrh, 32, 120);

        //    Setup.ChangeControl.ChangeSizeOfControl(btnSearchWorker, 246, 36);
        //    Setup.ChangeControl.ChangeLocationOfControl(btnSearchWorker, 32, 199);
        //    Setup.ChangeControl.ChangeLocationOfControl(lblListWorker, 318, 199);


        //    Setup.ChangeControl.ChangeLocationOfControl(processWashing, 32, 305);
        //    Setup.ChangeControl.ChangeLocationOfControl(processRepair, 188, 305);
        //    Setup.ChangeControl.ChangeLocationOfControl(processLook, 112, 478);

        //    Setup.ChangeControl.ChangeLocationOfControl(btnWorkerTypeWash, 18, 397);
        //    Setup.ChangeControl.ChangeLocationOfControl(btnWorkerTypeRepair, 182, 397);
        //    Setup.ChangeControl.ChangeLocationOfControl(btnWorkerTypeLook, 100, 570);
        //}


        //#endregion

        //private void ChangeControl()
        //{
        //    Setup.ChangeControl.ChangeSizeOfControl(this, 1200, 700);
        //    Setup.ChangeControl.ChangeLocationOfControl(this, 30, 20);

        //    // Panel top
        //    Setup.ChangeControl.ChangeSizeOfControl(pnTop, 1200, 48);

        //    // Title
        //    Setup.ChangeControl.ChangeSizeOfControl(lblTitle, 200, 48);
        //    Setup.ChangeControl.ChangeLocationOfControl(lblTitle, 500, 10);

        //    // Logo
        //    Setup.ChangeControl.ChangeSizeOfControl(picLogo, 48, 48);
        //    Setup.ChangeControl.ChangeLocationOfControl(picLogo, 440, 0);

        //    // Panel left: Chứa các control
        //    Setup.ChangeControl.ChangeSizeOfControl(pnLeft, 130, 789);
        //    Setup.ChangeControl.ChangeSizeOfControl(pnCurrent, 10, 48);
        //    Setup.ChangeControl.ChangeLocationOfControl(pnCurrent, 120, 16);

        //    Setup.ChangeControl.ChangeSizeOfControl(picVehicle, 48, 48);
        //    Setup.ChangeControl.ChangeSizeOfControl(picWorker, 48, 48);
        //    Setup.ChangeControl.ChangeSizeOfControl(picCustomer, 48, 48);
        //    Setup.ChangeControl.ChangeSizeOfControl(picContract, 48, 48);
        //    Setup.ChangeControl.ChangeSizeOfControl(picArea, 48, 48);
        //    Setup.ChangeControl.ChangeSizeOfControl(picSetting, 48, 48);

        //    Setup.ChangeControl.ChangeLocationOfControl(picVehicle, 39, 16);
        //    Setup.ChangeControl.ChangeLocationOfControl(picWorker, 39, 115);
        //    Setup.ChangeControl.ChangeLocationOfControl(picCustomer, 39, 215);
        //    Setup.ChangeControl.ChangeLocationOfControl(picContract, 39, 315);
        //    Setup.ChangeControl.ChangeLocationOfControl(picArea, 39, 415);
        //    Setup.ChangeControl.ChangeLocationOfControl(picSetting, 39, 515);

        //    Setup.ChangeControl.ChangeLocationOfControl(lblVehicle, 39, 65);
        //    Setup.ChangeControl.ChangeLocationOfControl(lblWorker, 39, 170);
        //    Setup.ChangeControl.ChangeLocationOfControl(lblCustomer, 35, 270);
        //    Setup.ChangeControl.ChangeLocationOfControl(lblContract, 38, 370);
        //    Setup.ChangeControl.ChangeLocationOfControl(lblArea, 32, 470);
        //    Setup.ChangeControl.ChangeLocationOfControl(lblSetting, 36, 570);

        //    #region Các panel chức năng

        //    // Của worker
        //    Setup.ChangeControl.ChangeSizeOfControl(pnWorker, 1058, 642);
        //    Setup.ChangeControl.ChangeLocationOfControl(pnWorker, 136, 52);


        //    // Của customer
        //    Setup.ChangeControl.ChangeSizeOfControl(pnCustomer, 1058, 642);
        //    Setup.ChangeControl.ChangeLocationOfControl(pnCustomer, 136, 52);

        //    // Của contract
        //    Setup.ChangeControl.ChangeSizeOfControl(pnContract, 1058, 642);
        //    Setup.ChangeControl.ChangeLocationOfControl(pnContract, 136, 52);

        //    // Của vehicle
        //    Setup.ChangeControl.ChangeSizeOfControl(pnVehicle, 1058, 642);
        //    Setup.ChangeControl.ChangeLocationOfControl(pnVehicle, 136, 52);

        //    // Của parkarea
        //    Setup.ChangeControl.ChangeSizeOfControl(pnPartArea, 1058, 642);
        //    Setup.ChangeControl.ChangeLocationOfControl(pnPartArea, 136, 52);

        //    // Của setting
        //    Setup.ChangeControl.ChangeSizeOfControl(pnSetting, 1058, 642);
        //    Setup.ChangeControl.ChangeLocationOfControl(pnSetting, 136, 52);

        //    #endregion
        //}

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

        #region  Code chức năng
        #region code cho phần worker 
        private void loadWorker()
        {
            dgvListOfWorker.DataSource = Worker_BUL.GetDataWorker();
            DataGridViewImageColumn pic = (DataGridViewImageColumn)dgvListOfWorker.Columns[3];
            pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
        private void dgvListOfWorker_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            uC_Worker_Choose.Controls.Clear();
            int i = dgvListOfWorker.CurrentRow.Index;
            
            string workerId = dgvListOfWorker.Rows[i].Cells[0].Value.ToString().Trim();
            string fullName = dgvListOfWorker.Rows[i].Cells[1].Value.ToString().Trim();
            string address = dgvListOfWorker.Rows[i].Cells[2].Value.ToString().Trim();

            byte[] pic = dgvListOfWorker.Rows[i].Cells[3].Value as byte[];
            MemoryStream picture = pic != null ? new MemoryStream(pic) : null;

            string type = dgvListOfWorker.Rows[i].Cells[4].Value.ToString().Trim();
            string parkAreaId = dgvListOfWorker.Rows[i].Cells[5].Value.ToString().Trim();
            string parkAreaAddress = dgvListOfWorker.Rows[i].Cells[6].Value.ToString().Trim();
            Worker_DTO worker = new Worker_DTO(workerId, fullName, address, picture, type, new ParkArea_DTO(parkAreaId,parkAreaAddress));
            uC_Worker_Choose.Controls.Add(new UC_Controls.UC_Worker(worker));
        }
        private void btnAddWorker_Click(object sender, EventArgs e)
        {
            frmDetailWorker frmProfileWorker = new frmDetailWorker ();
            frmProfileWorker.ShowDialog();
            loadWorker();
        }
        #endregion
        #endregion

        #region code cho phần contract 
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
            return txtIDParkArea.Text != ""; // chưa code xong 
        }
        private void resetControlParkArea ()
        {
            txtIDParkArea.Text = "";
            txtAddressParkArea.Text = "";
            numCapacity.Value = 100;
            rbtnBicycle.Checked = true;
        }
        public void loadContract ()
        {
            try
            {
                flowContractUC.Controls.Clear();
                flowMessage.Controls.Clear();
                var myListContractCompleted = BUL.Contract_BUL.GetContract(3);
                var myListContractUnpaid = BUL.Contract_BUL.GetContract(2);
                var myListContractMaking = BUL.Contract_BUL.GetContract(1);
                var myListContractUncomfimred = BUL.Contract_BUL.GetContract(0);
                foreach (var contractUncomfimred in myListContractUncomfimred)
                {
                    flowMessage.Controls.Add(new UC_Controls.UC_Message(contractUncomfimred,this));
                }
                /*foreach (var contract in myListContractCom) 
                    flowContractUC.Controls.Add (new UC_Controls.UC_Contract(contract));*/
                foreach (var contract in myListContractUnpaid)
                    flowContractUC.Controls.Add(new UC_Controls.UC_Contract(contract));
                foreach (var contract in myListContractMaking)
                    flowContractUC.Controls.Add(new UC_Controls.UC_Contract(contract));
                //
                lblNumberComplated.Text = myListContractCompleted.Count.ToString();
                lblNumberUnpaid.Text = myListContractUnpaid.Count.ToString();
                lblNumberMaking.Text = myListContractMaking.Count.ToString();
                lblNumberUncomfimred.Text = myListContractUncomfimred.Count.ToString();
            }
            catch
            {
                MessageBox.Show ("Có lỗi khi lấy dữ liệu !","Notice",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        //
        private void loadParkArea ()
        {
            try
            {
                dgvListParkArea.DataSource = BUL.ParkArea_BUL.GetParkArea();
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
            int i = dgvListParkArea.CurrentCell.RowIndex;
            string parkAreaId = dgvListParkArea.Rows[i].Cells[0].Value.ToString().Trim();
            string Address = dgvListParkArea.Rows[i].Cells[1].Value.ToString().Trim();
            int Capacity = Convert.ToInt32 ( dgvListParkArea.Rows[i].Cells[2].Value.ToString());
            string type = dgvListParkArea.Rows[i].Cells[3].Value.ToString().Trim();
            flowChoosePark.Controls.Add(new UC_Controls.UC_ParkArea(new ParkArea_DTO(parkAreaId, Address, Capacity, type)));
            //
            txtIDParkArea.Text = parkAreaId;
            txtAddressParkArea.Text = Address;
            numCapacity.Value = Capacity;
            if (type == "Bicycle") rbtnBicycle.Checked = true;
            else if (type == "Moto") rbtnMotobike.Checked = true;
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
                loadParkArea();
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
                loadParkArea();
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
                loadParkArea();
            }
            else lblNoticeParkArea.Text = "update parking failed!";
        }
        #endregion
        // code cho phần service
        public void LoadService ()
        {
            flowRental.Controls.Clear();
            flowMaintenance.Controls.Clear();
            flowWashing.Controls.Clear();   
            flowBorrow.Controls.Clear();
            List<Service_DTO> servicesRent = BUL.Service_BUL.GetServicesByType("rent");
            foreach (Service_DTO service in servicesRent)
                flowRental.Controls.Add(new UC_Controls.UC_ServiceOfAdmin(service,this));
            List<Service_DTO> serviceWash = BUL.Service_BUL.GetServicesByType("wash");
            foreach (Service_DTO service in serviceWash)
                flowWashing.Controls.Add(new UC_Controls.UC_ServiceOfAdmin(service,this));
            List<Service_DTO> serviceMaintenance = BUL.Service_BUL.GetServicesByType("maintenance");
            foreach (Service_DTO service in serviceMaintenance)
                flowMaintenance.Controls.Add(new UC_Controls.UC_ServiceOfAdmin(service,this));
            List<Service_DTO> serviceBorrow = BUL.Service_BUL.GetServicesByType("borrow");
            foreach (Service_DTO service in serviceBorrow)
                flowBorrow.Controls.Add(new UC_Controls.UC_ServiceOfAdmin(service,this));
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            new frmServiceDetail().ShowDialog();
            LoadService();
        }
    }
}
