using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace _10Balls
{
    class Ball
    {
        public Point Location { get; set; }
        public Color Color { get; set; }
        public bool Selected { get; set; }
        public bool Deleted { get; set; }
            
        public Ball(Point location, Color color)
        {
            this.Location = location;
            this.Color = color;
            Selected = false;
            Deleted = false;
        }

    }
}
