using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[3];

            Thread f = new Thread(new ThreadStart(Output));
            for(int i = 0; i < 3; i++)
            {
                threads[i] = new Thread(new ThreadStart(Output));
            }

            threads[0].Name = "Thread #1";
            threads[1].Name = "Thread #2";
            threads[2].Name = "Thread #3";

            for (int i = 0; i < 3; i++)
            {
                threads[i].Start();
            }

            Console.ReadLine();
        }
        static void Output()
        {
            Console.WriteLine(Thread.CurrentThread.Name);
        }
    }
}
