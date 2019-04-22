using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food : GameObject
    {
        public Food(char sign) : base(sign)
        {

            Generate();
        }

        public void Generate()
        {
            body.Clear();

            Random rand = new Random(DateTime.Now.Second);
            body.Add(new Point(rand.Next(0, 39), rand.Next(0, 39)));

        }
    }
}
