using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniExcelLibs;
using MiniExcelLibs.OpenXml;
using MiniSoftware;
using System.Diagnostics;
using Newtonsoft.Json;
using ParkingLotManagementt.Setup;
using System.Net;
using System.IO;
using RestSharp;
using System.Text.RegularExpressions;
namespace ParkingLotManagementt.Forms
{
    public partial class frmPayMentForCustomer : Form
    {
        private Contract_DTO contract;
        private Bill_DTO myBill;
        double total = 0;
        private void SetInformation ()
        {
            txtCustomerID.Text = contract.Customer.CustomerId;
            txtFullname.Text = contract.Customer.FullName;
            txtPayDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtContractId.Text = contract.ContractId;
            flowPnContractDetail.Controls.Clear();
            foreach (var contractDetail in contract.MyContractDetail)
            {
                flowPnContractDetail.Controls.Add(new UC_Controls.UC_ContractDetailPayMentForCustomer(contractDetail));
                total += contractDetail.Service.Price;
            }
            lblPriceTotal.Text = total + "$";
        }
        public frmPayMentForCustomer()
        {
            InitializeComponent();

            // Tạo luôn qr thanh toán
            GetQRCode();
        }
        public frmPayMentForCustomer(Contract_DTO contract)
        {
            InitializeComponent();
            this.contract = contract;
            SetInformation();

            // Tạo luôn qr thanh toán
            GetQRCode();

            if (contract.MyContractDetail[0].Service.Type == "rent")
            {
                myBill = new Bill_DTO(contract, DateTime.Now, total * -1);
                btnPayment.Text = "Confirm receipt of money";
            }
            else myBill = new Bill_DTO(contract, DateTime.Now, total);
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region code cho thanh trượt 
        private void pnInfomationContract_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        #endregion

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (!BUL.Contract_BUL.ContractPayment(contract,myBill))
            {
                lblNotice.Text = "(system error) payment has not been successful!";
            }
            else
            {
                MessageBox.Show("Payment success! , thank you for using the service at our garage, see you again", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                DialogResult dialogResult = MessageBox.Show("Do you want to print invoice ?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    PrintReceip();
                }
                this.Close ();
            }
        }
        public string PATH_TEMPLATE = Application.StartupPath + "\\Template\\payTemplate.docx"; /*Application.StartupPath + "\\mauword.docx"*/
        public string PATH_EXPORT = Application.StartupPath + "\\export.docx";
        private void PrintReceip ()
        {
            List<Service_DTO> services = contract.MyContractDetail.Select(cd => cd.Service).ToList();
            var data = contract.MyContractDetail.Select(cd => cd.Service).ToList().ToArray();
            var config = new OpenXmlConfiguration()
            {
                IgnoreTemplateParameterMissing = false,
            };

            //var total = data.Sum(x => x.thanhtien);

            var value = new
            {
                Service_DTO = data,
                ContractId = contract.ContractId,
                CustomerName = contract.Customer.FullName,
                VehicleId = contract.MyVehical.VehicalId,
                VehicleType = contract.MyVehical.Type,
                payday = myBill.PayDate.ToString("yyyy-MM-dd"),
                //CustomerIdd = contract.Customer.CustomerId,
                price = total.ToString() ,
            };

            MiniWord.SaveAsByTemplate(PATH_EXPORT, PATH_TEMPLATE, value);

            Process.Start(PATH_EXPORT);
        }


        #region Phần code cho QR thanh toán

        // Hàm chuyển đổi sang giá trị tiền Việt (Ngân hàng có thể thanh toán)
        private int ConvertMoney(string usd)
        {
            // Tỷ giá hối đoái từ USD sang VND
            double exchangeRate = 24000;
            
            // Tách ký tự chỉ lấy số
            int amountUSD = int.Parse(Regex.Match(usd, @"\d+").Value);
            return (int)(amountUSD * exchangeRate);
        }

        // Hàm chuyển đổi từ base64 sang image để nhận QR
        private Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        // Hàm lấy QR
        private void GetQRCode()
        {
            API_Request apiRequest = new API_Request();
            apiRequest.acqId = 970436;
            apiRequest.accountNo = 1027248713;
            apiRequest.accountName = "NGUYEN CONG QUY";

            // Lấy số tiền sau khi quy đổi
            int price = ConvertMoney(lblPriceTotal.Text);
            apiRequest.amount = price;
            apiRequest.format = "text";
            apiRequest.template = "compact2";

            var jsonRequest = JsonConvert.SerializeObject(apiRequest);

            var client = new RestClient("https://api.vietqr.io/v2/generate");
            var request = new RestRequest();

            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);
            var response = client.Execute(request);

            var content = response.Content;
            var dataResponse = JsonConvert.DeserializeObject<API_Response>(content);

            var bakingImage = Base64ToImage(dataResponse.data.qrDataURL.Replace("data:image/png;base64,", ""));
            picQR.Image = bakingImage;
        }

        #endregion

        private void frmPayMentForCustomer_Load(object sender, EventArgs e)
        {
            // Đoạn code lấy ra tất cả các thông tin của toàn bộ Ngân hàng ở VietNam (Không cần dùng đến)

            //using (WebClient client = new WebClient())
            //{
            //    var htmlData = client.DownloadData("https://api.vietqr.io/v2/banks");
            //    var bankRawJson = Encoding.UTF8.GetString(htmlData);

            //    var listBanking = JsonConvert.DeserializeObject<Bank>(bankRawJson);
            //}
        }
    }
}
