using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExerciseFive_WebBrowser
{
    public partial class FormWebBrowser : Form
    {
        public FormWebBrowser()
        {
            InitializeComponent();
        }

        private void FormWebBrowser_Load(object sender, EventArgs e)
        {
            try
            {
                ControlExtension.Draggable(this, true);
                tbUrl.Text = @"https://www.google.com/";
                webBrowserScreen.Url = new Uri(tbUrl.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void tbUrl_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    webBrowserScreen.Navigate(tbUrl.Text);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void webBrowserScreen_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            try
            {
                tbUrl.Text = webBrowserScreen.Url.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            webBrowserScreen.GoBack();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            webBrowserScreen.GoForward();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            webBrowserScreen.Refresh();
        }
    }
}
