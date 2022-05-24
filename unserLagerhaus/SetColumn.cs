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
    public partial class SetColumn : Form
    {
        private DataTable data;
        private Array ar;
        public SetColumn()
        {
            InitializeComponent();
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {

        }

        public void importDataTable(DataTable data)
        {
            this.data = data;
        }

        private void SetColumn_Load(object sender, EventArgs e)
        {
            ar = new Array[data.Columns.Count];
            foreach(string x in data.Columns)
            {
                lb_columnName.Text = x;

            }
        }
    }
}
