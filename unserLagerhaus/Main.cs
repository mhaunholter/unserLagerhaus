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
        //Dings
        private void Main_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            SQL_Database.start();
            SQL_Database.create();
            dataTable = SQL_Database.fill_Datagridview(cb_table.Text);
            dgv_Table.DataSource = dataTable;
            dgv_Table.Columns[0].ReadOnly = true;
        }

        private void cb_table_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataTable.Clear();
            dgv_Table.DataSource = null;
            dataTable = SQL_Database.fill_Datagridview(cb_table.Text);
            dgv_Table.DataSource = dataTable;
        }
    }
}
