using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace ExerciseThree_Net
{
    public partial class BasicClientDownload : Form
    {
        private const string statusMsgAddress = @"https://pastebin.com/raw/fyEqZWtv";

        public BasicClientDownload()
        {
            InitializeComponent();
        }

        private void BasicClientDownload_Load(object sender, EventArgs e)
        {
            ControlExtension.Draggable(this, true);
        }

        private void ExitProgram(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DownloadFile(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Text file|*.txt"
            };

            if (sfd.ShowDialog().Equals(DialogResult.OK))
            {
                WebClient wc = new WebClient();
                wc.DownloadFileAsync(new Uri(statusMsgAddress), sfd.FileName);
                wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
            }
        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            labelDownloadProgress.Text = $"Downloading... ({e.ProgressPercentage}%)";
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            labelDownloadProgress.Text = "Download complete!";
        }
    }
}
