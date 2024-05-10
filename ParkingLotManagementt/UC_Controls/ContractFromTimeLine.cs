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
    public partial class ContractFromTimeLine : UserControl
    {
        private Contract_DTO myContract;
        private void setMyContract()
        {
            lblNameCustomer.Text = myContract.Customer.FullName;
            lblStartday.Text = myContract.ReceiptDate.ToString("dd/MM/yyyy") +" - "+ myContract.DeliveryDate.ToString ("dd/MM/yyyy");
            //lblIdContract.Text = myContract.ContractId;
            PicCustomer.Image = myContract.Customer.Picture != null ? Image.FromStream(myContract.Customer.Picture) : null;
            lblStatus.Text = myContract.StatusToString();
            //
            //picStatus.FillColor = ColorTranslator.FromHtml(myContract.StatusToColor()); // Màu nền
            processSpeed.Value = (int)((double)(myContract.Status / 3.0) * 100);
            lblValue.Text = processSpeed.Value.ToString() + "%";
            processSpeed.ProgressColor = ColorTranslator.FromHtml(myContract.StatusToColor()); // Màu nền
            processSpeed.ProgressColor2 = ColorTranslator.FromHtml(myContract.StatusToColor()); // Màu tiến trình
            //
            /*if (myContract.MyContractDetail[0].Service.Type == "rent")
                this.BackColor = ColorTranslator.FromHtml("#fd79a8") ;*/
            // lấy các service 
            foreach (var contractDetail in myContract.MyContractDetail)
            {
                lblDetail.Text += contractDetail.Service.NameService + ", ";
            }
        }
        public ContractFromTimeLine(Contract_DTO myContract)
        {
            InitializeComponent();
            this.myContract = myContract;
            setMyContract();
        }
        public ContractFromTimeLine()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            new frmContractDetail(myContract).ShowDialog ();
        }
    }
}
