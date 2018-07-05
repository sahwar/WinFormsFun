using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExerciseOne_Basic_ui
{
    public partial class RGB_basic_ui : Form
    {
        public RGB_basic_ui()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Hello(object sender, EventArgs e)
        {
            MessageBox.Show("Hello world!");
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ChangeButtonText(object sender, EventArgs e)
        {
        }
        
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void UpdatePanel1Color(object sender, EventArgs e)
        {
            byte red = 0, green = 0, blue = 0;
            if(cbRed.Checked)
            {
                red = byte.MaxValue;
            }
            if(cbGreen.Checked)
            {
                green = byte.MaxValue;
            }
            if(cbBlue.Checked)
            {
                blue = byte.MaxValue;
            }
            panel1.BackColor = Color.FromArgb(red, green, blue);
        }
    }
}
