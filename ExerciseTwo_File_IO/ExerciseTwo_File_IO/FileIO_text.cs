using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExerciseTwo_File_IO
{
    public partial class FileIO_text : Form
    {
        public FileIO_text()
        {
            InitializeComponent();
        }

        private void LoadTextFromFile(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Text files|*.txt"
            };
            if (ofd.ShowDialog().Equals(DialogResult.OK))
            {
                using (StreamReader reader = new StreamReader(ofd.FileName))
                {
                    textBox1.Text = reader.ReadToEnd();
                }
            }
            
        }
        private void SaveTextToFile(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Text files|*.txt"
            };
            if(sfd.ShowDialog().Equals(DialogResult.OK))
            {
                using (StreamWriter writer = new StreamWriter(sfd.FileName))
                {
                    writer.Write(textBox1.Text);
                    MessageBox.Show("Successfuly saved text!");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ControlExtension.Draggable(this, true);
        }

        private void ShutDown(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
