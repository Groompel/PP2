using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{


    class Program
    {
        static bool IsPrime(int n)
        {
            if (n == 0 || n == 1)
                return false;
            for(int i = 2; i <= Math.Sqrt(n); i++)
            {
                if(n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            string s = System.IO.File.ReadAllText(@"C:\Test\InOut\input.txt");
            string[] sa = s.Split(' ');
            int[] arr = new int[sa.Length];
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(sa[i]);
            }

            int cnt = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (IsPrime(arr[i]))
                    {
                    cnt++;
                    }
                }
            string[] primes = new string[cnt];
            int k = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (IsPrime(arr[i]))
                {
                    primes[k] = arr[i].ToString();
                    k++;
                }
            }

            File.WriteAllText(@"C:\Test\InOut\output.txt", string.Join(" ", primes));

        }
    }
}
