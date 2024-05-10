using BUL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ParkingLotManagementt.Forms
{
    public partial class frmStaticContract : Form
    {
        private void LoadStaticContractType ()
        {
            // biểu đồ tròn thống kê số lượng contrat 
            chartTypeContract.Series["Contract Type "].Points.Clear();
            string[] typeContract = { "rent", "borrow", "maintenance", "wash" };
            chartTypeContract.Series["Contract Type "].Points.Clear();
            for (int i = 0; i < typeContract.Length; i++)
            {
                int contractCount = Contract_BUL.CountContractType(typeContract[i],cbMonthContractTypeGraph.SelectedIndex + 1);
                chartTypeContract.Series["Contract Type "].Points.AddXY(typeContract[i] + " (" + contractCount + ")", contractCount);
                chartTypeContract.Series["Contract Type "].Points[i].LegendText = typeContract[i];
                chartTypeContract.Series["Contract Type "].Points[i].Font = new Font("Microsoft YaHei UI", 8,FontStyle.Bold);
            }
        }
        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStaticContractType();
        }
        private void LoadStaticContractMonth(string criteria)
        {
            chartContract.Series["Month"].Points.Clear();
            string[] months = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };/*{"Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6",
                       "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"};*/
            chartContract.ChartAreas[0].AxisY.LabelStyle.Enabled = true;
            chartContract.ChartAreas[0].AxisY.Title = criteria;
            if (criteria != "Count Contract")
                chartContract.ChartAreas[0].AxisY.Title += " ($)";
            //chartParking.Series["Month"].Color = criteria == "Revenue" ? Color.Red : ColorTranslator.FromHtml("#74b9ff");
            //Revenue
            //Count Contract
            for (int i = 0; i < months.Length; i++)
            {
                if (criteria == "Count Contract")
                    chartContract.Series["Month"].Points.AddXY(months[i], Contract_BUL.CountContractMonth(i + 1));
                else
                {
                    chartContract.Series["Month"].Points.AddXY(months[i],Bill_BUL.RevenueBillMonth (i + 1));
                }   
            }
        }
        // các thống kê trên panel 
        private void LoadStaticCount ()
        {
            lblNumberContractFixAndWashing.Text = (Contract_BUL.CountContractType("maintenance", cbMonth.SelectedIndex + 1) + Contract_BUL.CountContractType("wash", cbMonth.SelectedIndex + 1)).ToString();
            lblNumberContractRentalAndBorrow.Text = (Contract_BUL.CountContractType("rent", cbMonth.SelectedIndex + 1) + Contract_BUL.CountContractType("borrow", cbMonth.SelectedIndex + 1)).ToString();
            lblRenuve.Text = Bill_BUL.RevenueBillMonth(cbMonth.SelectedIndex + 1) + " $";
        }
        int numberContractUnpair = 0;
        /// <summary>
        //
        /// </summary>
        /// <param name="month"></param>
        private void LoadContract (int month)
        {
            var contraclst = Contract_BUL.GetContract(new DateTime (DateTime.Now.Year,month,1));
            numberContractUnpair = 0;
            flowPnContract.Controls.Clear();
            foreach (var contract in contraclst)
            {
                if (contract.Status == 2)
                    numberContractUnpair++;
                flowPnContract.Controls.Add(new UC_Controls.UC_ContractForAdmin(contract));
            }
            lblNumberContractUnpair.Text = numberContractUnpair.ToString();
        }
        /// <summary>
        /// thống kê cho graph status
        /// </summary>
        private void LoadStatusContract ()
        {
            ChartStatusContract.Series["Contract Status"].Points.Clear();
            string[] contractStatus = {
                "Not Confirmed",
                "In Progress",
                "Waiting Payment",
                "Completed"
            };
            ChartStatusContract.ChartAreas[0].AxisY.LabelStyle.Enabled = true;
            ChartStatusContract.ChartAreas[0].AxisY.Title = "number of contracts in each state";
            //chartParking.Series["Month"].Color = criteria == "Revenue" ? Color.Red : ColorTranslator.FromHtml("#74b9ff");
            //Revenue
            //Count Contract
            for (int i = 0; i < contractStatus.Length; i++)
            {
                ChartStatusContract.Series["Contract Status"].Points.AddXY(contractStatus[i], Contract_BUL.CountContractStatus(i,cbContractStatusGraph.SelectedIndex + 1));
            }
        }
        public frmStaticContract()
        {
            InitializeComponent();
            LoadStaticContractType();
            LoadStaticContractMonth(cbCriteria.Text);
            LoadStaticCount();
            LoadContract (cbMonth.SelectedIndex + 1);
            LoadStatusContract();
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// code thanh panel trượt 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void pnTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void cbCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStaticContractMonth(cbCriteria.Text);
        }

        private void cbMonth_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LoadStaticCount();
            LoadContract (cbMonth.SelectedIndex + 1);
        }

        private void cbContractStatusGraph_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStatusContract();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            this.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

            // Hiển thị bitmap trong một hộp thoại xem trước khi in
            using (PrintDocument pd = new PrintDocument())
            {
                pd.PrintPage += (s, ev) =>
                {
                    // Tính tỷ lệ giữa kích thước của hình ảnh và kích thước của trang in
                    float scaleX = (float)ev.PageBounds.Width / bmp.Width;
                    float scaleY = (float)ev.PageBounds.Height / bmp.Height;
                    float scale = Math.Min(scaleX, scaleY);

                    // Tính toán kích thước mới của hình ảnh
                    int newWidth = (int)(bmp.Width * scale);
                    int newHeight = (int)(bmp.Height * scale);

                    // Tính toán vị trí cần vẽ để hình ảnh nằm giữa trang in
                    int x = (ev.PageBounds.Width - newWidth) / 2;
                    int y = (ev.PageBounds.Height - newHeight) / 2;

                    // Vẽ hình ảnh lên tài liệu in với kích thước mới và vị trí mới
                    ev.Graphics.DrawImage(bmp, x, y, newWidth, newHeight);
                };

                PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
                printPreviewDialog1.Document = pd;
                //
                printPreviewDialog1.ShowDialog();
            }
        }
    }
}
