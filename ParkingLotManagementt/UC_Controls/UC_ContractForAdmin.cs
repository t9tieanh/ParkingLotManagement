using DTO;
using ParkingLotManagementt.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ParkingLotManagementt.UC_Controls
{
    public partial class UC_ContractForAdmin : UserControl
    {
        private Contract_DTO myContract;
        private void setContract ()
        {
            lblIdContract.Text = myContract.ContractId;
            lblNameCustomer.Text = myContract.Customer.FullName;
            lblIdentificationOfCar.Text = myContract.MyVehical.VehicalId;
            //picCustomer.Image = Image.FromStream(myContract.Customer.Picture);
            picCustomer.Image = myContract.Customer.Picture != null ? Image.FromStream(myContract.Customer.Picture) : picCustomer.Image;
            lblDeadline.Text = myContract.DeliveryDate.ToString("dd/MM/yyyy");
            lblType.Text = myContract.StatusToString();

            processSpeed.Value = (int)((double)(myContract.Status / 3.0) * 100);
            lblValue.Text = processSpeed.Value.ToString() + "%";

            foreach (var contractDetil in myContract.MyContractDetail)
            {
                lblDetail.Text += contractDetil.Service.NameService + ", ";
            }
         
            processSpeed.ProgressColor = ColorTranslator.FromHtml(myContract.StatusToColor()); // Màu nền
            processSpeed.ProgressColor2 = ColorTranslator.FromHtml(myContract.StatusToColor()); // Màu tiến trình
            //"#fab1a0"ColorTranslator.FromHtml(#fab1a0)
        }
        public UC_ContractForAdmin()
        {
            InitializeComponent();
        }
        public UC_ContractForAdmin(Contract_DTO myContract)
        {
            InitializeComponent();
            this.myContract = myContract;
            setContract();
        }

        #region Design

        private int radius = 20;
        [DefaultValue(20)]
        public int Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                this.RecreateRegion();
            }
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private GraphicsPath GetRoundRectagle(Rectangle bounds, int radius)
        {
            float r = radius;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(bounds.Left, bounds.Top, r, r, 180, 90);
            path.AddArc(bounds.Right - r, bounds.Top, r, r, 270, 90);
            path.AddArc(bounds.Right - r, bounds.Bottom - r, r, r, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - r, r, r, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void RecreateRegion()
        {
            var bounds = ClientRectangle;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(bounds.Left, bounds.Top,
                bounds.Right, bounds.Bottom, Radius, radius));
            this.Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.RecreateRegion();
        }



        #endregion

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            new frmContractDetail(myContract).ShowDialog();
        }
    }
}
