using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Snake
{
    class Wall : GameObject
    {
        public Wall(char sign) : base(sign)
        {
            LoadLevel(1);
        }

        public void LoadLevel(int lvl)
        {
            string name = string.Format(@"C:\Users\Mukhammed\source\repos\Week6\Snake\bin\Debug\Level{0}.txt", lvl);

            using (StreamReader streamReader = new StreamReader(name))
            {
                int r = 0;
                

                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    for(int i =0; i < line.Length; i++)
                    { 

                        if (line[i] == '#')
                        {
                            body.Add(new Point(i, r));
                        }
                        
                    }
                    r++;
                }

            }


        }

    }
}
