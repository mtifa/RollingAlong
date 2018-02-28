using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;
using Rollin__Along.Data_classes;

namespace Rollin__Along.Entry_and_inventory_managment
{
    public partial class FrmPictures : Form
    {
        User User;
        public int BicId { get; set; }
        public string fullName;
        public byte[] buffer;
        public string PicturePostResponse { get; set; }
        public string PictureId { get; set; }
        public Bicycle_pictures imageObj { get; set; }
        public FrmPictures(User a, int bicId)
        {
            InitializeComponent();
            User = a;

            BicId = bicId;

            toolStripStatusLabel1.Text += User.Name;
            toolStripStatusLabel2.Text += BicId;

            GetImagesId();
        }

        struct FtpSetting
        {
            public string FileName { get; set; }
            public string FullName { get; set; }
        }

        FtpSetting input;

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "Image files (*.jpg) | *.jpg" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fi = new FileInfo(ofd.FileName);
                    input.FileName = BicId + ".jpg";
                    input.FullName = BicId + ".jpg";
                    fullName = fi.FullName;

                    backgroundWorker.RunWorkerAsync(input);

                    txtImgName.Text = ofd.FileName;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void GetImageById()
        {
            var restClient = new RestClient("http://marichely.me:8099/");
            var restRequest = new RestRequest("bicycle/picture/id", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            restRequest.AddHeader("Content-Type", "image/jpeg");
            restRequest.AddHeader("UserApiKey", User.ApiKey);
            restRequest.AddHeader("imageid", PictureId);
            restRequest.AlwaysMultipartFormData = true;
            IRestResponse restResponse = restClient.Execute(restRequest);
            restResponse.ContentType = "image/jpeg";
            restResponse.ContentLength = 1000000;
            restResponse.Headers[0].Value = 1000000;
            if ((int)restResponse.StatusCode == 200)
            {
                using (var ms = new MemoryStream(restResponse.RawBytes))
                {
                    Image image = Image.FromStream(ms);
                    pictureBox1.Invoke(new MethodInvoker(delegate ()
                    {
                        pictureBox1.Image = image;
                        pictureBox1.Refresh();
                    }));
                }
            }
        }
        private void GetImagesId()
        {
            var restClient = new RestClient("http://marichely.me:8099/");
            var restRequest = new RestRequest("bicycle/picture/id/all", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            restRequest.AddHeader("UserApiKey", User.ApiKey);
            restRequest.AddHeader("bicycleid", BicId.ToString());
            IRestResponse restResponse = restClient.Execute(restRequest);
            if ((int)restResponse.StatusCode == 200)
            {
                imageObj = JsonConvert.DeserializeObject<Bicycle_pictures>(restResponse.Content);
                var pictureIDs = imageObj.PictureIds;
            }
            
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            FileStream fs = File.OpenRead(fullName);
            buffer = new byte[1000000];
            double total = (double)fs.Length;
            int byteRead = 0;
            double read = 0;
            do
            {
                if(!backgroundWorker.CancellationPending)
                {
                    byteRead = fs.Read(buffer, 0, 1000000);
                    read += (double)byteRead;
                    double percentage = read / total * 100;
                    backgroundWorker.ReportProgress((int)percentage);
                } 
            }
            while (byteRead != 0);
            fs.Close();

            PostPicture();
            GetImageById();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatus.Text = $"Uploaded {e.ProgressPercentage}%";
            progressBar.Value = e.ProgressPercentage;
            progressBar.Update();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.Text = "Upload complete!";
            MessageBox.Show("You sucessfully uploaded a picture for selected bicycle!");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmLogin frmPrijava = new FrmLogin();
            frmPrijava.ShowDialog();
        }

        private void btnMeinMenu_Click(object sender, EventArgs e)
        {
            FrmMainMenu frmMainMenu = new FrmMainMenu(User);
            frmMainMenu.Show();
            this.Hide();
        }

        private void btnBicycles_Click(object sender, EventArgs e)
        {
            FrmBicycles frmBicycles = new FrmBicycles(User);
            frmBicycles.Show();
            this.Hide();
        }

        private void btnEqu_Click(object sender, EventArgs e)
        {
            FrmEquipment frmEquipment = new FrmEquipment(User);
            frmEquipment.Show();
            this.Hide();
        }
        public void PostPicture()
        {
            var restClient = new RestClient("http://marichely.me:8099/");
            var restRequest = new RestRequest("bicycle/picture", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            restRequest.AddHeader("UserApiKey", User.ApiKey);
            restRequest.AddHeader("bicycleid", BicId.ToString());
            restRequest.AddFileBytes("slika", buffer, fullName, "image/jpeg");
            restRequest.AddHeader("Content-Type", "multipart/form-data;");
            restRequest.AlwaysMultipartFormData = true;

            IRestResponse restResponse = restClient.Execute(restRequest);
            if ((int)restResponse.StatusCode == 200)
            {
                PicturePostResponse = restResponse.Content;
                PictureId = PicturePostResponse.Substring(38);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to DELETE a image of bicycle?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var restClient = new RestClient("http://marichely.me:8099/");
                var restRequest = new RestRequest("bicycle/picture/id", Method.DELETE)
                {
                    RequestFormat = DataFormat.Json
                };
                restRequest.AddHeader("UserApiKey", User.ApiKey);
                restRequest.AddHeader("imageid", PictureId.ToString());

                IRestResponse restResponse = restClient.Execute(restRequest);
                if ((int)restResponse.StatusCode == 200)
                {
                    MessageBox.Show("You 're sucessfully deleted image!");
                }
            }
        }
    }
}
