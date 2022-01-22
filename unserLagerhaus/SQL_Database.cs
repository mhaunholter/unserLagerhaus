using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace unserLagerhaus
{
    class SQL_Database
    {
        private static SqlConnection con = new SqlConnection();
        private static SqlCommand cmd = new SqlCommand();
        private static string connectionstring;
        private string table;

        public static void start()
        {
            con.ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Integrated security=SSPI;";
            connectionstring = con.ConnectionString;
        }
        
        public static void create()
        {
            try
            {
                cmd.CommandText = "create database UnserLagerhaus_3ITK_Hain_Haunholter";
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }catch(Exception ex)
            {
                con.Close();
                connectionstring = connectionstring + "database=UnserLagerhaus_3ITK_Hain_Haunholter";
                MessageBox.Show(ex.ToString());
            }
        }

        public static DataTable fill_Datagridview(string table)
        {
            DataTable dataTable = new DataTable();
            con.ConnectionString = connectionstring;
            cmd.CommandText = "Select * from " + table;
            try
            {
                con.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
                sqlData.Fill(dataTable);
                con.Close();
                sqlData.Dispose();
        } catch(Exception ex) { MessageBox.Show(ex.ToString()); }
            return dataTable;
        }

    }
}
