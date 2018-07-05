using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EmailSender
{
    public partial class FormEmailSender : Form
    {
        string userMailAddress = string.Empty, userMailPassword = string.Empty;
        bool tbSubjectChanged = false;
        public FormEmailSender()
        {
            InitializeComponent();
        }

        private void FormEmailSender_Load(object sender, EventArgs e)
        {
            ControlExtension.Draggable(this, true);
        }
        
        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void tbSubject_Click(object sender, EventArgs e)
        {
            if(!tbSubjectChanged)
            {
                tbSubject.Text = string.Empty;
                tbSubject.ForeColor = Color.FromName("WindowText");
                tbSubjectChanged = true;
            }
        }

        private void tbSubject_Leave(object sender, EventArgs e)
        {
            if (tbSubject.Text.Equals(string.Empty))
            {
                tbSubject.ForeColor = Color.FromName("ControlDarkDark");
                tbSubject.Text = "Subject";
                tbSubjectChanged = false;
            }
        }

        // Note: Program won't work if your https://myaccount.google.com/lesssecureapps is turned off
        // because this application is simple and is classified in "Less Secure Apps" category and with the
        // mentioned-above setting turned off gmail/google will automacily block/delete received mail from less secure app
        private void btnSend_Click(object sender, EventArgs e)
        {
            if(tbSubject.Text.Equals(string.Empty) || tbRecipiants.Text.Equals(string.Empty))
            {
                MessageBox.Show("Recipiant and Subject must be entered!");
                return;
            }

            Login login = new Login();
            login.ShowDialog();

            try
            {
                using (FileStream fs = File.OpenRead("user.dat"))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    User myUser = (User)bf.Deserialize(fs);
                    if(myUser.Username.Equals(string.Empty) || myUser.Password.Equals(string.Empty))
                    {
                        return;
                    }
                    userMailAddress = myUser.Username;
                    userMailPassword = myUser.Password;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Failed to deserialize 'user.dat'. ErrMsg: {ex.Message}");
                return;
            }

            try
            {
                MailMessage message = new MailMessage
                {
                    From = new MailAddress(userMailAddress),
                    Subject = tbSubject.Text,
                    Body = tbBody.Text
                };

                foreach (string s in tbRecipiants.Text.Split(';'))
                {
                    try
                    {
                        message.To.Add(new MailAddress(s));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"(Recipient: {s}): {ex.Message}");
                    }
                }

                SmtpClient client = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(userMailAddress, userMailPassword)
                };

                client.Send(message);
                   
                MessageBox.Show("Mail successfully sent!");
                
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Failed to send mail! Reason: {ex.Message}");
            }
        }
    }
}
