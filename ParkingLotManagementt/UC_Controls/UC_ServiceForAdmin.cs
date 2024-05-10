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
    public partial class UC_ServiceForAdmin : UserControl
    {
        private Service_DTO myService;
        private frmMain frmMain;
        private void SetMyService ()
        {
            lblName.Text = myService.NameService;
            lblServiceID.Text = myService.ServiceId;
            lblPrice.Text = myService.Price.ToString();
            if (myService.TypeVehical == "Moto") picTypeCar.Image = Resource1.motorcycle;
            else if (myService.TypeVehical == "Car") picTypeCar.Image = picTypeCar.Image;
            else picTypeCar.Image = picTypeCar.Image = Resource1.bicycle;
        }
        public UC_ServiceForAdmin()
        {
            InitializeComponent();
        }
        public UC_ServiceForAdmin (Service_DTO service, frmMain frmMain)
        {
            InitializeComponent();
            myService = service;
            this.frmMain = frmMain;
            SetMyService ();
        }
        #region Click lay thong tin cua toan bo detail service

        // Mày tự load dữ liệu dô form đi, tạo đối tượng Service rồi load dô form
        // Lấy cái id của cái service mà admin muốn chỉnh (idOfService) này, xong rồi
        // viết câu truy vấn lấy ra toàn bộ thông tin của nó rồi đưa vào đối tượng
        // trả qua cho form

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            new frmServiceDetail(this.myService).ShowDialog();
            frmMain.LoadData();
        }

        #endregion
    }
}
