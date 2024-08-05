using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ziya_Dent
{
    internal class ConnectionString
    {
        public SqlConnection GetCon()
        {
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = @"Data Source=HARUN;Initial Catalog=""Ziya Dent"";Integrated Security=True;";
            return baglanti;
        }

    }
}
