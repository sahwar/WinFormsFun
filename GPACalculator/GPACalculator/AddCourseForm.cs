using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProsekOcena
{
    public partial class AddCourseForm : Form
    {
        DataGridView dgvReference = null;
        Course currCourse = new Course();
        public AddCourseForm(DataGridView dgv)
        {
            InitializeComponent();
            dgvReference = dgv;
            propertyGridNewCourse.SelectedObject = currCourse;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                dgvReference.Rows.Add(0, currCourse.Name, currCourse.ECTS, currCourse.Grade, currCourse.Passed);
                MessageBox.Show("Course added!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.HelpLink, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
