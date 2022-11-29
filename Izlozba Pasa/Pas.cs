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
    class Pas
    {
        public int PasID { get; set; }
        public string Ime { get; set; }

        public string PasIme
        {
            get
            {
                return this.PasID + " - " + this.Ime;
            }
        }

        public Pas(DataRow dr)
        {
            InicijalizujPolja(dr);
        }

        public void InicijalizujPolja(DataRow dr)
        {
            this.PasID = (int)dr["PasID"];
            this.Ime = (string)dr["Ime"];
        }

        public static List<Pas> UcitajPse()
        {
            SqlCommand cmd = Konekcija.GetCommand();
            cmd.CommandText = "usp_Pas";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            List<Pas> lista = new List<Pas>();
            try
            {
                cmd.Connection.Open();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        lista.Add(new Pas(dr));
                    }
                    return lista;
                }
                else throw new Exception("Tabela nije pronadjena");
            }
            catch(Exception ex)
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
