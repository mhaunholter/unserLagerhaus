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
            dataTable = SQL_Database.fill_Datagridview(cb_table.Text);
            dgv_Table.DataSource = dataTable;
            dgv_Table.Columns[0].ReadOnly = true;
            cb_searchBy_Change();
        }

        private void cb_table_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataTable.Clear();
            dgv_Table.DataSource = null;
            dataTable = SQL_Database.fill_Datagridview(cb_table.Text);
            dgv_Table.DataSource = dataTable;
            cb_searchBy_Change();
        }

        private void dgv_Table_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataTable data = new DataTable();
            data.Clear();
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
            SQL_Database.saveTable(data);
        }
        private void cb_searchBy_Change()
        {
            cb_searchBy.Items.Clear();
            switch (cb_table.Text)
            {
                case "Produkte":
                    {
                        cb_searchBy.Items.Add("ID");
                        cb_searchBy.Items.Add("Bezeichnung");
                        cb_searchBy.Items.Add("Anzahl");
                        cb_searchBy.Items.Add("Kategorie");
                        cb_searchBy.Items.Add("Lagerabteilung");
                        cb_searchBy.Items.Add("Regal");

                        break;
                    }
                case "Mitarbeiter":
                    {
                        cb_searchBy.Items.Add("ID");
                        cb_searchBy.Items.Add("Vorname");
                        cb_searchBy.Items.Add("Nachname");
                        cb_searchBy.Items.Add("Arbeitsstelle");
                        cb_searchBy.Items.Add("Arbeitet seit");
                        cb_searchBy.Items.Add("SV-Nummer");
                        cb_searchBy.Items.Add("Gehalt");
                        break;
                    }
                case "Bestellungen":
                    {
                        cb_searchBy.Items.Add("ID");
                        cb_searchBy.Items.Add("Bestellt am");
                        cb_searchBy.Items.Add("Angekommen");
                        cb_searchBy.Items.Add("Bezahlt");
                        cb_searchBy.Items.Add("Bezeichnung");
                        cb_searchBy.Items.Add("Anzahl");
                        break;
                    }
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            dataTable = SQL_Database.Search(tb_searchFor.Text, cb_table.Text, cb_searchBy.Text);
            dgv_Table.DataSource = null;
            dgv_Table.DataSource = dataTable;
        }
    }
}