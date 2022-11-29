using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Izlozba_Pasa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Pas.UcitajPse();
            comboBox1.DisplayMember = "PasIme";
            comboBox1.ValueMember = "PasID";

            comboBox2.DataSource = Izlozba.UcitajIzlozbe(1);
            comboBox2.DisplayMember = "IzlozbaIme";
            comboBox2.ValueMember = "IzlozbaID";

            comboBox3.DataSource = Kategorija.UcitajKategorije();
            comboBox3.DisplayMember = "KategorijaIme";
            comboBox3.ValueMember = "KategorijaID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sifraP = (int)comboBox1.SelectedValue;
            string sifraI = (string)comboBox2.SelectedValue;
            int sifraK = (int)comboBox3.SelectedValue;
            Prijava.PrijavaPsa(sifraP, sifraI, sifraK);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FStatistika nf = new FStatistika();
            nf.Show();
        }
    }
}
