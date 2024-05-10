using AForge.Imaging.Filters;
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

namespace ParkingLotManagementt
{
    public partial class frmServiceDetail : Form
    {
        private Service_DTO myService; 
        private void SetMyService ()
        {
            txtIDService.Text = myService.ServiceId;
            txtNameService.Text = myService.NameService;
            txtPrice.Text = myService.Price.ToString();
            cbType.Text = myService.Type;
            cbTypeVehicle.Text = myService.TypeVehical;
            txtTime.Text = myService.Time.ToString();
            txtDescription.Text = myService.Description;
        }
        public frmServiceDetail()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
        }
        public frmServiceDetail(Service_DTO service)
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.myService = service;   
            SetMyService();

            txtIDService.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnInsert.Visible = false;
            txtNameService.Enabled = false;
            cbType.Enabled = false;
            cbTypeVehicle.Enabled = false;
        }

        #region Code giao diện 
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
        private void picClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
        private bool CheckInfoService()
        {
            error.Clear();
            bool kq = true;
            if (!InputCheck.CheckInput.Name(txtIDService.Text))
            {
                error.SetError(txtIDService, "Invalid Id service!");
                kq = false;
            }
            if (!InputCheck.CheckInput.Name(txtNameService.Text))
            {
                error.SetError(txtNameService, "Invalid name service!");
                kq = false;
            }
            if (!InputCheck.CheckInput.IsDouble(txtPrice.Text))
            {
                error.SetError(txtPrice, "Invalid price service!");
                kq = false;
            }
            if (!InputCheck.CheckInput.IsInteger(txtTime.Text))
            {
                error.SetError(txtTime, "Invalid time service!");
                kq = false;
            }
            return kq;
        }
        private void GetService ()
        {
            myService = new Service_DTO(txtIDService.Text,txtNameService.Text,
                txtDescription.Text,Convert.ToDouble(txtPrice.Text),
                cbType.Text,cbTypeVehicle.Text,Convert.ToInt32(txtTime.Text));
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!CheckInfoService()) return;
            GetService();
            if (BUL.Service_BUL.InsertService(myService))
            {
                MessageBox.Show ($"Service Insert {myService} successful!","Notice",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2);
                Close();
            }
            else lblNotice.Text = $"Service Insert {myService} failed!";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!CheckInfoService()) return;
            GetService();
            if (BUL.Service_BUL.UpdateService(myService))
                lblNotice.Text = $"Service update {myService} successful!";
            else lblNotice.Text = $"Service update {myService} failed!";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!CheckInfoService()) return;
            GetService();
            if (BUL.Service_BUL.DeleteService(myService))
            {
                MessageBox.Show($"Service Deleted {myService} successful!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                Close();
            }
            else lblNotice.Text = $"Service update {myService} failed!";
        }

        private void cbTypeVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTypeVehicle.Text == "Moto") picTypeCar.Image = Resource1.motorcycle;
            else if (cbTypeVehicle.Text == "Car") picTypeCar.Image = Resource1.car;
            else picTypeCar.Image = picTypeCar.Image = Resource1.bicycle;
        }
        private int ConvertHours(int number, string type)
        {
            switch (type)
            {
                case "Day":
                    return number * 24;
                case "Week":
                    return number * 24 * 7;
                case "Month":
                    return number * 24 * 30; // Cân nhắc sử dụng thư viện để tính chính xác hơn
                case "Year":
                    return number * 24 * 365; // Cân nhắc sử dụng 366 cho năm nhuận
                default:
                    throw new ArgumentException("Invalid type. Only 'Day', 'Week', 'Month', and 'Year' are supported.");
            }
        }

        private void cbChooseDayMonthYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            int number = 0;
            try
            {
                number = Convert.ToInt32(txtNumberDayMonthYear.Text);
            }
            catch {
                error.SetError(txtNumberDayMonthYear, "value not valid !");
                txtTime.Text = "Number " + cbChooseDayMonthYear.Text + " Not Valid !";
                return;
            }
            txtTime.Text = ConvertHours(number, cbChooseDayMonthYear.Text) + "";
        }

        private void txtNumberDayMonthYear_TextChanged(object sender, EventArgs e)
        {
            int number = 0;
            try
            {
                number = Convert.ToInt32(txtNumberDayMonthYear.Text);
            }
            catch
            {
                error.SetError(txtNumberDayMonthYear, "value not valid !");
                txtTime.Text = "Number " + cbChooseDayMonthYear.Text + " Not Valid !";
                return;
            }
            txtTime.Text = ConvertHours(number, cbChooseDayMonthYear.Text) + "";
        }
    }
}
