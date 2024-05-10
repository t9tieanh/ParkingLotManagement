using DTO;
using ParkingLotManagementt.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingLotManagementt.UC_Controls
{
    public partial class UC_MessageForAdmin : UserControl
    {
        private frmMain frmMain;
        private frmViewDetailParkAreaForAdmin viewDetailParkAreaForAdmin;
        private Contract_DTO myContract ;
        private frmViewContractParkArea viewContractParkArea;
        private void setMyContract ()
        {
            lblNameCustomer.Text = myContract.Customer.FullName;
            lblStartday.Text = myContract.ReceiptDate.ToString("dd/MM/yyyy");
            lblIdContract.Text = myContract.ContractId;
            PicCustomer.Image = myContract.Customer.Picture != null ? Image.FromStream(myContract.Customer.Picture) : null;
            // lấy các service 
            foreach (var contractDetail in myContract.MyContractDetail)
            {
                lblDetail.Text += contractDetail.Service.NameService + ", ";
            }
        }
        public UC_MessageForAdmin()
        {
            InitializeComponent();
        }
        public UC_MessageForAdmin(Contract_DTO myContract, frmMain frmMain)
        {
            InitializeComponent();
            this.myContract = myContract;
            setMyContract();
            this.frmMain = frmMain;
        }
        public UC_MessageForAdmin(Contract_DTO myContract, frmViewContractParkArea viewContractParkArea)
        {
            InitializeComponent();
            this.myContract = myContract;
            setMyContract();
            this.viewContractParkArea = viewContractParkArea;
        }
        public UC_MessageForAdmin(Contract_DTO myContract, frmViewDetailParkAreaForAdmin viewDetailParkAreaForAdmin)
        {
            InitializeComponent();
            this.myContract = myContract;
            setMyContract();
            this.viewDetailParkAreaForAdmin = viewDetailParkAreaForAdmin;
        }

        private void UC_Message_Click(object sender, EventArgs e)
        {
            new frmCofirmationContract(myContract).ShowDialog();
            if (frmMain != null)
                frmMain.LoadContract();
            else if (viewDetailParkAreaForAdmin != null) 
                viewDetailParkAreaForAdmin.LoadContract();
            else if (viewContractParkArea != null) 
                viewContractParkArea.LoadContract();
        }
    }
}
