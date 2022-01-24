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
        private bool integrated_security;
        public Login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (integrated_security == false)
            {
                if (tb_user.Text == "" || tb_password.Text == "" || cb_type.Text != "SSPI" && cb_type.Text != "Benutzer & Passwort")
                {
                    MessageBox.Show("Wrong Input!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            exit = true;
            SQL_Database.start(integrated_security,tb_user.Text,tb_password.Text);
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

        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_type.Text)
            {
                case "SSPI":
                    {
                        tb_password.Enabled = false;
                        tb_user.Enabled = false;
                        integrated_security = true;
                        break;
                    }
                case "Benutzer & Passwort":
                    {
                        tb_password.Enabled = true;
                        tb_user.Enabled = true;
                        integrated_security = false;
                        break;
                    }
            }
        }
    }
}
