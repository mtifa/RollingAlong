using Rollin__Along.Data_classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rollin__Along.Entry_and_inventory_managment;
using System.Diagnostics;

namespace Rollin__Along
{
    public partial class FrmMainMenu : Form
    {
        User korisnik;
        public int BicId { get; set; }
        public FrmMainMenu(User a)
        {
            InitializeComponent();
            korisnik = a;
            toolStripStatusLabel1.Text += korisnik.Name + " | ";
        }

        public FrmLogin Prijava
        {
            get => default(FrmLogin);
            set
            {
            }
        }

        private void opremaPregled_Click(object sender, EventArgs e)
        {
            FrmEquipment formaOprema = new FrmEquipment(korisnik);
            formaOprema.Show();
            this.Hide();
        }

        private void biciklPregled_Click(object sender, EventArgs e)
        {
            FrmBicycles formaBicikl = new FrmBicycles(korisnik);
            formaBicikl.Show();
            this.Hide();
        }

        private void incidenti_Click(object sender, EventArgs e)
        {
            Incidents_managing.FrmIncidents formaIncident = new Incidents_managing.FrmIncidents(this, korisnik);

            formaIncident.Show();
            this.Hide();

        }

        private void rezervacije_Click(object sender, EventArgs e)
        {
            Active_rents.FrmRents formaRezervacije = new Active_rents.FrmRents(korisnik, this);
            formaRezervacije.Show();
            this.Hide();

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://github.com/foivz/r17036/wiki/3.-Korisni%C4%8Dka-dokumentacija");
            Process.Start(sInfo);
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmLogin frmPrijava = new FrmLogin();
            frmPrijava.ShowDialog();
        }
    }
}
