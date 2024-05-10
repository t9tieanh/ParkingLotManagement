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
    public partial class frmContractCustomer : Form
    {
        private Customer_DTO myCustomer;
        private Contract_DTO contractSelected;
        private void LoadContract (int status)
        {
            flowContract.Controls.Clear();
            var ContractCustomerLst = BUL.Contract_BUL.GetContractCustomer(myCustomer, status);
            foreach (var contract in ContractCustomerLst)
            {
                flowContract.Controls.Add(new UC_Controls.UC_ContractForCustomer(contract,this));
            }
        }
        private void SetCustomer ()
        {
            try
            {
                picCustomerAvatar.Image = myCustomer.Picture != null ? Image.FromStream(myCustomer.Picture) : picCustomerAvatar.Image;
            }
            catch { }
            lblNameCustomer.Text = myCustomer.FullName;
            lblIdCustomer.Text = myCustomer.Account.UserName;
        }
        public void LoadContractDetail (Contract_DTO myContract)
        {
            contractSelected = myContract;
            pnDetailContractDetail.Enabled = true;
            //
            btnDeleteContract.Enabled = false;
            btnPayMent.Enabled = false;
            if (myContract.Status == 0)
            {
                btnDeleteContract.Enabled = true;
                btnPayMent.Enabled = false;
            }
            else if (myContract.Status == 2)
            {
                btnPayMent.Enabled = true;
                btnDeleteContract.Enabled = false;
            }
            // set data
            txtIdContract.Text = myContract.ContractId;
            txtReceiptDate.Text = myContract.ReceiptDate.ToString("yyyy-MM-dd");
            txtDeadline.Text = myContract.DeliveryDate.ToString("yyyy-MM-dd");
            // set dữ liệu cho car 
            txtIdVehicle.Text = myContract.MyVehical.VehicalId;
            txtModelVehicle.Text = myContract.MyVehical.Model;
            txtTypeVehicle.Text = myContract.MyVehical.Type;
            picAvatarCar.Image = (myContract.MyVehical.Picture == null) ? picAvatarCar.Image : Image.FromStream(myContract.MyVehical.Picture);
            // set dữ liệu cho flowContractDetail 
            flowContractDetail.Controls.Clear();
            foreach (var contractDetail in myContract.MyContractDetail)
            {
                flowContractDetail.Controls.Add(new UC_Controls.UC_ContractDetailFromCustomer(contractDetail));
            }
        }
        public frmContractCustomer(Customer_DTO myCustomer)
        {
            InitializeComponent();
            this.myCustomer = myCustomer;
            rdUncomfirmed.Checked = true;
            btnDeleteContract.Enabled = false;
            btnPayMent.Enabled = false;
            pnDetailContractDetail.Enabled = false;
            SetCustomer();
        }

        private void rdUncomfirmed_CheckedChanged(object sender, EventArgs e)
        {
            LoadContract(0);
        }

        private void rdProcessing_CheckedChanged(object sender, EventArgs e)
        {
            LoadContract(1);
        }

        private void rdWaitForPay_CheckedChanged(object sender, EventArgs e)
        {
            LoadContract(2);
        }

        private void rdComplete_CheckedChanged(object sender, EventArgs e)
        {
            LoadContract(3);
        }

        private void btnDeleteContract_Click(object sender, EventArgs e)
        {
            if (contractSelected == null) return;
            if (BUL.Contract_BUL.DeleteContract(contractSelected))
            {
                pnDetailContractDetail.Enabled = false;
                contractSelected = null;
                lblNotice.Text = $"Cancel contract {contractSelected} successfully";
                LoadContract(0);
            }
            else
                lblNotice.Text = "(system error) There was an error deleting the contract, the contract has not been deleted";
        }

        private void btnPayMent_Click(object sender, EventArgs e)
        {
            if (contractSelected == null) return;
            new frmPayMentForCustomer(contractSelected).ShowDialog();
        }
        #region code giao diện 
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
        #endregion
    }
}
