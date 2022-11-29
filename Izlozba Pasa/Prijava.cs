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
    class Prijava
    {
        public static bool PrijavaPsa(int sifraP, string sifraI, int sifraK)
        {
            SqlCommand cmd = Konekcija.GetCommand();
            cmd.CommandText = "usp_Rezultat";
            cmd.Parameters.AddWithValue("@sifraP", sifraP);
            cmd.Parameters.AddWithValue("@sifraI", sifraI);
            cmd.Parameters.AddWithValue("@sifraK", sifraK);
            try
            {
                cmd.Connection.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Pas je uspesno prijavljen");
                    return true;
                }
                else throw new Exception("Tabela nije pronadjena");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pas je vec prijavljen");
                return false;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
    }
}
