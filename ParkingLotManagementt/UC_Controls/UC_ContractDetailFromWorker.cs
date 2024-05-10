using DTO;
using ParkingLotManagementt.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingLotManagementt.UC_Controls
{
    public partial class UC_ContractDetailFromWorker : UserControl
    {
        private frmMainWorker frmMainWorker;
        private ContractDetail_DTO myContractDetail;
        private void SetContractDetail ()
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
        public UC_ContractDetailFromWorker()
        {
            InitializeComponent();
        }
        public UC_ContractDetailFromWorker(ContractDetail_DTO contractDetail,frmMainWorker mainWorker)
        {
            InitializeComponent();
            this.myContractDetail = contractDetail;
            frmMainWorker = mainWorker;
            SetContractDetail();
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

        private void btnPreview_Click(object sender, EventArgs e)
        {
            frmMainWorker.LoadDataContractDetail(myContractDetail);
        }
    }
}
