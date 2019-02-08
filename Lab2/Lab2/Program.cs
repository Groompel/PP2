using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPal = true;
            string s = Console.ReadLine();
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] != s[s.Length - i - 1])
                {
                    isPal = false;
                    break;
                }
            }
            if (isPal)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }
    }
}
