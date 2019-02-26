using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Student
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int YearOfStudy { get; set; };
        public Student(string n, string id)
        {
            Name = n;
            Id = id;
        }
        public void IncrementYearOfStudy()
        {
            YearOfStudy++;
        }

        public static void Hello()
        {
            Console.WriteLine("Hello");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            
            Student s = new Student("John", "18BD00777")
            {
                YearOfStudy = 1
            };
            Console.WriteLine(s.Name + " na " + s.YearOfStudy);
            s.IncrementYearOfStudy();
            Console.WriteLine(s.Name + " teper' na " + s.YearOfStudy);
           
        }
    }
}
