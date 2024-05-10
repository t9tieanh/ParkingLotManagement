using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace ParkingLotManagementt.Forms
{
    public partial class frmService : Form
    {
        private string type;
        private List<Service_DTO> service_Selected = new List<Service_DTO> ();

        public List<Service_DTO> Service_Selected { get => service_Selected; set => service_Selected = value; }

        private void loadService ()
        {
            List<Service_DTO> service_Baotri = BUL.Service_BUL.GetService(type, "maintenance");
            service_Baotri.AddRange(BUL.Service_BUL.GetService(type, "wash"));
            //lấy các service rent 
            List<Service_DTO> service_ThueMuon = BUL.Service_BUL.GetService(type, "rent");
            flowServiceForCar.Controls.Clear ();
            foreach (var service in service_Baotri)
            {
                flowServiceForCar.Controls.Add(new UC_Controls.UC_ServiceForCustomer(service));
            }
            cbServiceRent.DataSource = service_ThueMuon;
            cbServiceRent.DisplayMember = "nameService";
        }
        public frmService()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        public frmService(string type)
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.type = type;
            loadService ();
            // tắt chọn service rent 
            cbServiceRent.Enabled = false;
            pnRentService.Enabled = false;
            //
        }
        private void cbServiceRent_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectCb = cbServiceRent.SelectedValue;
            pnRentService.Controls.Clear();
            pnRentService.Controls.Add(new UC_Controls.UC_ServiceRentCar((Service_DTO)selectCb));
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
        private void pnTop_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        #endregion

        private void btnApply_Click(object sender, EventArgs e)
        {
            Service_Selected.Clear();
            if (ToggleSwitchRent.Checked)
                service_Selected.Add((Service_DTO)cbServiceRent.SelectedValue);
            else
            {
                foreach (UC_Controls.UC_ServiceForCustomer control in flowServiceForCar.Controls)
                {
                    if (control.Checked())
                    {
                        Service_Selected.Add(control.MyService);
                    }
                }
            }
            // thông báo 
            if (service_Selected.Count == 0)
                lblNotice.Text = "You have not selected any service yet !";
            else
                lblNotice.Text = "Saved service selection successfully!";
        }

        private void ToggleSwitchRent_CheckedChanged(object sender, EventArgs e)
        {
            cbServiceRent.Enabled  = ToggleSwitchRent.Checked;
            pnRentService.Enabled = ToggleSwitchRent.Checked;
            flowServiceForCar.Enabled = !ToggleSwitchRent.Checked;
        }
    }
}
