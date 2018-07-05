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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnChoice_Click(object sender, EventArgs e)
        {
            if(programsToRunCheckedListBox.CheckedItems.Count <= 0)
            {
                MessageBox.Show("You must select at least one of the programs!");
                return;
            }

            this.Hide();

            for(int i = 0; i < programsToRunCheckedListBox.Items.Count; ++i)
            {
                if(programsToRunCheckedListBox.GetItemChecked(i))
                {
                    switch(i)
                    {
                        case 0:
                            EtchASketch etch = new EtchASketch();
                            etch.ShowDialog();
                            break;
                        case 1:
                            RGB_basic_ui rgb_basic = new RGB_basic_ui();
                            rgb_basic.ShowDialog();
                            break;
                    }
                }
            }

            this.Close();
            
        }
    }
}
