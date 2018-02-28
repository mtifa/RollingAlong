using Newtonsoft.Json;
using RestSharp;
using Rollin__Along.Data_classes;
using Rollin__Along.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rollin__Along.Incidents_managing
{
    public partial class FrmIncidents : Form
    {
        User korisnik;
        FrmMainMenu menu;
        public FrmIncidents(FrmMainMenu a, User b)
        {
            InitializeComponent();
            menu = a;
            korisnik = b;
            userLab.Text = "User: " + b.Username;
            OsvjeziDGV();

            List<Status> lista = new List<Status>();
            Status unos = new Status();
            unos.ID = 1;
            unos.Ime = "Resolved";
            lista.Add(unos);
            Status unos1 = new Status();
            unos1.ID = 2;
            unos1.Ime = "In proccess";
            lista.Add(unos1);
            Status unos2 = new Status();
            unos2.ID = 3;
            unos2.Ime = "Pending";
            Status unos3 = new Status();
            lista.Add(unos2);
            comboStatus.Items.Add(unos);
            comboStatus.Items.Add(unos2);
            comboStatus.Items.Add(unos1);
        }


        private void btnGetImage_Click(object sender, EventArgs e)
        {

        }

        private bool PostaviSliku(PictureBox a, string url,Size b)
        {
            var request = WebRequest.Create(url);
            try
            {
                using (var response = request.GetResponse())
                {
                    HttpWebResponse c = (HttpWebResponse)response;
                    if (c.StatusCode == System.Net.HttpStatusCode.OK)
                        using (var stream = response.GetResponseStream())
                        {
                            Image slika = Bitmap.FromStream(stream);

                            pboxIncidentSlika.Image = new Bitmap(slika, b);
                        }
                    else
                    {
                        pboxIncidentSlika.Image = Image.FromFile("../slike/placeholder.png");
                    }
                }
            }catch(Exception e)
            {
                pboxIncidentSlika.Image = Properties.Resources.placeholder;
            }
            return true;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            menu.Show();
            this.Dispose();
        }

        private void OsvjeziDGV()
        {
            var klijent = new RestClient("http://marichely.me:8099/");
            var zahtjev = new RestRequest("issues", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };

            zahtjev.AddHeader("userapikey", korisnik.ApiKey);
            IRestResponse odgovor = klijent.Execute(zahtjev);
            if ((int)odgovor.StatusCode == 200)
            {
                List<Issue> problemi = JsonConvert.DeserializeObject<List<Issue>>(odgovor.Content);
                SortableBindingList<Issue> sortableBindingList = new SortableBindingList<Issue>(problemi);
                dgvIncidenti.DataSource = sortableBindingList;

            }
            dgvIncidenti.Refresh();
            dgvIncidenti.Update();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            OsvjeziDGV();

        }

        private void btnPromjeniStatus_Click(object sender, EventArgs e)
        {
            var klijent = new RestClient("http://marichely.me:8099");
            var zahtjev = new RestRequest("/issue", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };

            zahtjev.AddHeader("userapikey", korisnik.ApiKey);
            Issue a = (Issue)dgvIncidenti.CurrentRow.DataBoundItem;
            Status c = (Status)comboStatus.SelectedItem;
            a.State = c.ID;
            string tijelo = JsonConvert.SerializeObject(a);
            zahtjev.AddParameter("text/json", tijelo, ParameterType.RequestBody);
            IRestResponse odgovor = klijent.Execute(zahtjev);
            if ((int)odgovor.StatusCode == 200)
            {
                OsvjeziDGV();
            }
        }

        private void dgvIncidenti_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvIncidenti.CurrentRow != null)
            {
                Issue a = (Issue)dgvIncidenti.CurrentRow.DataBoundItem;
                Status stat = new Status();
                if (a != null)
                {
                    stat.ID = a.State;
                    switch (stat.ID)
                    {
                        case 1: stat.Ime = "Resolved (1)"; break;
                        case 2: stat.Ime = "In proccess (2)"; break;
                        case 3: stat.Ime = "Pending (3)"; break;
                        case 0: stat.Ime = "Not set (0)"; break;
                    }
                    comboStatus.Text = stat.Ime;
                    comboStatus.SelectedItem = stat;
                    textOpisProblema.Text = a.Description;

                    Size novavel = new Size();
                    novavel.Height = 250;
                    novavel.Width = 250;
                    Issue b = (Issue)dgvIncidenti.CurrentRow.DataBoundItem;
                    string url = "http://marichely.me/rolling/media/Incident/" + b.Issueid + "/slika.png";
                    PostaviSliku(pboxIncidentSlika, url, novavel);
                }
            }
        }

     
    }
}
