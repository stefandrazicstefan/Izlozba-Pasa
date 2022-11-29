using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Izlozba_Pasa
{
    class Konekcija
    {
        public static SqlCommand GetCommand()
        {
            string connstr = @"Data Source=.; Integrated security=true; Initial Catalog=IzlozbaPasa; ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(connstr);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
    }
}
