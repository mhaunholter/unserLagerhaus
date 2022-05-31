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
        private string[,] ar;
        private int i;
        public SetColumn()
        {
            InitializeComponent();
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {            
            lb_columnName.Text = ar[i, 0];
                if(cb_type.Text == "nvarchar")
                {
                    ar[i, 1] = cb_type.Text + "(" + tb_charLength.Text + ")";
                }
                else
                {
                    ar[i, 1] = cb_type.Text;
                }
            i++;
            if(i == data.Columns.Count)
            {
                ActiveForm.Close();
            }
            lb_columnName.Text = ar[i, 0];
        }

        public void importDataTable(DataTable data)
        {
            this.data = data;
        }

        private void SetColumn_Load(object sender, EventArgs e)
        {
            i = 0;
            ar = new string[data.Columns.Count,2];
            foreach(DataColumn x in data.Columns)
            {
                ar[i, 0] = x.ToString();
                i++;
            }
            i = 0;
            lb_columnName.Text = ar[i, 0];
        }

        private void nextColumn()
        {
            for (int i = 0; i < data.Columns.Count; i++)
            {
            }
        }
    }
}
