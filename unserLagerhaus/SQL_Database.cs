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
                connectionstring = connectionstring + "database=UnserLagerhaus_3ITK_Hain_Haunholter";
                con.ConnectionString = connectionstring;
                cmd.Connection = con;
                cmd.CommandText = "create table [dbo].[Produkte]([id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY)";
                con.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "create table [dbo].[Mitarbeiter]([id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY)";
                cmd.ExecuteNonQuery();
                con.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        public static DataTable fill_Datagridview()
        {
            DataTable table = new DataTable();
            cmd.CommandText = "Select * from "+table;
            try
            {
                con.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
                sqlData.Fill(table);
                con.Close();
                sqlData.Dispose();
            } catch(Exception ex) { MessageBox.Show(ex.ToString()); }
            return table;
        }

    }
}
