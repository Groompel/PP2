using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Worm : GameObject
    {

        public Worm(char sign) : base(sign)
        {
            body.Add(new Point(20,20));
        }


        public bool CheckIntersection(List<Point> otherBody)
        {
            bool res = false;

            foreach(Point p in otherBody)
            {
                if(p.X == body[0].X && p.Y == body[0].Y)
                {
                    res = true;
                    break;
                }
                
            }
            return res;

        }

        public void Eat(List<Point> otherBody)
        {
            body.Add(new Point(otherBody[0].X, otherBody[0].Y));
        }

        public void Move(int dx, int dy)
        {
            Clear();
            for(int i = body.Count - 1; i > 0; i--)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }

            body[0].X += dx;
            body[0].Y += dy;


        }

    }
}
