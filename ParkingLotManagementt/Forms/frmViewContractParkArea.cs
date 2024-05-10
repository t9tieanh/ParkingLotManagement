using BUL;
using DTO;
using ParkingLotManagementt.UC_Controls;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ParkingLotManagementt.Forms
{
    public partial class frmViewContractParkArea : Form
    {
        private List <Vehical_DTO> vehicleMaintanedAndWashed = new List <Vehical_DTO> ();
        private List <Vehical_DTO> vehicleBorrow = new List <Vehical_DTO> ();
        private List <Vehical_DTO> vehicleRent = new List<Vehical_DTO> ();
        private List<Vehical_DTO> vehicleManagedbyCompany = new List<Vehical_DTO>();
        private void LoadVehicle ()
        {
            vehicleMaintanedAndWashed = BUL.Vehicle_BUL.GetMyVehicleForContract("maintenance");
            vehicleMaintanedAndWashed.AddRange(BUL.Vehicle_BUL.GetMyVehicleForContract("wash"));
            vehicleBorrow = BUL.Vehicle_BUL.GetMyVehicleForContract("borrow");
            vehicleRent = BUL.Vehicle_BUL.GetMyVehicleForContract("rent");
            vehicleManagedbyCompany = Vehicle_BUL.GetMyVehicleForContract();
            lblnumberRent.Text = vehicleRent.Count.ToString();
            lblNumberBorrow.Text = vehicleBorrow.Count.ToString();
            lblNumberMaintanedWash.Text = vehicleMaintanedAndWashed.Count.ToString();
            lblNumberManagementCompany.Text = vehicleManagedbyCompany.Count.ToString();
        }
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
                var contractLst = BUL.Contract_BUL.GetContract(status);
                foreach (var contract in contractLst)
                    flowContractUC.Controls.Add(new UC_ContractForAdmin(contract));
            }
            catch
            {
                MessageBox.Show("Có lỗi khi lấy dữ liệu !", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public frmViewContractParkArea()
        {
            InitializeComponent();
            LoadVehicle();
            LoadContract();
        }
        #region code cho giao diện 
        private void picExit_Click(object sender, EventArgs e)
        {
            this.Close ();  
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
        #endregion

        private void cbContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbContract.SelectedIndex == 0)
            {
                LoadContract();
                return;
            }
            LoadContract(cbContract.SelectedIndex);
        }

        private void btnVehicleMaintanedAndWashed_Click(object sender, EventArgs e)
        {
            flowContractUC.Controls.Clear();
            foreach (var vehicle in vehicleMaintanedAndWashed)
                flowContractUC.Controls.Add(new UC_VehicleForViewContractFrm(vehicle));
        }

        private void btnVehicleRent_Click(object sender, EventArgs e)
        {
            flowContractUC.Controls.Clear();
            foreach (var vehicle in vehicleRent)
                flowContractUC.Controls.Add(new UC_VehicleForViewContractFrm(vehicle));
        }

        private void btnVehicleBorrow_Click(object sender, EventArgs e)
        {
            flowContractUC.Controls.Clear();
            foreach (var vehicle in vehicleBorrow)
                flowContractUC.Controls.Add(new UC_VehicleForViewContractFrm(vehicle));
        }

        private void btnVehicleManagedbyCompany_Click(object sender, EventArgs e)
        {
            flowContractUC.Controls.Clear();
            foreach (var vehicle in vehicleManagedbyCompany)
                flowContractUC.Controls.Add(new UC_VehicleForViewContractFrm(vehicle));
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            List<Contract_DTO> myContract = new List<Contract_DTO>();
            if (cbSerachContract.Text == "Customer Name")
                myContract = BUL.Contract_BUL.SearchContract(new Customer_DTO(txtSearchVehicle.Text));
            else if (cbSerachContract.Text == "Vehicle ID")
                myContract = BUL.Contract_BUL.SearchContract(new Vehical_DTO(txtSearchVehicle.Text));
            flowContractUC.Controls.Clear();
            foreach (var contract in myContract)
                flowContractUC.Controls.Add(new UC_ContractForAdmin(contract));
        }
    }
}
