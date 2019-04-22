using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Point
    {

        private int x;
        private int y;


        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = Filter(value);
            }
        }

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = Filter(value);
            }
        }

        int Filter(int value)
        {
            if (value < 0) value = 39;
            else if (value > 39) value = 0;
            return value;
        }



        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }
}
