using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExerciseOne_Basic_ui
{
    public partial class EtchASketch : Form
    {
        float posX, posY;
        float lineSize = 2;
        const int lineSpeedMilli = 10;
        Graphics drawingPanelGraphics;
        static System.Windows.Forms.Timer loopTimer = new System.Windows.Forms.Timer();

        public EtchASketch()
        {
            InitializeComponent();
            drawingPanelGraphics = drawingPanel.CreateGraphics();

            posX = drawingPanel.Width / 2;
            posY = drawingPanel.Height / 2;

            loopTimer.Enabled = false;
            loopTimer.Interval = lineSpeedMilli;

            if(!float.TryParse(tbSpeed.Text, out lineSize))
            {
                lineSize = 2;
            }
            
        }
        private  void MouseUpEvent(object sender, MouseEventArgs e)
        {
            loopTimer.Enabled = false;
            if (sender is Button btn)
            {
                switch (btn.Name)
                {
                    case "btnUp":
                        loopTimer.Tick -= new EventHandler(btnUp_Click);
                        break;
                    case "btnDown":
                        loopTimer.Tick -= new EventHandler(btnDown_Click);
                        break;
                    case "btnLeft":
                        loopTimer.Tick -= new EventHandler(btnLeft_Click);
                        break;
                    case "btnRight":
                        loopTimer.Tick -= new EventHandler(btnRight_Click);
                        break;
                    default:
                        break;
                }
            }

        }
        private  void MouseDownEvent(object sender, MouseEventArgs e)
        {
            if (sender is Button btn)
            {
                switch (btn.Name)
                {
                    case "btnUp":
                        loopTimer.Tick += new EventHandler(btnUp_Click);
                        break;
                    case "btnDown":
                        loopTimer.Tick += new EventHandler(btnDown_Click);
                        break;
                    case "btnLeft":
                        loopTimer.Tick += new EventHandler(btnLeft_Click);
                        break;
                    case "btnRight":
                        loopTimer.Tick += new EventHandler(btnRight_Click);
                        break;
                    default:
                        break;
                }
            }
            loopTimer.Enabled = true;
        }
        public static void Clip(ref float val, float maxSize, float minSize = 0)
        {
            if(val >= maxSize)
            {
                val = maxSize - 1;
            }
            else if(val < minSize)
            {
                val = 0;
            }
        }
        public static void Clip(ref float row, ref float col, float maxRow, float maxCol)
        {
            Clip(ref row, maxRow);
            Clip(ref col, maxCol);
        }
        private void DrawLineAndUpdate(ref float oldPosX, ref float oldPosY, float newPosX, float newPosY)
        {
            Clip(ref newPosX, ref newPosY, drawingPanel.Width, drawingPanel.Height);
            drawingPanelGraphics.DrawLine(new Pen(Color.Red), oldPosX, oldPosY, newPosX, newPosY);
            oldPosX = newPosX;
            oldPosY = newPosY;
        }
        private void btnLeft_Click(object sender, EventArgs e)
        {
            float newX = posX - lineSize;
            float newY = posY;
            DrawLineAndUpdate(ref posX, ref posY, newX, newY);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            float newX = posX;
            float newY = posY - lineSize;
            DrawLineAndUpdate(ref posX, ref posY, newX, newY);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            float newX = posX + lineSize;
            float newY = posY;
            DrawLineAndUpdate(ref posX, ref posY, newX, newY);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            float newX = posX;
            float newY = posY + lineSize;
            DrawLineAndUpdate(ref posX, ref posY, newX, newY);
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            drawingPanelGraphics.Clear(Color.White);
            posX = drawingPanel.Width / 2;
            posY = drawingPanel.Height / 2;
        }

        private void TryUpdateSpeed(object sender, EventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (!float.TryParse(tb.Text, out lineSize))
                {
                    lineSize = 2;
                }
            }
        }

        private void EtchASketch_Load(object sender, EventArgs e)
        {

        }
    }
}
