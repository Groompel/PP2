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

namespace _10Balls
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics graphics;

        List<Ball> balls = new List<Ball>
            {
                new Ball(new Point(35, 100), Color.Green),
                new Ball(new Point(123, 305), Color.Green),
                new Ball(new Point(564, 341), Color.Purple),
                new Ball(new Point(100, 200), Color.Yellow),
                new Ball(new Point(231, 300), Color.Yellow),
                new Ball(new Point(35,300), Color.CornflowerBlue),
                new Ball(new Point(135, 234), Color.CornflowerBlue),
                new Ball(new Point(123, 30), Color.Red),
                new Ball(new Point(335, 45), Color.Purple),
                new Ball(new Point(43, 43), Color.Red),

            };

       // Random rand = new Random(DateTime.Now.Millisecond);
        
        public Form1()
        {
            
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
           
        }

        void CheckBalls()
        {
            foreach (Ball b in balls)
            {
                foreach (Ball b1 in balls)
                {
                    if (b.Color == b1.Color && b1.Selected && b.Selected && b != b1)
                    {
                        b.Deleted = true;
                        b1.Deleted = true;
                    }
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            CheckBalls();

            foreach(Ball b in balls)
            {
                if (!b.Deleted)
                {
                    e.Graphics.FillEllipse(new SolidBrush(b.Color), b.Location.X - 25, b.Location.Y - 25, 50, 50);
                    if (b.Selected)
                        e.Graphics.DrawEllipse(new Pen(Color.Black, 5), b.Location.X - 25, b.Location.Y - 25, 50, 50);
                }
            }
            
            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (Ball b in balls)
            {
                if (Math.Pow(e.X - (b.Location.X), 2) + Math.Pow(e.Y - (b.Location.Y),2) <= 25 * 25)
                {
                    b.Selected = !b.Selected;
                    Refresh();
                }
            }
        }
    }
}
