using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Izlozba_Pasa
{
    class Izlozba
    {
        public string IzlozbaID { get; set; }
        public string Mesto { get; set; }
        public DateTime Datum { get; set; }

        public string IzlozbaIme
        {
            get
            {
                return this.IzlozbaID + " - " + this.Mesto + " - " + this.Datum.ToShortDateString();
            }
        }

        public Izlozba(DataRow dr)
        {
            InicijalizujPolja(dr);
        }

        public void InicijalizujPolja(DataRow dr)
        {
            this.IzlozbaID = (string)dr["IzlozbaID"];
            if (dr["Mesto"] == DBNull.Value)
            {
                this.Mesto = "";
            }
            else
            {
                this.Mesto = (string)dr["Mesto"];
            }
            this.Datum = (DateTime)dr["Datum"];
        }

        public static List<Izlozba> UcitajIzlozbe(int akcija)
        {
            SqlCommand cmd = Konekcija.GetCommand();
            cmd.CommandText = "usp_Izlozba";
            cmd.Parameters.AddWithValue("@akcija", akcija);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            List<Izlozba> lista = new List<Izlozba>();
            try
            {
                cmd.Connection.Open();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lista.Add(new Izlozba(dr));
                    }
                    return lista;
                }
                else throw new Exception("Tabela nije pronadjena");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Baza nije povezana");
                return null;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
    }
}
