using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingLotManagementt.Forms
{
    public partial class frmVehicleAndContract : Form
    {
        private Vehical_DTO myVehicle;
        private List <Contract_DTO> myContract;
        private void SetMyVehicle ()
        {
            txtIdVehicle.Text = myVehicle.VehicalId;
            txtModelVehicle.Text = myVehicle.Model;
            txtTypeVehicle.Text = myVehicle.Type;
            picAvatarCar.Image = myVehicle.Picture == null ? picAvatarCar.Image : Image.FromStream(myVehicle.Picture);
            lblToday.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
        private void LoadContract ()
        {
            SetContractFromVehicle (BUL.Contract_BUL.GetContract(myVehicle));
        }
        private void LoadContract (DateTime start, DateTime end)
        {
            SetContractFromVehicle(BUL.Contract_BUL.GetContract(myVehicle,start,end));
        }
        private void SetContractFromVehicle (List<Contract_DTO> myContractLst)
        {
            this.myContract = myContractLst;
            myContract.Sort((x, y) => x.ReceiptDate.CompareTo(y.ReceiptDate));
            flContractFromVehicle.Controls.Clear();
            int numberRent = 0;
            int numberBorrow = 0;
            int numberMaintencesAndWashing = 0;
            foreach (var contract in myContract)
            {
                flContractFromVehicle.Controls.Add(new UC_Controls.UC_ContractFromVehicle(contract));
                if (contract.MyContractDetail[0].Service.Type == "rent")    numberRent ++;
                else if (contract.MyContractDetail[0].Service.Type == "borrow") numberBorrow ++;
                else 
                    numberMaintencesAndWashing ++;
            }
            txtNumberContract.Text = myContract.Count.ToString();
            txtNumberBorrowContract.Text = numberBorrow.ToString();
            txtNumberMaintenensWashing.Text = numberMaintencesAndWashing.ToString();
            txtNumberRentContract.Text = numberRent.ToString();
        }
        public frmVehicleAndContract(Vehical_DTO myVehicle)
        {
            InitializeComponent();
            this.myVehicle = myVehicle; 
            SetMyVehicle();
            LoadContract();
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region di chuyển thanh trượt 
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
        private bool CheckInputDtpk ()
        {
            if (dtpkToDate.Value < dtpkFromDate.Value)
            {
                lblNotice.Text = "Invalid time, to date > since";
                dtpkFromDate.Value = dtpkFromDate.MinDate;
                dtpkToDate.Value = dtpkToDate.MaxDate;
                return false;
            }
            return true;
        }

        private void dtpkToDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpkToDate.Value == dtpkToDate.MaxDate) return;
            if (!CheckInputDtpk()) return;
            LoadContract (dtpkFromDate.Value,dtpkToDate.Value);
        }

        private void dtpkFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpkFromDate.Value == dtpkFromDate.MinDate) return;
            if (!CheckInputDtpk()) return;
            LoadContract(dtpkFromDate.Value, dtpkToDate.Value);
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
