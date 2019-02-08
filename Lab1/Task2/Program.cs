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
        public int YearOfStudy { get; set; }
        public Student(string n, string i)
        {
            Name = n;
            Id = i;
        }
        public void IncrementYearOfStudy()
        {
            YearOfStudy++;
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
