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
    class Kategorija
    {
        public int KategorijaID { get; set; }
        public string Naziv { get; set; }
        public string KategorijaIme
        {
            get
            {
                return this.KategorijaID + " - " + this.Naziv;
            }
        }
        public Kategorija(DataRow dr)
        {
            InicijalizujPolja(dr);
        }
        public void InicijalizujPolja(DataRow dr)
        {
            this.KategorijaID = (int)dr["KategorijaID"];
            this.Naziv = (string)dr["Naziv"];
        }
        public static List<Kategorija> UcitajKategorije()
        {
            SqlCommand cmd = Konekcija.GetCommand();
            cmd.CommandText = "usp_Kategorija";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            List<Kategorija> lista = new List<Kategorija>();
            try
            {
                cmd.Connection.Open();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lista.Add(new Kategorija(dr));
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
