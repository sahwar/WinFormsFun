using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Paint
{
    public enum ShapeSelected
    {
        None, 
        Square, 
        Rectangle,
        Circle
    }
    public enum BrushType
    {
        Solid,
        Texture,
        Gradient
    }
    public partial class FormPaint : Form
    {
        private string lastOpenedFileName = string.Empty;
        private bool canDraw = false;
        private Point lastPoint = new Point(0, 0);
        private Brush selectedBrush = default(Brush);
        private Graphics graphicPanel = default(Graphics);
        private Bitmap buffer = default(Bitmap);
        private Stack<Bitmap> undoBitmaps = new Stack<Bitmap>();
        private Stack<Bitmap> redoBitmaps = new Stack<Bitmap>();
        private int _brushSize = default(int);
        private ShapeSelected _shape = ShapeSelected.None;
        private BrushType _brushType = BrushType.Solid;
        public int BrushSize
        {
            get => _brushSize;
            set
            {
                btnBrushSize.Text = value.ToString();
                _brushSize = value;
            }
        }
        public ShapeSelected Shape
        {
            get
            {
                return _shape;
            }
            set
            {
                switch (value.ToString())
                {
                    case "Rectangle":
                        _shape = ShapeSelected.Rectangle;
                        btnShapes.Image = rectangleToolStripMenuItem.Image;
                        break;
                    case "Circle":
                        _shape = ShapeSelected.Circle;
                        btnShapes.Image = circleToolStripMenuItem.Image;
                        break;
                    case "Square":
                        _shape = ShapeSelected.Square;
                        btnShapes.Image = squareToolStripMenuItem.Image;
                        break;
                    default:
                        _shape = ShapeSelected.None;
                        btnShapes.Image = noneToolStripMenuItem.Image;
                        break;
                }
            }
        }
        public BrushType SelectedBrushType
        {
            get
            {
                return _brushType;
            }
            set
            {
                switch (value)
                {
                    case BrushType.Texture:
                        btnTools.Text = $"{BrushType.Texture.ToString()} brush";
                        break;
                    case BrushType.Gradient:
                        btnTools.Text = $"{BrushType.Gradient.ToString()} brush";
                        break;
                    default:
                        btnTools.Text = $"{BrushType.Solid.ToString()} brush";
                        break;
                }
                _brushType = value;
            }
        }
        public FormPaint()
        {
            InitializeComponent();

            graphicPanel = panelDraw.CreateGraphics();
            BrushSize = 1;
            selectedBrush = CreateBrush();
            Shape = ShapeSelected.None;

            buffer = new Bitmap(panelDraw.ClientSize.Width, panelDraw.ClientSize.Height);
            using (Graphics g = Graphics.FromImage(buffer))
            {
                g.Clear(panelDraw.BackColor);
            }
        }

        private Brush CreateBrush(BrushType type = BrushType.Solid)
        {
            Brush brush = default(Brush);
            switch (type)
            {
                case BrushType.Texture:
                    brush = CreateTextureBrush();
                    break;
                case BrushType.Gradient:
                    brush = new LinearGradientBrush(new Point(0, 0), new Point(panelDraw.Bounds.Width, panelDraw.Bounds.Height), Color.White, btnColors.BackColor);
                    break;
                default:
                    brush = new SolidBrush(btnColors.BackColor);
                    break;
            }

            return brush;
        }
        private TextureBrush CreateTextureBrush()
        {
            OpenFileDialog opf = new OpenFileDialog()
            {
                Filter = "PNG|*.png|Bitmap|*.bmp|JPEG|*.jpg|Icon|*.ico"
            };
            if (opf.ShowDialog() == DialogResult.OK)
            {
                Image imag = Image.FromFile(opf.FileName);
                return new TextureBrush(imag);
            }
            return default(TextureBrush);
        }
        private void btnColors_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog()
            {
                FullOpen = true,
                AllowFullOpen = true
            };
            if (cd.ShowDialog() == DialogResult.OK)
            {
                btnColors.BackColor = cd.Color;
            }
        }
        private void btnColors_BackColorChanged(object sender, EventArgs e)
        {
            if (SelectedBrushType != BrushType.Texture)
            {
                selectedBrush = CreateBrush(SelectedBrushType);
            }
        }
        private void BrushSizePicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (int.TryParse(e.ClickedItem.Text, out int newSize))
            {
                BrushSize = newSize;
            }
        }
        private void tbBrushSize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender is ToolStripTextBox box)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(box.Text, "[^0-9]"))
                    {
                        MessageBox.Show("Please enter only numbers.");
                        box.Text = box.Text.Remove(box.Text.Length - 1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnShapes_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                Shape = (ShapeSelected)Enum.Parse(typeof(ShapeSelected), e.ClickedItem.Text);
            }
            catch (Exception)
            {
                _shape = ShapeSelected.None;
                btnShapes.Image = noneToolStripMenuItem.Image;
            }
        }
        private void btnTools_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                SelectedBrushType = (BrushType)int.Parse(e.ClickedItem.Tag.ToString());
                selectedBrush = CreateBrush(SelectedBrushType);
                if(selectedBrush is null)
                {
                    selectedBrush = CreateBrush(BrushType.Solid);
                    SelectedBrushType = BrushType.Solid;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, $"{ex.HResult} - {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelDraw_MouseDown(object sender, MouseEventArgs e)
        {
            undoBitmaps.Push((Bitmap)buffer.Clone());
            redoBitmaps.Clear();
            switch (Shape)
            {
                case ShapeSelected.Square:
                    graphicPanel.FillRectangle(selectedBrush, e.X, e.Y, BrushSize * 6, BrushSize * 6);
                    using (Graphics g = Graphics.FromImage(buffer))
                    {
                        g.FillRectangle(selectedBrush, e.X, e.Y, BrushSize * 6, BrushSize * 6);
                    }
                    break;
                case ShapeSelected.Rectangle:
                    graphicPanel.FillRectangle(selectedBrush, e.X, e.Y, BrushSize * 9, BrushSize * 6);
                    using (Graphics g = Graphics.FromImage(buffer))
                    {
                        g.FillRectangle(selectedBrush, e.X, e.Y, BrushSize * 9, BrushSize * 6);
                    }
                    break;
                case ShapeSelected.Circle:
                    graphicPanel.FillEllipse(selectedBrush, e.X, e.Y, BrushSize * 6, BrushSize * 6);
                    using (Graphics g = Graphics.FromImage(buffer))
                    {
                        g.FillEllipse(selectedBrush, e.X, e.Y, BrushSize * 6, BrushSize * 6);
                    }
                    break;
                default:
                    lastPoint = e.Location;
                    canDraw = true;
                    break;
            }
        }
        private void panelDraw_MouseUp(object sender, MouseEventArgs e)
        {
            canDraw = false;

        }
        private void panelDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (canDraw)
            {
                graphicPanel.DrawLine(new Pen(selectedBrush, BrushSize), lastPoint, e.Location);
                using (Graphics g = Graphics.FromImage(buffer))
                {
                    g.DrawLine(new Pen(selectedBrush, BrushSize), lastPoint, e.Location);
                }
                lastPoint = e.Location;
            }
        }

        private void Undo(object sender, EventArgs e)
        {
            if (undoBitmaps.Count > 0)
            {
                redoBitmaps.Push((Bitmap)buffer.Clone());
                buffer = undoBitmaps.Pop();
                panelDraw.Refresh();
            }
        }
        private void Redo(object sender, EventArgs e)
        {
            if (redoBitmaps.Count > 0)
            {
                undoBitmaps.Push((Bitmap)redoBitmaps.Peek().Clone());
                buffer = redoBitmaps.Pop();
                panelDraw.Refresh();
            }
        }

        private void New(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Bitmap|*.bmp"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                buffer = new Bitmap(panelDraw.ClientSize.Width, panelDraw.ClientSize.Height);
                this.Text = $"{Path.GetFileName(sfd.FileName)} - Danilo's Paint";
                lastOpenedFileName = sfd.FileName;
                panelDraw.Refresh();
                undoBitmaps.Clear();
                redoBitmaps.Clear();
            }

        }
        private void Open(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Bitmap|*.bmp"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                buffer = new Bitmap(ofd.FileName);
                if (buffer.Width > panelDraw.Width)
                {
                    panelDraw.Width = buffer.Width;
                }
                if (buffer.Height > panelDraw.Height)
                {
                    panelDraw.Height = buffer.Height;
                }
                this.Text = $"{Path.GetFileName(ofd.FileName)} - Danilo's Paint";
                lastOpenedFileName = ofd.FileName;
                panelDraw.Refresh();
                undoBitmaps.Clear();
                redoBitmaps.Clear();
            }

        }
        private void Save(object sender, EventArgs e)
        {
            if (lastOpenedFileName.Equals(string.Empty))
            {
                SaveAs(sender, e);
            }
            else
            {
                SaveTo(lastOpenedFileName);
            }
        }
        private void SaveAs(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Bitmap|*.bmp"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (SaveTo(sfd.FileName))
                {
                    this.Text = $"{Path.GetFileName(sfd.FileName)} - Danilo's Paint";
                    lastOpenedFileName = sfd.FileName;
                }
            }
        }
        private bool SaveTo(string fileName)
        {
            try
            {
                buffer.Save(fileName);
                MessageBox.Show("File saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, $"{ex.HResult} - {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ClearPanel(object sender, EventArgs e)
        {
            graphicPanel.Clear(panelDraw.BackColor);
            using (Graphics g = Graphics.FromImage(buffer))
            {
                g.Clear(panelDraw.BackColor);
            }
        }
        private void Exit(object sender, EventArgs e)
        {
            try
            {
                string safeFileName = this.Text.Split(' ')[0];
                string msg = $"Do you want to save changes to {(lastOpenedFileName == string.Empty ? safeFileName : lastOpenedFileName)}";
                if (DialogResult.OK == MessageBox.Show(msg, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    Save(sender, e);
                }
            }
            catch { }
            finally
            {
                Application.Exit();
            }
        }
        private void FormPaint_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Exit(sender, new EventArgs());
            }
        }

        private void FormPaint_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush lgb = new LinearGradientBrush(this.ClientRectangle, this.BackColor, Color.FromArgb(0xDC, 0xE5, 0xF2), 90f);
            Graphics formGraphic = this.CreateGraphics();
            formGraphic.FillRectangle(lgb, this.ClientRectangle);
        }
        private void panelDraw_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(buffer, Point.Empty);
        }

        
    }
}
