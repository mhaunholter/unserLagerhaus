using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.IO;
using System.Collections.Generic;

namespace unserLagerhaus
{
    class SQL_Database
    {
        private static SqlConnection con = new SqlConnection();
        private static SqlCommand cmd = new SqlCommand();
        private static string connectionstring;
        private static string tb;
        private static bool alreadyExists;

        public static void start(string password)
        {
            con.ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Integrated security=SSPI;";
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
            //con.ConnectionString = connectionstring;
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
            DataTable backup = fill_Datagridview(tb);
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
            try
            {
                bulkCopy.WriteToServer(data);
            }catch (Exception ex)
            {
                MessageBox.Show("Ein Fehler wurde verursachtet, vermutlich weil der Inhalt der Zeile mehr als 50 Zeichen hat oder mehr als float(8,2)");
                bulkCopy.WriteToServer(backup);
            }
            
            con.Close();
        }

        public static void connectTable(string table)
        {
            tb = table;
        }

        public static void ImportCSV(string table)
        {
            string filepath = "";
            if (table == "Produkte" || table == "Mitarbeiter" || table == "Bestellungen")
            {
                filepath = @"..\..\Properties\" + table + ".csv";
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    filepath = openFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }          
            StreamReader csvReader = new StreamReader(filepath);
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
            }
            if (table != "Produkte" && table != "Mitarbeiter" && table != "Bestellungen")
            {
                SetColumn setColumn = new SetColumn();
                setColumn.importDataTable(csvData);
                setColumn.ShowDialog();
                int length = csvData.Columns.Count;
                table = Path.GetFileNameWithoutExtension(filepath);
                alreadyExists = false;
                addTable(length, table, alreadyExists);
                if (alreadyExists)
                {
                    return;
                }
            }
            SqlCommand cmd = new SqlCommand("Delete from " + table, con);
            SqlBulkCopy bulkCopy = new SqlBulkCopy(con);
            bulkCopy.DestinationTableName = table;
            cmd.ExecuteNonQuery();            
            SqlDecimal.Round(8, 2);
            try
            {
                bulkCopy.WriteToServer(csvData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Die Daten entsprechen nicht dem Datentyp, bitte wählen Sie nvarchar(50) aus oder überprüfen Sie ihre Daten");
                cmd.CommandText = "Drop table " + table;
                cmd.ExecuteNonQuery();
            }
            
            //con.Close();
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

        public static List<string> getTable(List<string> db)
        {
            //Gets every Table that is in the database
            con.ConnectionString = "Server = (localdb)\\MSSQLLocalDB; Integrated security = SSPI;database=UnserLagerhaus_3ITK_Hain";
            con.Open();
            DataTable tables = con.GetSchema("Tables");
            foreach (DataRow table in tables.Rows)
            {
                //[2] because [0] is database, [1] is dbo, [2] is table name
                if(table[2].ToString() == "Admin")
                {
                    
                }
                db.Add(table[2].ToString());
            }
            con.Close();
            return db;
        }

        private static void addTable(int length, string table, bool alreadyExists)
        {
            try
            {
                cmd.CommandText = "create table dbo." + table + "([ID][int] IDENTITY(1,1) NOT NULL PRIMARY KEY)";
                con.Open();
                cmd.ExecuteNonQuery();
                for (int i = 1; i < length; i++)
                {
                    cmd.CommandText = "Alter Table dbo." + table + " add " + SetColumn.ar[i, 0] + " " + SetColumn.ar[i, 1];
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                MessageBox.Show("Tabellenname ist schon vergeben");
                alreadyExists = true;
            }            
        }

        public static void deleteTable(string table)
        {
            cmd.CommandText = "drop table " + table;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void passwordTable(string hashedPassword)
        {
            con.ConnectionString = "Server = (localdb)\\MSSQLLocalDB; Integrated security = SSPI;database=UnserLagerhaus_3ITK_Hain";
            cmd.CommandText = "create table dbo.Admin([Password][nvarchar](100))";
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Insert into Admin values('"+hashedPassword+"')";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static string getPassword()
        {
            cmd.CommandText = "Select * from Admin";
            SqlDataReader reader = cmd.ExecuteReader();
            string hashedpassword = reader.GetString(0);
            return hashedpassword;
        }
    }
}
