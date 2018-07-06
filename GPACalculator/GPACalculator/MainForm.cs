using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProsekOcena
{
    public partial class MainForm : Form
    {
        const int scrollBarWidth = 75; 
        string lastOpenedFileName = string.Empty;
        public MainForm()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), $"{ex.GetType()} {ex.HResult}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            panelStatistics.Hide();
            dgvCourses.Show();
        }
        private void DataGridViewRowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                int idLastRow = dgv.Rows.Count;
                dgv.Rows[idLastRow - 1].Cells[colOrdNum.DisplayIndex].Value = idLastRow;
                foreach(DataGridViewCell cell in dgv.Rows[e.RowIndex].Cells)
                {
                    DataGridViewCellValueChanged(dgv, new DataGridViewCellEventArgs(cell.ColumnIndex, cell.RowIndex));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), $"{ex.GetType()} ({ex.HResult})", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddCourse(object sender, EventArgs e)
        {
            try
            {
                AddCourseForm acf = new AddCourseForm(dgvCourses);
                acf.ShowDialog();
                if(acf.IsDisposed)
                {
                    acf.Close();
                }
                CalculateAverages(dgvCourses, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), $"{ex.GetType()} ({ex.HResult})", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddCourse(XmlNode fromNode)
        {
            try
            {
                string name = fromNode.SelectSingleNode("Name").InnerText;
                if(!int.TryParse(fromNode.SelectSingleNode("ECTS").InnerText, out int ects))
                {
                    ects = default(int);
                }
                if (!int.TryParse(fromNode.SelectSingleNode("Grade").InnerText, out int grade))
                {
                    grade = default(int);
                }
                if (!bool.TryParse(fromNode.SelectSingleNode("Passed").InnerText, out bool passed))
                {
                    passed = default(bool);
                }
                dgvCourses.Rows.Add(dgvCourses.Rows.Count + 1, name, ects, grade, passed);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), $"{ex.GetType()} ({ex.HResult})", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CalculateAverages(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                int sumGrade = 0, sumECTS = 0;
                int numPassed = 0;
                foreach (DataGridViewRow dgRow in dgv.Rows)
                {
                    if (bool.TryParse(dgRow.Cells[colPassed.DisplayIndex].Value.ToString(), out bool result) && result)
                    {
                        if(int.TryParse(dgRow.Cells[colECTS.DisplayIndex].Value.ToString(), out int ectsVal))
                        {
                            sumECTS += ectsVal;
                        }
                        if(int.TryParse(dgRow.Cells[colGrade.DisplayIndex].Value.ToString(), out int gradeVal))
                        {
                            sumGrade += gradeVal;
                        }
                        ++numPassed;
                    }
                }
                tbAverageGrade.Text = string.Format("{0:0.00}", ((double)sumGrade / numPassed));
                tbTotalECTS.Text = sumECTS.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), $"{ex.GetType()} ({ex.HResult})", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateOrderNumber(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                for (int i = 0; i < dgv.Rows.Count; ++i)
                {
                    dgv[colOrdNum.DisplayIndex, i].Value = i + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), $"{ex.GetType()} ({ex.HResult})", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DataGridViewRowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateAverages(sender, e);
            UpdateOrderNumber(sender, e);
            UpdateMainFormSize();
        }
        public static void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }
        private void Clip(ref int x, int maxVal)
        {
            if (x < 0) x = 0;
            else if (x > maxVal) x = maxVal;
        }
        private void CutString(ref string valToCut, int maxSize, int startIndex = 0)
        {
            #region inputValidationCheck
            Clip(ref startIndex, valToCut.Length);
            Clip(ref maxSize, valToCut.Length);
            if (startIndex > maxSize)
            {
                Swap(ref startIndex, ref maxSize);
            }
            #endregion inputValidationCheck

            if (valToCut.Length > maxSize)
            {
                valToCut = valToCut.Substring(startIndex, maxSize - startIndex);
            }
        }
        private void DataGridViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is null || e is null)
                return;
            if (sender is DataGridView dgv)
            {
                try
                {
                    if (e.ColumnIndex < 0 || e.RowIndex < 0)
                        return;

                    if (e.ColumnIndex == colECTS.DisplayIndex || e.ColumnIndex == colGrade.DisplayIndex)
                    {
                        DataGridViewTextBoxColumn colTemp = e.ColumnIndex == colECTS.DisplayIndex ? colECTS : colGrade; 
                        string valueString = dgv[e.ColumnIndex, e.RowIndex].Value?.ToString() ?? default(int).ToString();
                        CutString(ref valueString, colTemp.MaxInputLength);

                        if (!int.TryParse(valueString, out int result))
                        {
                            MessageBox.Show("Property value is not valid!", "invalid value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgv[e.ColumnIndex, e.RowIndex].Value = default(int);
                        }
                        else
                        {
                            dgv[e.ColumnIndex, e.RowIndex].Value = valueString;
                        }
                        CalculateAverages(sender, e);
                        UpdateMainFormSize();
                    }
                    else if(e.ColumnIndex == colCourse.DisplayIndex)
                    {
                        string valueString = dgv[e.ColumnIndex, e.RowIndex].Value?.ToString() ?? string.Empty;
                        CutString(ref valueString, colCourse.MaxInputLength);
                        dgv[e.ColumnIndex, e.RowIndex].Value = valueString;
                        UpdateMainFormSize();
                    }
                    else if(e.ColumnIndex == colPassed.DisplayIndex)
                    {
                        CalculateAverages(sender, e);
                    }
                }
                catch (NullReferenceException)
                {
                    dgv[e.ColumnIndex, e.RowIndex].Value = default(int);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), $"{ex.GetType()} ({ex.HResult})", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ClearDataGridViewer(object sender, EventArgs e)
        {
            try
            {
                dgvCourses.Rows.Clear();
                this.Text = "Untitled";
                lastOpenedFileName = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), $"{ex.GetType()} ({ex.HResult})", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Exit(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show($"Do you want to save changes to {this.Text}?", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                SaveXML(sender, e);
            }
            Application.Exit();
        }
        private void UpdateMainFormSize()
        {
            int colsWidth = 0;
            foreach (DataGridViewColumn col in dgvCourses.Columns)
            {
                colsWidth += col.Width;
            }
            if (this.WindowState.Equals(FormWindowState.Normal))
            {
                this.Size = new Size(colsWidth + scrollBarWidth, this.Size.Height);
            }
        }
        private void OpenXMLFile(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog()
                {
                    Filter = "XML|*.xml"
                };

                if (ofd.ShowDialog().Equals(DialogResult.OK))
                {
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(ofd.FileName);
                    ClearDataGridViewer(dgvCourses, new EventArgs());
                    foreach (XmlNode node in xDoc.SelectNodes("Courses/Course"))
                    {
                        AddCourse(node);
                    }
                    CalculateAverages(dgvCourses, new EventArgs());
                    lastOpenedFileName = ofd.FileName;
                    this.Text = ofd.SafeFileName;
                    UpdateMainFormSize();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), $"{ex.GetType()} ({ex.HResult})", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveAsXML(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "XML|*.xml"
            };
            if(sfd.ShowDialog().Equals(DialogResult.OK))
            {
                SaveToXML(sfd.FileName);
            }
        }
        private void SaveXML(object sender, EventArgs e)
        {
            if(lastOpenedFileName != string.Empty && lastOpenedFileName != null)
            {
                SaveToXML(lastOpenedFileName);
            }
            else
            {
                SaveAsXML(sender, e);
            }
        }
        private void SaveToXML(string fileName)
        {
            if (fileName is null)
                return;

            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "    "
            };
            
            using (XmlWriter xWriter = XmlWriter.Create(fileName, settings))
            {
                try
                {
                    xWriter.WriteStartDocument();
                    xWriter.WriteStartElement("Courses");
                    foreach (DataGridViewRow row in dgvCourses.Rows)
                    {
                        xWriter.WriteStartElement("Course");
                        for (int i = 1; i < row.Cells.Count; ++i)
                        {
                            if (i == colCourse.DisplayIndex)
                            {
                                xWriter.WriteElementString("Name", row.Cells[i].Value.ToString());
                            }
                            else if (i == colECTS.DisplayIndex)
                            {
                                xWriter.WriteElementString("ECTS", row.Cells[i].Value.ToString());
                            }
                            else if (i == colGrade.DisplayIndex)
                            {
                                xWriter.WriteElementString("Grade", row.Cells[i].Value.ToString());
                            }
                            else
                            {
                                xWriter.WriteElementString("Passed", row.Cells[i].Value.ToString());
                            }
                        }
                        xWriter.WriteEndElement();
                    }
                    xWriter.WriteEndElement();
                    xWriter.WriteEndDocument();

                    MessageBox.Show("Item(s) Saved!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), $"{ex.GetType()} ({ex.HResult})", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CreateNewDataGridView(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "XML|*.xml"
                };

                if (sfd.ShowDialog().Equals(DialogResult.OK))
                {
                    ClearDataGridViewer(dgvCourses, new EventArgs());
                    lastOpenedFileName = sfd.FileName;
                    string[] fileNames = sfd.FileName.Split('\\');
                    this.Text = fileNames[fileNames.Length - 1];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), $"{ex.GetType()} ({ex.HResult})", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void coursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelStatistics?.Hide();
            dgvCourses?.Show();
            
        }
        private void statisticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dgvCourses.Hide();
                panelStatistics.Show();
                Dictionary<int, int> gradeCount = new Dictionary<int, int>();
                for (int i = 6; i <= 10; ++i)
                {
                    gradeCount[i] = 0;
                }
                int totalGrades = 0;
                for (int i = 0; i < dgvCourses.Rows.Count; ++i)
                {
                    if (bool.TryParse(dgvCourses[colPassed.DisplayIndex, i].Value.ToString(), out bool passed) && passed)
                    {
                        if (int.TryParse(dgvCourses[colGrade.DisplayIndex, i].Value.ToString(), out int grade))
                        {
                            if (gradeCount.ContainsKey(grade))
                            {
                                ++gradeCount[grade];
                            }
                            else
                            {
                                gradeCount.Add(grade, 1);
                            }
                            ++totalGrades;
                        }
                    }
                }
                if (totalGrades <= 0)
                    return;

                double grade10stat = Math.Round((double)gradeCount[10] * 100 / totalGrades, 2);
                double grade9stat = Math.Round((double)gradeCount[9] * 100 / totalGrades, 2);
                double grade8stat = Math.Round((double)gradeCount[8] * 100 / totalGrades, 2);
                double grade7stat = Math.Round((double)gradeCount[7] * 100 / totalGrades, 2);
                double grade6stat = Math.Round((double)gradeCount[6] * 100 / totalGrades, 2);

                progress10.Value = (int)grade10stat;
                progress9.Value = (int)grade9stat;
                progress8.Value = (int)grade8stat;
                progress7.Value = (int)grade7stat;
                progress6.Value = (int)grade6stat;

                percent10.Text = $"{grade10stat}% ({gradeCount[10]})";
                percent9.Text = $"{grade9stat}% ({gradeCount[9]})";
                percent8.Text = $"{grade8stat}% ({gradeCount[8]})";
                percent7.Text = $"{grade7stat}% ({gradeCount[7]})";
                percent6.Text = $"{grade6stat}% ({gradeCount[6]})";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), $"{ex.GetType()} ({ex.HResult})", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCourses.SelectedRows.Count > 0)
                {
                    List<DataGridViewRow> toDelete = new List<DataGridViewRow>();
                    foreach (DataGridViewRow row in dgvCourses.SelectedRows)
                    {
                        toDelete.Add(row);
                    }
                    foreach (DataGridViewRow row in toDelete)
                    {
                        dgvCourses.Rows.Remove(row);
                    }
                    toDelete.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), $"{ex.GetType()} ({ex.HResult})", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCourses_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            try
            {
                MessageBox.Show("Error happened " + anError.Context.ToString(), anError.Exception.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

                if ((anError.Exception) is ConstraintException)
                {
                    DataGridView view = (DataGridView)sender;
                    view.Rows[anError.RowIndex].ErrorText = "an error";
                    view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";

                    anError.ThrowException = false;
                }
            }
            catch { }
            finally
            {
                anError.Cancel = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                Exit(sender, e);
            }
        }
    }
}
