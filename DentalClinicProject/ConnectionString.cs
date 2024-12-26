using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace DentalClinicProject
{
    internal class ConnectionString
    {
        public SqlConnection GetCon()
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = @"Data Source=AYŞEGÜL\SQLEXPRESS;Initial Catalog=DentalDb;Integrated Security=True;Encrypt=False;Connection Timeout=100";
            return Con;
        }
    }
}
