using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceTest
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics graphics;
        Pen pen;
        int x = 50;
        int y = 30;
        int cnt = 0;
        
        public Form1()
        {
            
            InitializeComponent();
            pen = new Pen(Color.Blue, 7);
            
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
            
            pictureBox1.Image = bitmap;

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;

            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
           
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void DrawDay()
        {
            
            this.BackColor = Color.DarkBlue;
            graphics.Clear(Color.Orange);
            graphics.FillRectangle(new SolidBrush(Color.Green), 0, 250, 780, 250);


            graphics.FillEllipse(new SolidBrush(Color.Yellow), x, y, 30, 30);

            /*
            Point[] spaceship =
            {
                new Point(x, y),
                new Point(x + 40, y + 20),
                new Point(x + 40, y + 50),
                new Point(x, y + 70),
                new Point(x - 40, y + 50),
                new Point(x - 40, y + 20),
            };

            SolidBrush yellow = new SolidBrush(Color.Yellow);
            graphics.FillPolygon(yellow, spaceship);

            SolidBrush brown = new SolidBrush(Color.Brown);
            //ics.FillPath(brown, as3.gp1);
            */
            Refresh();
        }


        private void DrawNight()
        {

            graphics.Clear(Color.DarkBlue);
            graphics.FillRectangle(new SolidBrush(Color.Green), 0, 250, 780, 250);


            graphics.FillEllipse(new SolidBrush(Color.White), x, y, 30, 30);

            Point[] star =
            {
                new Point(330, 100),
                new Point(20, 20),
                new Point(20, 50),
                new Point(50,  70),
                new Point(20, 50),
                new Point(20, 20),
            };
            graphics.FillPolygon(new SolidBrush(Color.Yellow), star);
            Refresh();
        }
            private void timer1_Tick(object sender, EventArgs e)
        {

            x += 200;
           
            if (cnt < 3)
            { 
                if(cnt % 6 == 0)
                {
                    x = 50; y = 30;
                }
                DrawDay();
            }
            else
            {
                if(cnt % 6 == 3)
                {
                    x = 50; y = 30;
                }
                DrawNight();
            }
            cnt = (cnt + 1) % 6;
        }
    }
}
