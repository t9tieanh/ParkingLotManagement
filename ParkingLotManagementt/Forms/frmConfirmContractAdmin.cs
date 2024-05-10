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
    public partial class frmConfirmContractAdmin : Form
    {
        private Contract_DTO myContract;
        public frmConfirmContractAdmin()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        // load worker lên combobox
        private List<Worker_DTO> LoadWorker (string type)
        {
            return BUL.Worker_BUL.GetWorker(type, myContract.MyParkArea.ParkAreaId);
        }
        private void SetContract()
        {
            List<Service_DTO> services = myContract.MyContractDetail.Select(cd => cd.Service).ToList();
            dgvListService.DataSource = services.Select(s => new { s.NameService }).ToList();
            txtIDCustomer.Text = myContract.Customer.CustomerId;
            txtFullname.Text = myContract.Customer.FullName;
            txtIdParkArea.Text = myContract.MyParkArea.ParkAreaId;
            txtNameParkArea.Text = myContract.MyParkArea.Address;
            picCustomer.Image = (myContract.Customer.Picture != null) ? Image.FromStream(myContract.Customer.Picture) : picCustomer.Image;

            flPnVehicle.Controls.Clear();
            flPnVehicle.Controls.Add(new UC_Controls.UC_Vehicle(myContract.MyVehical));
        }
        public frmConfirmContractAdmin(Contract_DTO myContract)
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.myContract = myContract;   
            SetContract();
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

        #endregion

        private void dgvListService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblNotice.Text = "!";
            lblNoticeWorker.Text = "!";
            pnChooseWorker.Enabled = true;
            int i = dgvListService.CurrentRow.Index;
            lblServiceName.Text = myContract.MyContractDetail[i].Service.NameService;
            lblIdService.Text = myContract.MyContractDetail[i].Service.ServiceId;
            if (myContract.MyContractDetail[i].Service.Type != "borrow" &&
                myContract.MyContractDetail[i].Service.Type != "rent")
            {
                cbWorker.DataSource = LoadWorker(myContract.MyContractDetail[i].Service.Type);
                cbWorker.DisplayMember = "FullName";
            }
            else { 
                pnChooseWorker.Enabled = false;
                lblNotice.Text = "This is a rental service, no need to assign staff!";
            }
        }

        private void cbWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNameWorker.Text = ((Worker_DTO)cbWorker.SelectedValue).FullName;
            txtIdWorker.Text = ((Worker_DTO)cbWorker.SelectedValue).WorkerId;
            picAvatarOfWorker.Image = Image.FromStream (((Worker_DTO)cbWorker.SelectedValue).Picture);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            int i = dgvListService.CurrentRow.Index;
            if (((Worker_DTO)cbWorker.SelectedValue) != null)
            {
                myContract.MyContractDetail[i].Worker = ((Worker_DTO)cbWorker.SelectedValue);
                lblNoticeWorker.Text = "assigned to this service successfully!";
            }
        }
        /// <summary>
        /// check xem admin đã phân công việc cho tất cả các contract detail chưa
        /// </summary>
        /// <returns></returns>
        private bool checkChooseWorker ()
        {
            foreach (var contractDetail in myContract.MyContractDetail)
            {
                if (contractDetail.Worker == null &&
                    contractDetail.Service.Type != "borrow" && contractDetail.Service.Type != "rent")
                {
                    MessageBox.Show("VCL");
                    return false;
                }
            }
            return true;
        }
        private void btnComfirm_Click(object sender, EventArgs e)
        {
            if (checkChooseWorker ())
            {
                if (BUL.Contract_BUL.ConfirmContract(myContract))
                {
                    MessageBox.Show("Successful contract confirmation!","Notice",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    lblNotice.Text = "Contract validation failed";
            }
            else
            {
                lblNotice.Text = "You have not assigned workers to all services of this contract!";
            }
        }
    }
}
