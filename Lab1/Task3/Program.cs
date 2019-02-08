using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static int[] MakeDouble(int[] arr, int n)
        {
            int[] ar1 = new int[n * 2];
            int k = 0;
            for (int i = 0; i < n * 2; i++)
            {
                if (i % 2 == 0 && i != 0)
                    k++;
                ar1[i] = arr[k];

            }
            return ar1;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            int[] arr = new int[n];
            string[] sa = s.Split();
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(sa[i]);
            }

            int[] arrnew = MakeDouble(arr, n);

            for (int i = 0; i < arrnew.Length; i++)
            {
                Console.Write(arrnew[i] + " ");
            }


        }
    }
}
