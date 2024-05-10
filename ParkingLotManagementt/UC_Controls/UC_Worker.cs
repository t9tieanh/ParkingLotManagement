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

namespace ParkingLotManagementt.UC_Controls
{
    public partial class UC_Worker : UserControl
    {
        #region Này mới nghe

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


        private DTO.Worker_DTO myWorker;
        public UC_Worker()
        {
            InitializeComponent();
        }
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


        public UC_Worker(DTO.Worker_DTO myWorker)
        {
            InitializeComponent();
            this.myWorker = myWorker;
            if (myWorker.Status == false)
                btnPreview.Visible = false;
            SetWorker();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            var detailWorker = new frmProfileWorker(myWorker);
            detailWorker.ShowDialog();
        }
    }
}
