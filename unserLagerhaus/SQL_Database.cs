using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.IO;

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
                cmd.CommandText = "create database UnserLagerhaus_3ITK_Hain";
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                connectionstring = connectionstring + "database=UnserLagerhaus_3ITK_Hain";
                con.ConnectionString = connectionstring;
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "create table [dbo].[Produkte]([ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY, [Bezeichnung][nvarchar](50), [Anzahl][int],[Kategorie][nvarchar](50), [Lagerabteilung][int], [Regal][int])";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "create table [dbo].[Mitarbeiter]([ID][int] IDENTITY(1,1) NOT NULL PRIMARY KEY, [Vorname][nvarchar](50), [Nachname][nvarchar](50), [Arbeitsstelle][nvarchar](50), [Arbeitet seit][date], [Sozialversicherungsnummer][bigint],[Gehalt][decimal](8,2))";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "create table [dbo].[Bestellungen]([ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,[Bestellt am][date], [Angekommen][date],[Bezahlt][nvarchar](4),[Bezeichnung][nvarchar](50),[Anzahl][int])";
                cmd.ExecuteNonQuery();
                string table = "Produkte";
                ImportCSV(table);
                table = "Mitarbeiter";
                ImportCSV(table);
                table = "Bestellungen";
                ImportCSV(table);
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                connectionstring = connectionstring + "database=UnserLagerhaus_3ITK_Hain";
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
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
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

        public static void ImportCSV(string table)
        {
            string filename = "";
            if (table == "Produkte" || table == "Mitarbeiter" || table == "Bestellungen")
            {
                filename = @"..\..\Properties\" + table + ".csv";
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    filename = openFileDialog.FileName;
                }
            }
            StreamReader csvReader = new StreamReader(filename);
            DataTable csvData = new DataTable();
            string[] headers = csvReader.ReadLine().Split(';');
            foreach (string header in headers)
            {
                csvData.Columns.Add(header);
            }
            while (!csvReader.EndOfStream)
            {
                string[] rows = csvReader.ReadLine().Split(';');
                DataRow dr = csvData.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                csvData.Rows.Add(dr);
                if (table != "Produkte" || table != "Mitarbeiter" || table != "Bestellungen")
                {
                    
                }
            }
            SqlCommand cmd = new SqlCommand("Delete from " + table, con);
            SqlBulkCopy bulkCopy = new SqlBulkCopy(con);
            bulkCopy.BatchSize = 500;
            bulkCopy.NotifyAfter = 1000;
            bulkCopy.DestinationTableName = table;
            cmd.ExecuteNonQuery();
            SqlDecimal.Round(8, 2);
            bulkCopy.WriteToServer(csvData);
        }

        public static DataTable Search(string searchword, string table, string searchBy)
        {
            DataTable dataTable = new DataTable();
            string commandtext = "Select * from " + table + " Where " + searchBy + " like '" + searchword + "%'";
            cmd.CommandText = commandtext;
            try
            {
                con.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
                sqlData.Fill(dataTable);
                con.Close();
                sqlData.Dispose();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            return dataTable;
        }

        public static void ExportCSV(string path, DataTable data)
        {
            StreamWriter sw = new StreamWriter(path, false);
            //headers    
            for (int i = 0; i < data.Columns.Count; i++)
            {
                sw.Write(data.Columns[i]);
                if (i < data.Columns.Count - 1)
                {
                    sw.Write(";");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in data.Rows)
            {
                for (int i = 0; i < data.Columns.Count; i++)
                {

                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(";"))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < data.Columns.Count - 1)
                    {
                        sw.Write(";");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();

        }
    }
}
