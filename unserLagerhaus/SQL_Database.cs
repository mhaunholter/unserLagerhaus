using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.SqlTypes;

namespace unserLagerhaus
{
    class SQL_Database
    {
        private static SqlConnection con = new SqlConnection();
        private static SqlCommand cmd = new SqlCommand();
        private static string connectionstring;
        private static string tb;

        public static void start(bool integrated_security, string user, string password)
        {
            switch (integrated_security)
            {
                case true:
                    {
                        con.ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Integrated security=SSPI;";
                        break;
                    }
                case false:
                    {
                        con.ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Integrated security=SSPI;";
                        break;
                    }                                        
            }
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
                con.Open();
                cmd.CommandText = "create table [dbo].[Produkte]([ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY, [Bezeichnung][nvarchar](50), [Anzahl][int],[Kategorie][nvarchar](50), [Lagerabteilung][int], [Regal][int])";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "create table [dbo].[Mitarbeiter]([ID][int] IDENTITY(1,1) NOT NULL PRIMARY KEY, [Vorname][nvarchar](50), [Nachname][nvarchar](50), [Arbeitsstelle][nvarchar](50), [Arbeitet seit][date], [Sozialversicherungsnummer][bigint],[Gehalt][decimal](8,2))";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "create table [dbo].[Bestellungen]([ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,[Bestellt am][date], [Angekommen][date],[Bezahlt][nvarchar](4),[Bezeichnung][nvarchar](50),[Anzahl][int])";
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
            tb = table;
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

        public static void saveTable(DataTable data)
        {
            SqlCommand cmd = new SqlCommand("Delete from " + tb, con);
            SqlBulkCopy bulkCopy = new SqlBulkCopy(con);
            bulkCopy.BatchSize = 500;
            bulkCopy.NotifyAfter = 1000;
            bulkCopy.DestinationTableName = tb;
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DBCC CHECKIDENT('[" + tb + "]', RESEED, 0)";
            cmd.ExecuteNonQuery();
            SqlDecimal.Round(8, 2);
            bulkCopy.WriteToServer(data);
            con.Close();
        }

        public static void connectTable(string table)
        {
            tb = table;
        }
    }
}
