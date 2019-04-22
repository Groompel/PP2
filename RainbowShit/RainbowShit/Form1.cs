using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainbowShit
{
    public partial class Form1 : Form
    {

        Bitmap bitmap;
        Graphics graphics;
        int[] widths =
        {
            0,
            50,
        };
        int step = 5;
        Point mouse;
        int x = 100, y = 100;

        public Form1()
        {
            InitializeComponent();

            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
            SolidBrush red = new SolidBrush(Color.Red);

            
        


            graphics.FillEllipse(red, x, y, 50, 50);

        }

        void Draw()
        {
            graphics.Clear(Color.White);
            SolidBrush red = new SolidBrush(Color.Red);
            SolidBrush purple = new SolidBrush(Color.Purple);

            graphics.FillEllipse(red, x, y, 50, 50);


            Refresh();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse = e.Location;
            timer1.Enabled = true;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush red = new SolidBrush(Color.Red);

            graphics.FillEllipse(red, x, y, 50, 50);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (y < mouse.Y)
                y += step;
            if (y > mouse.Y)
                y -= step;
            if (x < mouse.X)
                x += step;
            if(x > mouse.X)
                x -= step;

            Draw();

            if (x == mouse.X && y == mouse.Y)
                timer1.Enabled = false;


        }
    }
}
