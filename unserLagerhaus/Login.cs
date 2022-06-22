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
        public bool firstTimeAdmin = true;
        public bool correctPassword = false;
        public Login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (cb_type.Text == "Admin")
            {
                if (tb_password.Text == "")
                {
                    MessageBox.Show("Wrong Input!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (firstTimeAdmin)
                {
                    string hashedPassword = BCrypt_Class.HashPassword(tb_password.Text);
                    SQL_Database.passwordTable(hashedPassword);
                }
                else
                {
                   correctPassword = BCrypt.Net.BCrypt.Verify(tb_password.Text, SQL_Database.getPassword());
                }
            }
            if(cb_type.Text != "Benutzer" && cb_type.Text != "Admin")
            {
                MessageBox.Show("Wrong Input!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            
            exit = true;
            SQL_Database.start(tb_password.Text);
                       
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
                case "Benutzer":
                    {
                        tb_password.Enabled = false;
                        label2.Text = "Passwort";
                        break;
                    }
                case "Admin":
                    {
                        tb_password.Enabled = true;
                        List<string> list = new List<string>();
                        list = SQL_Database.getTable(list);
                        foreach (string s in list)
                        {
                            if (s == "Admin")
                            {
                                firstTimeAdmin = false;
                            }
                        }
                        if (firstTimeAdmin)
                        {
                            label2.Text = "Passwort erstellen";
                        }
                        else
                        {
                            label2.Text = "Passwort";
                        }
                        break;
                    }
            }
        }
    }
}
