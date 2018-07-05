using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EmailSender
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Exit(object sender, EventArgs e)
        {
            try
            {
                using (FileStream stream = File.Open("user.dat", FileMode.Create, FileAccess.Write))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    User myUser = new User();
                    if (tbUsernameChanged && tbPasswordChanged)
                    {
                        myUser.Username = tbUsername.Text;
                        myUser.Password = tbPassword.Text;
                    }
                    bf.Serialize(stream, myUser);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error: {ex.Message}");
            }
            finally
            {
                this.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(!tbUsernameChanged || !tbPasswordChanged)
            {
                MessageBox.Show("Both email and password must be filled!");
                return;
            }
            this.Exit(sender, e);
        }

        bool tbUsernameChanged = false, tbPasswordChanged = false;
        private void tbUsername_Leave(object sender, EventArgs e)
        {
            if (tbUsername.Text.Equals(string.Empty))
            {
                tbUsername.ForeColor = Color.FromName("ControlDarkDark");
                tbUsername.Text = "mail@gmail.com";
                tbUsernameChanged = false;
            }
        }

        private void tbUsername_Click(object sender, EventArgs e)
        {
            if(!tbUsernameChanged)
            {
                tbUsername.Text = string.Empty;
                tbUsername.ForeColor = Color.Black;
                tbUsernameChanged = true;
            }
        }

        private void tbPassword_Leave(object sender, EventArgs e)
        {
            if (tbPassword.Text.Equals(string.Empty))
            {
                tbPassword.ForeColor = Color.FromName("ControlDarkDark");
                tbPassword.Text = "password";
                tbPassword.PasswordChar = '\0';
                tbPasswordChanged = false;
            }
        }

        private void tbPassword_Click(object sender, EventArgs e)
        {
            if (!tbPasswordChanged)
            {
                tbPassword.Text = string.Empty;
                tbPassword.ForeColor = Color.Black;
                tbPassword.PasswordChar = '●';
                tbPasswordChanged = true;
            }
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            tbUsernameChanged = true;
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            tbPasswordChanged = true;
        }

        Color oldColor = Color.LightSlateGray;
        Color newColor = Color.DarkGray;
        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                control.BackColor = oldColor;
            }
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                control.BackColor = newColor;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ControlExtension.Draggable(this, true);
        }
    }
}
