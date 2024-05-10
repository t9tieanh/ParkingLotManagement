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
    public partial class UC_ParkAreaForAdmin : UserControl
    {
        private ParkArea_DTO myParkArea;
        private frmMain frmMain;
        private void SetMyParkArea()
        {
            lblIDPark.Text = myParkArea.ParkAreaId;
            lblAddress.Text = myParkArea.Address;
        }
        public UC_ParkAreaForAdmin (ParkArea_DTO myParkArea, frmMain frmMain)
        {
            InitializeComponent();
            this.myParkArea = myParkArea;
            this.frmMain = frmMain;
            SetMyParkArea();
        }
        public UC_ParkAreaForAdmin()
        {
            InitializeComponent();
        }

        private void btnChoosePark_Click(object sender, EventArgs e)
        {
            this.frmMain.Hide();
            new frmViewDetailParkAreaForAdmin(frmMain.manager,myParkArea).ShowDialog();
            this.frmMain.LoadData();
            this.frmMain.Show();
        }
    }
}
