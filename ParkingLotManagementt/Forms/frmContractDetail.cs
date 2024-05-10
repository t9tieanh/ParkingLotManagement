using BUL;
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
    public partial class frmContractDetail : Form
    {
        private Contract_DTO myContract;
        /*/// <summary>
        /// đối với contractdetail thuộc loại cho mượn và vay xe thì value status được đặt bằng cách so sánh với thời gian kết thúc hợp đồng với 
        /// thời gian hiện tại (now) -> 
        /// </summary>
        private void UpdateStatusContractDetail ()
        {
            foreach (var contractDetail in myContract.MyContractDetail)
            {
                if (contractDetail.Service.Type == "rent" ||  contractDetail.Service.Type =="borrow")
                {
                    if (DateTime.Now > myContract.DeliveryDate)
                        contractDetail.Status = 1;
                    else 
                        contractDetail.Status = 0;
                }
            }
        }*/
        private void SetContract()
        {
            List<Service_DTO> services = myContract.MyContractDetail.Select(cd => cd.Service).ToList();
            dgvListService.DataSource = services.Select(s => new { s.NameService }).ToList();
            txtIDCustomer.Text = myContract.Customer.CustomerId;
            txtFullname.Text = myContract.Customer.FullName;
            picCustomer.Image = (myContract.Customer.Picture != null) ? Image.FromStream(myContract.Customer.Picture) : picCustomer.Image;
            txtIdParkArea.Text = myContract.MyParkArea.ParkAreaId;
            txtNameParkArea.Text = myContract.MyParkArea.Address;
            lblReceiptDate.Text = myContract.ReceiptDate.ToString("yyyy-MM-dd");
            lblDeliveryDate.Text = myContract.DeliveryDate.ToString("yyyy-MM-dd");

            flPnVehicle.Controls.Clear();
            flPnVehicle.Controls.Add(new UC_Controls.UC_Vehicle(myContract.MyVehical));
        }
        #region di chuyển thanh trượt 
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        #endregion
        public frmContractDetail()
        {
            InitializeComponent();
        }
        public frmContractDetail(Contract_DTO myContract)
        {
            InitializeComponent();
            this.myContract = myContract;
            if (myContract.Status == 2 || myContract.Status == 3)
            {
                lblTitleSmall.ForeColor = Color.Green;
                btnComfirm.Enabled = false;
                if (myContract.Status == 2)
                    lblTitleSmall.Text = "Contract pending payment !";
                else
                    lblTitleSmall.Text = "Contract completed";
            }
            /*UpdateStatusContractDetail();*/
            SetContract();
            pnInforContractDetail.Enabled = false;
        }
        // load worker lên combobox
        private List<Worker_DTO> LoadWorker(string type)
        {
            return BUL.Worker_BUL.GetWorker(type, myContract.MyParkArea.ParkAreaId);
        }
        private void SetStatusContractDetail (int status)
        {
            if ( status == 1)
            {
                lblStatus.Text = "Done";
                cbWorker.Enabled = false;
                picStatusContractDetail.Image = Resource1.correct;
                btnApply.Enabled =false;
            }
            else
            {
                lblStatus.Text = "unfinished";
                cbWorker.Enabled = true;
                cbWorker.DisplayMember = "FullName";
                picStatusContractDetail.Image = Resource1.folder;
                btnApply.Enabled = true;
            }
        }
        private void dgvListService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pnInforContractDetail.Enabled = true;
            lblNotice.Text = "!";
            int i = dgvListService.CurrentRow.Index;
            lblIdService.Text = myContract.MyContractDetail[i].Service.ServiceId;

            SetStatusContractDetail(myContract.MyContractDetail[i].Status);

            flPnService.Controls.Clear();
            flPnService.Controls.Add(new UC_Controls.UC_ServiceForAdminView(myContract.MyContractDetail[i].Service));
            flWorker.Controls.Clear();
            if (myContract.MyContractDetail[i].Service.Type == "borrow" || myContract.MyContractDetail[i].Service.Type == "rent")
            {
                lblNotice.Text = "This is a rental service, no need to assign staff!";
                cbWorker.Enabled = false;
                return;
            }
            flWorker.Controls.Add(new UC_Controls.UC_Worker(myContract.MyContractDetail[i].Worker));
        }
        private void picExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show ($"Confirm the change of worker {myContract.MyContractDetail[dgvListService.CurrentRow.Index].Worker} to worker {(Worker_DTO)cbWorker.SelectedValue} for this job ?", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;
            if (ContractDetail_BUL.UpdateContractDetailWorker(myContract.MyContractDetail[dgvListService.CurrentRow.Index], ((Worker_DTO)cbWorker.SelectedValue).WorkerId))
            {
                myContract.MyContractDetail[dgvListService.CurrentRow.Index].Worker = (Worker_DTO)cbWorker.SelectedValue;
                flWorker.Controls.Clear();
                flWorker.Controls.Add(new UC_Controls.UC_Worker((Worker_DTO)cbWorker.SelectedValue));
                lblNotice.Text = "worker change successful!";
            }
            else
                lblNotice.Text = "There was an error changing worker for this job!";
        }

        private void btnComfirm_Click(object sender, EventArgs e)
        {
            foreach (var contractDetail in myContract.MyContractDetail)
            {
                if (contractDetail.Status == 0)
                {
                    lblNotice.Text = "The contract has some unfinished tasks and the contract completion cannot be confirmed!";
                    return;
                }
            }
            if (BUL.Contract_BUL.ConfirmContractCompletion(myContract))
            {
                MessageBox.Show("Confirm the contract has been completed and is ready to be delivered to the customer successfully!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else lblNotice.Text = "Confirm the contract has been completed and is ready to be delivered to the unsuccessful customer!";
        }
    }
}
