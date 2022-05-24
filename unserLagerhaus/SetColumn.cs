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
        public SetColumn()
        {
            InitializeComponent();
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {

        }

        public void createHeaders(DataTable data)
        {
            foreach(DataColumn x in data.Columns)
            {
                lb_columnName.Text = Convert.ToString(x);
            }
        }
    }
}
