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
    public partial class UC_ContractDetailPayMentForCustomer : UserControl
    {
        private ContractDetail_DTO contractDetail;
        public UC_ContractDetailPayMentForCustomer()
        {
            InitializeComponent();
        }
        public UC_ContractDetailPayMentForCustomer(ContractDetail_DTO contractDetail)
        {
            InitializeComponent();
            this.contractDetail = contractDetail;
            lblNameService.Text = contractDetail.Service.NameService + " :";
            lblPrice.Text = contractDetail.Service.Price + "$";
        }
    }
}
