using AForge.Vision.Motion;
using Emgu.CV.VideoSurveillance;
using Guna.UI2.WinForms;
using Newtonsoft.Json;
using ParkingLotManagementt.Setup;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using ZXing;
using System.Threading;
using System.Media;


namespace ParkingLotManagementt.Forms
{
    public partial class TestLicense : Form
    {
        public TestLicense()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            API_Request apiRequest = new API_Request();
            apiRequest.acqId = 970436;
            apiRequest.accountNo = 1027248977;
            apiRequest.accountName = "HUYNH MY HUYEN";
            apiRequest.amount = Convert.ToInt32(txtPrice.Text);
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

        public Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        CancellationTokenSource cancellationToken;

        private void TestLicense_Load(object sender, EventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                var htmlData = client.DownloadData("https://api.vietqr.io/v2/banks");
                var bankRawJson = Encoding.UTF8.GetString(htmlData);

                var listBanking = JsonConvert.DeserializeObject<Bank>(bankRawJson);

                dgvData.DataSource = listBanking.data;
            }
        }
        
        public void onStartScan(CancellationToken sourcetoken)
        {
            Task.Factory.StartNew(new Action(() =>
            {
                while (true)
                {
                    if (sourcetoken.IsCancellationRequested)
                    {
                        return;
                    }
                    Thread.Sleep(50);
                    BarcodeReader Reader = new BarcodeReader();
                    picQR.BeginInvoke(new Action(() =>
                    {
                        if (picQR.Image != null)
                        {
                            try
                            {
                                var results = Reader.DecodeMultiple((Bitmap)picQR.Image);
                                if (results != null)
                                {
                                    foreach (Result result in results)
                                    {
                                        txtPrice.Text = result.ToString() + $"- Type: {result.BarcodeFormat.ToString()}";

                                        SystemSounds.Beep.Play();
                                        if (result.ResultPoints.Length > 0)
                                        {
                                            var offsetX = picQR.SizeMode == PictureBoxSizeMode.Zoom
                                               ? (picQR.Width - picQR.Image.Width) / 2 :
                                               0;
                                            var offsetY = picQR.SizeMode == PictureBoxSizeMode.Zoom
                                               ? (picQR.Height - picQR.Image.Height) / 2 :
                                               0;
                                            var rect = new Rectangle((int)result.ResultPoints[0].X + offsetX, (int)result.ResultPoints[0].Y + offsetY, 1, 1);
                                            foreach (var point in result.ResultPoints)
                                            {
                                                if (point.X + offsetX < rect.Left)
                                                    rect = new Rectangle((int)point.X + offsetX, rect.Y, rect.Width + rect.X - (int)point.X - offsetX, rect.Height);
                                                if (point.X + offsetX > rect.Right)
                                                    rect = new Rectangle(rect.X, rect.Y, rect.Width + (int)point.X - (rect.X - offsetX), rect.Height);
                                                if (point.Y + offsetY < rect.Top)
                                                    rect = new Rectangle(rect.X, (int)point.Y + offsetY, rect.Width, rect.Height + rect.Y - (int)point.Y - offsetY);
                                                if (point.Y + offsetY > rect.Bottom)
                                                    rect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height + (int)point.Y - (rect.Y - offsetY));
                                            }
                                            using (var g = picQR.CreateGraphics())
                                            {
                                                using (Pen pen = new Pen(Color.Green, 5))
                                                {
                                                    g.DrawRectangle(pen, rect);

                                                    pen.Color = Color.Yellow;
                                                    pen.DashPattern = new float[] { 5, 5 };
                                                    g.DrawRectangle(pen, rect);
                                                }
                                                g.DrawString(result.ToString(), new Font("Tahoma", 16f), Brushes.Blue, new Point(rect.X - 60, rect.Y - 50));
                                            }
                                        }

                                    }

                                }
                            }
                            catch (Exception)
                            {
                            }
                        }

                    }));

                }
            }), sourcetoken);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            cancellationToken = new CancellationTokenSource();
            var sourcetoken = cancellationToken.Token;
            onStartScan(sourcetoken);
        }
    }
}
