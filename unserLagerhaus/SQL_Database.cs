using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace unserLagerhaus
{
    class SQL_Database
    {
        private static SqlConnection con = new SqlConnection();
        private static SqlCommand cmd = new SqlCommand();

        public static void start()
        {
            con.ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Integrated security=SSPI;";
        }
        
        public static void create()
        {
            cmd.CommandText = "create database UnserLagerhaus_3ITK_Hain_Haunholter";
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
