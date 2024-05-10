using DTO;
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

namespace ParkingLotManagementt.Forms
{
    public partial class CreateContractBorrow : Form
    {
        #region thanh trượt
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
        private Contract_DTO newContract;
        private RentalManagement_DTO myRentalManagement;
        private string TimeString(int time)
        {
            if (time < 24)
                return time + " Hour" + (time == 1 ? "" : "s"); // pluralize "Hour" if time is not 1
            else if (time >= 24 && time < 168)
                return (time / 24) + " Day" + (time / 24 == 1 ? "" : "s"); // convert to days and pluralize if necessary
            else if (time >= 168 && time < 720)
                return (time / 168) + " Week" + (time / 168 == 1 ? "" : "s"); // convert to weeks and pluralize if necessary
            else
                return (time / 720) + " Month" + (time / 720 == 1 ? "" : "s"); // convert to months and pluralize if necessary
        }
        private void SetInfomationContract ()
        {
            // set thông tin cho xe chuẩn bị mượn 
            pbxVehicle.Image = (myRentalManagement.MyContract.MyVehical.Picture == null) ? pbxVehicle.Image : 
                Image.FromStream(myRentalManagement.MyContract.MyVehical.Picture);
            lblNameVehicle.Text = myRentalManagement.MyContract.MyVehical.VehicalId;
            lblTypeVehicle.Text = myRentalManagement.MyContract.MyVehical.Type;
            lblModel.Text = myRentalManagement.MyContract.MyVehical.Model;
            // set thông tin cho nhà xe để khách nhận xe 
            txtIdParkArea.Text = myRentalManagement.MyContract.MyParkArea.ParkAreaId;
            txtNameParkArea.Text = myRentalManagement.MyContract.MyParkArea.Address;
            // set thông tin cho chủ xe 
            txtIdCustomer.Text = myRentalManagement.MyContract.Customer.CustomerId;
            txtFullName.Text = myRentalManagement.MyContract.Customer.FullName;
            txtPhoneNumberCustomer.Text = myRentalManagement.MyContract.Customer.Phone;
            txtAddressCustomer.Text = myRentalManagement.MyContract.Customer.Address;
            picCustomer.Image = (myRentalManagement.MyContract.Customer.Picture == null) ? picCustomer.Image :
               Image.FromStream(myRentalManagement.MyContract.Customer.Picture);
            // set thông tin cho dịch vụ chuẩn bị được chọn vào contract 
            lblNameService.Text = newContract.MyContractDetail[0].Service.NameService;
            lblTimeService.Text =TimeString( newContract.MyContractDetail[0].Service.Time);
            lblDecription.Text = newContract.MyContractDetail[0].Service.Description;
            lblPriceContract.Text = newContract.MyContractDetail[0].Service.Price + "$";
        }
        public CreateContractBorrow()
        {
            InitializeComponent();
        }
        public CreateContractBorrow(Contract_DTO newContract, RentalManagement_DTO management)
        {
            InitializeComponent();
            this.newContract = newContract;
            this.myRentalManagement = management;
            SetInfomationContract();
        }

        private void btnCreateContract_Click(object sender, EventArgs e)
        {
            error.Clear();
            if (rdButtonBorrow.Checked == false)
            {
                error.SetError(rdButtonBorrow, "You have not confirmed the car rental terms");
                return;
            }
            // thêm hợp đồng 
            if (!BUL.Contract_BUL.InsertContractBorrow(newContract))
            {
                lblNotice.Text = "Creating a car rental contract was not successful, please try again";
                return;
            }
            else
            {
                MessageBox.Show($"Sent a request to borrow a car {newContract.MyVehical}, waiting for admin to confirm",
               "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            /*if (!BUL.RentalManagement_BUL.DeleteRentalManagement(myRentalManagement.IdRentalManagement))
            {
                lblNotice.Text = "Creating a car rental contract was not successful, please try again";
                return;
            }
            //
            Tuple<RentalManagement_DTO, RentalManagement_DTO> newRentalManagement =
                myRentalManagement.rentChange(newContract.ReceiptDate, newContract.DeliveryDate);
            BUL.RentalManagement_BUL.InsertRentalManagement(newRentalManagement.Item1);
            BUL.RentalManagement_BUL.InsertRentalManagement(newRentalManagement.Item2);
            MessageBox.Show($"Successfully created car rental contract, please come to the garage {myRentalManagement.MyContract.MyParkArea.Address} at {newContract.ReceiptDate.ToString("yyyy-MM-dd")} to pick up the car",
                "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();*/
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
