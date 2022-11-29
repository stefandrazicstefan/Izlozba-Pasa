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
    class Statistika
    {
        public static int BrojPasa(string sifraI, bool ucest)
        {
            SqlCommand cmd = Konekcija.GetCommand();
            cmd.CommandText = "usp_Prijavljeni_Ucesnici";
            cmd.Parameters.AddWithValue("@sifraI", sifraI);
            if (ucest) cmd.Parameters.AddWithValue("@ucestvovao", true);
            else cmd.Parameters.AddWithValue("@ucestvovao", false);
            try
            {
                cmd.Connection.Open();
                int broj = (int)cmd.ExecuteScalar();
                return broj;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska");
                return 0;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public static DataTable UcitajTabelu(string sifraI)
        {
            SqlCommand cmd = Konekcija.GetCommand();
            cmd.CommandText = "usp_StatistikaPoKategorijama";
            cmd.Parameters.AddWithValue("@sifraI", sifraI);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                cmd.Connection.Open();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt;
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
