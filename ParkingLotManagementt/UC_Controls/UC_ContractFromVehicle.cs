using DTO;
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
    public partial class UC_ContractFromVehicle : UserControl
    {
        private Contract_DTO myContract; 
        private void SetContract ()
        {
            lblReceptionDate.Text = myContract.ReceiptDate.ToString("yyyy-MM-dd");
            if (myContract.MyContractDetail[0].Service.Type == "rent")
            {
                lblNotice.Text += "This is rent Contract, expiration date : ";//+ myContract.DeliveryDate.ToString("yyyy-MM-dd");
            }
            else if (myContract.MyContractDetail[0].Service.Type == "borrow")
            {
                lblNotice.ForeColor = Color.Orange;
                lblDateDelivery.ForeColor = Color.Orange;
                lblNotice.Text += "This is borrow Contract, expiration date : ";
            }
            else 
            {
                lblNotice.ForeColor = Color.Green;
                lblDateDelivery.ForeColor = Color.Green;
                lblNotice.Text += "This is maintenance or wash Contract, expiration date : ";
            }
            lblDateDelivery.Text = myContract.DeliveryDate.ToString("yyyy-MM-dd");
            flowPnContract.Controls.Clear();
            flowPnContract.Controls.Add(new ContractFromTimeLine(myContract));
        }
        public UC_ContractFromVehicle()
        {
            InitializeComponent();
        }
        public UC_ContractFromVehicle(Contract_DTO myContract)
        {
            InitializeComponent();
            this.myContract = myContract;
            SetContract (); 
        }
    }
}
