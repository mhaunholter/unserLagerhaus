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
    public partial class Login : Form
    {
        private bool exit;
        public Login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            exit = true;
            ActiveForm.Close();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(exit != true)
            {
                Environment.Exit(0);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }
    }
}
