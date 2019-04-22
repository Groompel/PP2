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
            };
            gp1.AddPolygon(t1);
        }

    }
}
