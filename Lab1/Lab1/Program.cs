using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        //creating a method that will check whether the given number is prime
        public static bool IsPrime(int n)
        {
            //since 0 and 1 are not prime numbers
            if (n == 1 || n == 0)
                return false;

            //cycle which goes from 2 to the square root if the number and divides the number by it
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            //if the method dind't return false until now it is prime
            return true;
        }


        static void Main(string[] args)
        {
            //Getting the number
            int n = int.Parse(Console.ReadLine());
            //Creating an array
            int[] a = new int[n];
            //Getting the whole line of numbers
            string s = Console.ReadLine();
            //Spliting it and collecting it in string array
            string[] sa = s.Split(' ');

            //The cycle to assign every string value to the array of ints
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(sa[i]);
            }
            //Creating a counter variable to count the number
            int cnt = 0;
            //Counting the number of primes
            for (int i = 0; i < n; i++)
            {
                if (IsPrime(a[i]))
                    cnt++;
            }

            //Writing the number of primes
            Console.WriteLine(cnt);
            //Writing all the prime number
            for (int i = 0; i < n; i++)
            {
                if (IsPrime(a[i]))
                    Console.Write(a[i] + " ");
            }

        }
    }
}
