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
        public static string[,] ar;
        private int i;
        public SetColumn()
        {
            InitializeComponent();
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {   
            if(cb_type.Text == "")
            {
                MessageBox.Show("Bitte wählen Sie einen Datentyp aus");
                return;
            }
            lb_columnName.Text = ar[i, 0];
 
                    ar[i, 1] = cb_type.Text;
            i++;
            if(i == data.Columns.Count)
            {
                ActiveForm.Close();
            }
            else
            {
                lb_columnName.Text = ar[i, 0];
            }
            
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
            i = 1;
            lb_columnName.Text = ar[i, 0];
        }
    }
}
