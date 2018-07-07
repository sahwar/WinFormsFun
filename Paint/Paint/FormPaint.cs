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
using System.Drawing.Imaging;

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
        // fields
        private string _lastOpenedFileName = string.Empty;

        private Point _lastPoint = new Point(0, 0);
        private Brush _selectedBrush = default(Brush);
        private Graphics _graphicPanel = default(Graphics);
        private bool _canDraw = false;
        
        private Stack<Bitmap> _undoBitmaps = new Stack<Bitmap>();
        private Stack<Bitmap> _redoBitmaps = new Stack<Bitmap>();

        private bool _hasBufferChanged = false;
        private Bitmap _buffer = default(Bitmap);
        private int _brushSize = default(int);
        private ShapeSelected _shape = ShapeSelected.None;
        private BrushType _brushType = BrushType.Solid;

        // props
        public Bitmap Buffer
        {
            get
            {
                return _buffer;
            }
            set
            {
                _buffer = value;
                _hasBufferChanged = true;
            }
        }
        public int BrushSize
        {
            get => _brushSize;
            set
            {
                btnBrushSize.Text = value.ToString();
                _brushSize = value;
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

        // ctor
        public FormPaint()
        {
            InitializeComponent();

            _graphicPanel = panelDraw.CreateGraphics();
            BrushSize = 1;
            _selectedBrush = CreateBrush();
            Shape = ShapeSelected.None;

            try
            {
                Buffer = new Bitmap(panelDraw.ClientSize.Width, panelDraw.ClientSize.Height);
                using (Graphics g = Graphics.FromImage(Buffer))
                {
                    g.Clear(panelDraw.BackColor);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, $"type:{ex.GetType()}, source:{ex.Source}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // methods
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
                _selectedBrush = CreateBrush(SelectedBrushType);
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
                _selectedBrush = CreateBrush(SelectedBrushType);
                if(_selectedBrush is null)
                {
                    _selectedBrush = CreateBrush(BrushType.Solid);
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
            try
            {
                _undoBitmaps.Push((Bitmap)Buffer.Clone());
                _redoBitmaps.Clear();
                switch (Shape)
                {
                    case ShapeSelected.Square:
                        _graphicPanel.FillRectangle(_selectedBrush, e.X, e.Y, BrushSize * 6, BrushSize * 6);
                        using (Graphics g = Graphics.FromImage(Buffer))
                        {
                            g.FillRectangle(_selectedBrush, e.X, e.Y, BrushSize * 6, BrushSize * 6);
                        }
                        break;
                    case ShapeSelected.Rectangle:
                        _graphicPanel.FillRectangle(_selectedBrush, e.X, e.Y, BrushSize * 9, BrushSize * 6);
                        using (Graphics g = Graphics.FromImage(Buffer))
                        {
                            g.FillRectangle(_selectedBrush, e.X, e.Y, BrushSize * 9, BrushSize * 6);
                        }
                        break;
                    case ShapeSelected.Circle:
                        _graphicPanel.FillEllipse(_selectedBrush, e.X, e.Y, BrushSize * 6, BrushSize * 6);
                        using (Graphics g = Graphics.FromImage(Buffer))
                        {
                            g.FillEllipse(_selectedBrush, e.X, e.Y, BrushSize * 6, BrushSize * 6);
                        }
                        break;
                    default:
                        _lastPoint = e.Location;
                        _canDraw = true;
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, $"type:{ex.GetType()}, source:{ex.Source}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void panelDraw_MouseUp(object sender, MouseEventArgs e)
        {
            _canDraw = false;
        }
        private void panelDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (_canDraw)
            {
                try
                {
                    _graphicPanel.DrawLine(new Pen(_selectedBrush, BrushSize), _lastPoint, e.Location);
                    using (Graphics g = Graphics.FromImage(Buffer))
                    {
                        g.DrawLine(new Pen(_selectedBrush, BrushSize), _lastPoint, e.Location);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, $"type:{ex.GetType()}, source:{ex.Source}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                _lastPoint = e.Location;
            }
        }

        private void Undo(object sender, EventArgs e)
        {
            if (_undoBitmaps.Count > 0)
            {
                try
                {
                    _redoBitmaps.Push((Bitmap)Buffer.Clone());
                    Buffer = _undoBitmaps.Pop();
                    panelDraw.Refresh();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, $"type:{ex.GetType()}, source:{ex.Source}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Redo(object sender, EventArgs e)
        {
            if (_redoBitmaps.Count > 0)
            {
                try
                {
                    _undoBitmaps.Push((Bitmap)Buffer.Clone());
                    Buffer = _redoBitmaps.Pop();
                    panelDraw.Refresh();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, $"type:{ex.GetType()}, source:{ex.Source}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                if (_hasBufferChanged)
                {
                    SaveIfUserWants(sender, e);
                }
                _undoBitmaps.Clear();
                _redoBitmaps.Clear();
                Buffer.Dispose();
                try
                {
                    Buffer = new Bitmap(panelDraw.ClientSize.Width, panelDraw.ClientSize.Height);
                    this.Text = $"{Path.GetFileName(sfd.FileName)} - Danilo's Paint";
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, $"type:{ex.GetType()}, source:{ex.Source}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                _lastOpenedFileName = sfd.FileName;
                panelDraw.Refresh();
            }
        }
        private void Open(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Bitmap|*.bmp|JPEG|*.jpg|PNG|*.png|Icon|*.ico"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (_hasBufferChanged)
                    {
                        SaveIfUserWants(sender, e);
                    }
                    _undoBitmaps.Clear();
                    _redoBitmaps.Clear();
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        Image image = Image.FromStream(fs);
                        using (Graphics g = Graphics.FromImage(Buffer))
                        {
                            g.DrawImage(image, Point.Empty);
                        }
                    }
                    this.Text = $"{Path.GetFileName(ofd.FileName)} - Danilo's Paint";
                    _lastOpenedFileName = ofd.FileName;
                    panelDraw.Refresh();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, $"type:{ex.GetType()}, source:{ex.Source}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Save(object sender, EventArgs e)
        {
            if (_lastOpenedFileName.Equals(string.Empty))
            {
                SaveAs(sender, e);
            }
            else
            {
                SaveTo(_lastOpenedFileName);
            }
        }
        private void SaveAs(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Bitmap|*.bmp|JPEG|*.jpg|PNG|*.png|Icon|*.ico"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (SaveTo(sfd.FileName))
                    {
                        this.Text = $"{Path.GetFileName(sfd.FileName)} - Danilo's Paint";
                        _lastOpenedFileName = sfd.FileName;
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, $"source:{ex.Source}", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private bool SaveTo(string fileName)
        {
            try
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
                    {
                        string extension = Path.GetExtension(fileName);
                        switch (extension)
                        {
                            case ".jpg":
                                Buffer.Save(memory, ImageFormat.Jpeg);
                                break;
                            case ".png":
                                Buffer.Save(memory, ImageFormat.Png);
                                break;
                            case ".ico":
                                Buffer.Save(memory, ImageFormat.Icon);
                                break;
                            default:
                                Buffer.Save(memory, ImageFormat.Bmp);
                                break;
                        }
                        byte[] bytes = memory.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
                MessageBox.Show("File saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _hasBufferChanged = false;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, $"{ex.HResult} - {ex.GetType()}", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private void SaveIfUserWants(object sender, EventArgs e)
        {
            try
            {
                string safeFileName = this.Text.Split(' ')[0];
                string msg = $"Do you want to save changes to {(_lastOpenedFileName == string.Empty ? safeFileName : _lastOpenedFileName)}";
                if (DialogResult.OK == MessageBox.Show(msg, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    Save(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, $"type:{ex.GetType()}, source:{ex.Source}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearPanel(object sender, EventArgs e)
        {
            try
            {
                _graphicPanel.Clear(panelDraw.BackColor);
                using (Graphics g = Graphics.FromImage(Buffer))
                {
                    g.Clear(panelDraw.BackColor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Exit(object sender, EventArgs e)
        {
            try
            {
                if (_hasBufferChanged)
                {
                    SaveIfUserWants(sender, e);
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
            try
            {
                LinearGradientBrush lgb = new LinearGradientBrush(this.ClientRectangle, this.BackColor, Color.FromArgb(0xDC, 0xE5, 0xF2), 90f);
                Graphics formGraphic = this.CreateGraphics();
                formGraphic.FillRectangle(lgb, this.ClientRectangle);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void panelDraw_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.DrawImage(Buffer, Point.Empty);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
    }
}
