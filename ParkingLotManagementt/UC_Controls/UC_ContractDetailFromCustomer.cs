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
    public partial class UC_ContractDetailFromCustomer : UserControl
    {
        private ContractDetail_DTO myContractDetail;
        private void SetContractDetail()
        {
            picVehicle.Image = (myContractDetail.Contract.MyVehical.Picture == null) ? picVehicle.Image : Image.FromStream(myContractDetail.Contract.MyVehical.Picture);
            lblNameOfService.Text = myContractDetail.Service.NameService;
            lblContractDetailID.Text = myContractDetail.Contract.ContractId;
            lblDescription.Text = myContractDetail.Service.Description;
            if (myContractDetail.Status == 0)
            {
                lblStatus.Text = "unfinished";
                picStatusContractDetail.Image = Resource1.folder;
            }
            else
            {
                lblStatus.Text = "done";
                picStatusContractDetail.Image = Resource1.correct;
            }
        }
        public UC_ContractDetailFromCustomer(ContractDetail_DTO contractDetail)
        {
            InitializeComponent();
            myContractDetail = contractDetail;
            SetContractDetail();
        }
    }
}
