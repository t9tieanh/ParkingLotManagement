using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace ParkingLotManagementt.Forms
{
    public partial class frmDetailWorker : Form
    {
        #region 
        private Worker_DTO myWorker;
        private bool checkInput ()
        {
            return true;
        }
        public Worker_DTO MyWorker { get => myWorker; set => myWorker = value; }
        private void LoadcbGetParkingArea()
        {
            var parkAreaLst = BUL.ParkArea_BUL.GetParkArea();
            cbGetParkingArea.DataSource = parkAreaLst;
            cbGetParkingArea.DisplayMember = "Address";
        }

        public frmDetailWorker(Worker_DTO myWorker)
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            MyWorker = myWorker;

            txtIDWorker.Enabled = true;
            picAdd.Visible = false;
            picChange.Visible = true;
            picDelete.Visible = true;

            LoadcbGetParkingArea();
            SetWorker();
        }
        public frmDetailWorker()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            picAdd.Visible = true;
            picChange.Visible = false;
            picDelete.Visible = false;

            LoadcbGetParkingArea();
        }
        /// <summary>
        /// set thông tin cho form worker 
        /// </summary>
        private void SetWorker ()
        {
            txtIDWorker.Text = MyWorker.WorkerId;
            txtFullNameWorker.Text = MyWorker.FullName;
            cbGetParkingArea.Text = MyWorker.ParkArea.Address;
            picAvatar.Image = Image.FromStream(MyWorker.Picture);
            txtAddressWorker.Text = MyWorker.Address;
            if (MyWorker.Type.Trim() == "Lock")
                rbtnLookAfter.Checked = true;
            else if (MyWorker.Type.Trim() == "Repair") 
                rbtnRepair.Checked = true;
            else 
                rbtnWashing.Checked = true;
        }
        private void GetWorker ()
        {
            string typeWorker ;
            if (rbtnLookAfter.Checked) typeWorker = rbtnLookAfter.Text;
            else if (rbtnRepair.Checked) typeWorker = rbtnRepair.Text;
            else typeWorker = rbtnWashing.Text;

            MemoryStream picWorker = new MemoryStream();
            picAvatar.Image.Save(picWorker, picAvatar.Image.RawFormat);

            MyWorker = new Worker_DTO(txtIDWorker.Text, txtFullNameWorker.Text, txtAddressWorker.Text, picWorker, typeWorker,(ParkArea_DTO)cbGetParkingArea.SelectedValue);
        }

        #region Code cho phần thêm worker
        private void picAdd_Click(object sender, EventArgs e)
        {
            GetWorker();
            if (Worker_BUL.InsertWorker(myWorker))
                lblNotice.Text = "Insert " + myWorker.ToString() + " successfully!";
            else
                lblNotice.Text = "Insert " + myWorker.ToString() + " failed!";
        }
        #endregion 


        private void picDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác nhận xóa " + txtIDWorker.Text.Trim() + " ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;
            if (BUL.Worker_BUL.DeleteWorker(txtIDWorker.Text.Trim()))
            {
                MessageBox.Show("Delete" + txtIDWorker.Text + " successfully!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                lblNotice.Text = "Delete " + txtIDWorker.Text + " failed! ";
        }

        private void picChange_Click(object sender, EventArgs e)
        {
            GetWorker();
            if (Worker_BUL.UpdateWorker(myWorker))
                lblNotice.Text = "Update " + myWorker.ToString() + " successfully!";
            else
                lblNotice.Text = "Update " + myWorker.ToString() + " failed!";
        }

        #endregion


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

        private void frmProfileWorker_Load(object sender, EventArgs e)
        {

        }

        private void picExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        private void btnImportImage_Click(object sender, EventArgs e)
        {

        }

        private void pnTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnBottom_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblNotice_Click(object sender, EventArgs e)
        {

        }

        private void lblType_Click(object sender, EventArgs e)
        {

        }

        private void lblPartArea_Click(object sender, EventArgs e)
        {

        }

        private void lblAddress_Click(object sender, EventArgs e)
        {

        }

        private void lblFullName_Click(object sender, EventArgs e)
        {

        }

        private void lblIDWorker_Click(object sender, EventArgs e)
        {

        }

        private void txtAddressWorker_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbGetParkingArea_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pnTypeWorker_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rbtnWashing_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtnRepair_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtnLookAfter_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtFullNameWorker_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIDWorker_TextChanged(object sender, EventArgs e)
        {

        }

        private void picAvatar_Click(object sender, EventArgs e)
        {

        }

        private void picMaximize_Click(object sender, EventArgs e)
        {

        }

        private void picMinimize_Click(object sender, EventArgs e)
        {

        }
    }
}