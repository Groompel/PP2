using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Paint
{
    enum Tools
    {
        Pencil,
        Line,
        Rectangle,
        Ellipse,
        Fill,
        Eraser,
        Figure,
    }
    
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics graphics;
        Point firstPoint;
        Point secondPoint;
        Pen eraser;
        int brushWidth = 1;
        int eraserWidth = 1;
        Pen pen;
        Tools currTool = Tools.Pencil;

        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Blue, brushWidth);
            eraser = new Pen(Color.White, eraserWidth);
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            pictureBox1.Image = bitmap;

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            eraser.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            eraser.EndCap = System.Drawing.Drawing2D.LineCap.Round;

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;
            if(currTool == Tools.Fill)
            {
              //  MapFill
            }
            
        }


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (currTool)
            {
                case Tools.Line:
                    graphics.DrawLine(pen, firstPoint, secondPoint);
                    break;
                case Tools.Rectangle:
                    graphics.DrawRectangle(pen, GetRectangle(firstPoint, secondPoint));
                    break;
                case Tools.Ellipse:
                    graphics.DrawEllipse(pen, GetRectangle(firstPoint, secondPoint));
                    break;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            switch (currTool)
            {
                case Tools.Ellipse:
                    e.Graphics.DrawEllipse(pen, GetRectangle(firstPoint, secondPoint));
                    break;
                case Tools.Line:
                    e.Graphics.DrawLine(pen, firstPoint, secondPoint);
                    break;
                case Tools.Rectangle:
                    e.Graphics.DrawRectangle(pen, GetRectangle(firstPoint, secondPoint));
                    break;

            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                secondPoint = e.Location;
                switch (currTool)
                {
                    case Tools.Pencil:
                        graphics.DrawLine(pen, firstPoint, secondPoint);
                        firstPoint = secondPoint;
                        break;
                    case Tools.Eraser:
                        graphics.DrawLine(eraser, firstPoint, secondPoint);
                        firstPoint = secondPoint;
                        break;

                }
                pictureBox1.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currTool = Tools.Pencil;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currTool = Tools.Line;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currTool = Tools.Rectangle;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currTool = Tools.Ellipse;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currTool = Tools.Fill;
        }

        Rectangle GetRectangle(Point p1, Point p2) 
        {
            Rectangle res = new Rectangle();
            res.X = Math.Min(p1.X, p2.X);
            res.Y = Math.Min(p1.Y, p2.Y);
            res.Width = Math.Abs(p1.X - p2.X);
            res.Height = Math.Abs(p1.Y - p2.Y);
            return res;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            brushWidth = (int) numericUpDown1.Value;
            pen.Width = brushWidth;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currTool = Tools.Eraser;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            eraserWidth = (int)numericUpDown2.Value;
            eraser.Width = eraserWidth;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            currTool = Tools.Figure;
        }
    }
}
