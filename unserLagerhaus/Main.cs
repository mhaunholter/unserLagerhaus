using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace unserLagerhaus
{
    public partial class Main : Form
    {
        private DataTable dataTable = new DataTable();
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            SQL_Database.create();
            fill_cb_table();
        }

        private void cb_table_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataTable.Clear();
            dgv_Table.DataSource = null;
            dataTable = SQL_Database.fill_Datagridview(cb_table.Text);
            dgv_Table.DataSource = dataTable;
            dgv_Table.Columns[0].ReadOnly = true;
            cb_searchBy_Change();
        }

        private void dgv_Table_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataTable data = new DataTable();
            data.Clear();
            TableToDataTable(data);
           
            SQL_Database.saveTable(data);
        }
        private void cb_searchBy_Change()
        {
            cb_searchBy.Items.Clear();
            dataTable = SQL_Database.fill_Datagridview(cb_table.Text);
            foreach (DataColumn column in dataTable.Columns)
            {
                cb_searchBy.Items.Add(column.ColumnName);                
            }            
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            dataTable = SQL_Database.Search(tb_searchFor.Text, cb_table.Text, cb_searchBy.Text);
            dgv_Table.DataSource = null;
            dgv_Table.DataSource = dataTable;
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            string path ="";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV|*.csv";
            if(saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = saveFileDialog.FileName;
            }
            else
            {
                return;
            }
            DataTable data = new DataTable();
            TableToDataTable(data);
            SQL_Database.ExportCSV(path.Replace("\\", "/"), data);
        }

        private DataTable TableToDataTable(DataTable data)
        {
            foreach (DataGridViewColumn column in dgv_Table.Columns)
            {
                data.Columns.Add(column.HeaderText, column.ValueType);
            }
            foreach (DataGridViewRow row in dgv_Table.Rows)
            {

                int i = 1;
                data.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex == 0)
                    {
                        data.Rows[data.Rows.Count - 1][cell.ColumnIndex] = i;
                    }
                    else
                    {
                        if (cell.Value.ToString() == "") { }
                        else
                        {
                            try
                            {
                                data.Rows[data.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                            }
                            catch
                            {
                                data.Rows[data.Rows.Count - 1][cell.ColumnIndex] = Convert.ToDecimal(cell.Value);
                            }

                        }
                    }
                }
                if (dgv_Table.Rows.Count - 1 == data.Rows.Count) break;
            }
            return data;
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            SQL_Database.ImportCSV("");
            fill_cb_table();

        }

        private void fill_cb_table()
        {
            List<string> list = new List<string>();
            list = SQL_Database.getTable(list);
            cb_table.Items.Clear();
            foreach(string s in list)
            {
                cb_table.Items.Add(s);
            }
        }

        private void btn_deleteTable_Click(object sender, EventArgs e)
        {
            dgv_Table.DataSource = null;
            SQL_Database.deleteTable(cb_table.Text);
            fill_cb_table();
            cb_table.Text = "";
        }
    }
}