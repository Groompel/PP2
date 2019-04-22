using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceTest
{
    class Asteroid
    {

        int x, y;
        public GraphicsPath gp1;
        public GraphicsPath gp2;

        public Asteroid(int x, int y)
        {
            this.x = x;
            this.y = y;
            gp1 = new GraphicsPath();
            gp2 = new GraphicsPath();

        }

        public void Move()
        {
            x += 10;
            if(x > 780)
            {
                x = 0;
            }
            gp1.Reset();
            gp2.Reset();
            Point[] t1 =
            {
                new Point(x, y),
                new Point(x + 20, y),
                new Point(x + 30, y + 20),
                new Point(x + 10, y - 20),
                new Point(x - 15, y + 10),
                new Point(x - 45, y - 10),
                new Point(x + 35, y - 35),

            };
            gp1.AddPolygon(t1);
        }

    }
}
