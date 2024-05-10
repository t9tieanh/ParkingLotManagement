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
    public partial class UC_ContractForCustomer : UserControl
    {
        private Contract_DTO myContract;
        private frmContractCustomer frmContractCustomer;
        private void SetContract ()
        {
            lblNameVehicle.Text = myContract.MyVehical.VehicalId;
            lblStatusContract.Text = myContract.StatusToString();
            lblStartday.Text = "Request day: " + myContract.ReceiptDate.ToString ("yyyy-MM-dd");
            foreach (var contractDetail in myContract.MyContractDetail)
            {
                lblDetail.Text = contractDetail.Service.NameService;
            }
            picStatus.FillColor = ColorTranslator.FromHtml(myContract.StatusToColor());
        }
        public UC_ContractForCustomer()
        {
            InitializeComponent();
        }
        public UC_ContractForCustomer(Contract_DTO myContract, frmContractCustomer frmContractCustomer)
        {
            InitializeComponent();
            this.myContract = myContract;
            this.frmContractCustomer = frmContractCustomer;
            SetContract();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            frmContractCustomer.LoadContractDetail(myContract);
        }
    }
}
