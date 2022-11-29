using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Izlozba_Pasa
{
    public partial class FStatistika : Form
    {
        public FStatistika()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form1 nf = new Form1();
            nf.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FStatistika_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Izlozba.UcitajIzlozbe(1);
            comboBox1.DisplayMember = "IzlozbaIme";
            comboBox1.ValueMember = "IzlozbaID";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sifraI = (string)comboBox1.SelectedValue;
            label4.Text = Statistika.BrojPasa(sifraI, false).ToString();
            label4.Visible = true;
            label5.Text = Statistika.BrojPasa(sifraI, true).ToString();
            label5.Visible = true;
            dataGridView1.DataSource = Statistika.UcitajTabelu(sifraI);
            chart1.DataSource = dataGridView1.DataSource;
            chart1.Series[0].YValueMembers = "Broj Pasa";
            chart1.Series[0].XValueMember = "Naziv Kategorije";
            chart1.Series[0].YValueType = ChartValueType.Int32;
            chart1.Series[0].XValueType = ChartValueType.String;
        }
    }
}
