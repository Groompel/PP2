using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace Task1
{
    [Serializable]

    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Grade { get; set; }
        
        public Student(string name, string surname, int grade)
        {
            Name = name;
            Surname = surname;
            Grade = grade;
        }
        public override string ToString()
        {
            return string.Format("{0} {1} is in {2} grade", Name, Surname, Grade);
        }

    }
    [Serializable]

    class Group
    {
        public string Name { get; set; }
        public List<Student> students = new List<Student>();
        public Group(string name, List<Student> students)
        {
            Name = name;
            this.students = students;
        }
        public override string ToString()
        {
            return string.Format("The Groups' name is {0}", Name);
        }
    }
    [Serializable]
    class Department
    { 
        public string Name { get; set; }
        public List<Group> groups = new List<Group>();
        public Department(string name, List<Group> groups)
        {
            Name = name;
            this.groups = groups;
        }
        public override string ToString()
        {
            return string.Format("The Department's name is {0}", Name);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student> {
                new Student("John", "Wick", 1),
                new Student("Bravo", "Rak", 4),
                new Student("Bob", "George", 3),
                new Student("Frank", "Sinatra", 2),
            };

            List<Student> students2 = new List<Student> {
                new Student("John2", "2Wick", 1),
                new Student("Bravo2", "2Rak", 4),
                new Student("Bob2", "2George", 3),
                new Student("Frank2", "2Sinatra", 2),
            };

            List<Group> groups = new List<Group>
            {
                new Group("FIT", students),
                new Group("BS", students2),
            };

            Department department = new Department("18BD", groups);

            BinaryFormatter bf = new BinaryFormatter();

            FileStream fs = new FileStream("bf.xml", FileMode.OpenOrCreate);

            bf.Serialize(fs, department);

            department = null;
            fs.Close();
            fs = new FileStream("bf.xml", FileMode.Open);
            department = (Department)bf.Deserialize(fs);


            Console.WriteLine(department.ToString());
            Console.Read();





        }
    }
}
