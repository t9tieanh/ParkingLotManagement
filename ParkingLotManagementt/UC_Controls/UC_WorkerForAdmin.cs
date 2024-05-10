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
    public partial class UC_WorkerForAdmin : UserControl
    {
        private DTO.Worker_DTO myWorker;
        private void SetWorker()
        {
            if (myWorker != null)
            {
                lblIDWorker.Text = myWorker.WorkerId;
                lblFullNameWorker.Text = myWorker.FullName;
                lblType.Text = myWorker.Type;
                lblAddressWorker.Text = myWorker.Address;
                picAvatarWorker.Image = myWorker.Picture != null ? Image.FromStream(myWorker.Picture) : picAvatarWorker.Image;
            }
        }
        public UC_WorkerForAdmin(DTO.Worker_DTO myWorker)
        {
            InitializeComponent();
            this.myWorker = myWorker;
            if (myWorker.Status == false)
                picShowInfoWorker.Visible = false;
            SetWorker();
        }
        public UC_WorkerForAdmin()
        {
            InitializeComponent();
        }
        private void picShowInfoWorker_Click(object sender, EventArgs e)
        {
            var detailWorker = new frmProfileWorker(myWorker);
            detailWorker.ShowDialog();
        }

        private void picShowInfoWorker_Click_1(object sender, EventArgs e)
        {
            var detailWorker = new frmProfileWorker(myWorker);
            detailWorker.ShowDialog();
        }
    }
}
