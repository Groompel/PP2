using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
namespace Task2
{
    [Serializable()]
    public class Mark : ISerializable
    {
        public double Points { get; set; }
        public Mark(double Points)
        {
            this.Points = Points;
        }

        public string GetLetter()
        {
            if (Points < 50)
                return "F";
            if (Points >= 50 && Points < 70)
                return "C-";
            if (Points >= 70 && Points < 75)
                return "C";
            if (Points >= 75 && Points < 80)
                return "B";
            if (Points >= 80 && Points < 85)
                return "B+";
            if (Points >= 90 && Points < 95)
                return "A-";
            else
                return "A";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Points", Points);
        }
        
        public Mark()
        {

        }

        public Mark(SerializationInfo info, StreamingContext context)
        {
            Points = (double)info.GetValue("Points", typeof(double));
        }

        public override string ToString()
        {
            return string.Format("The number of points is: {0} \n The letter: {1}", Points, GetLetter());
        }


    }
    class Program
    {

        static void Main(string[] args)
        {
            List<Mark> marks = new List<Mark>
            {
                new Mark(84),
                new Mark(34),
                new Mark(85),
                new Mark(35),
                new Mark(74),
            };

            XmlSerializer ser = new XmlSerializer(typeof(List<Mark>));

            using (FileStream fs = File.Create(@"C:\Test\marks.xml"))
            {
                ser.Serialize(fs, marks);
            }

            marks = null;

            using (FileStream fs = File.Open(@"C:\Test\marks.xml", FileMode.Open))
            {
                marks = (List<Mark>)ser.Deserialize(fs);
            }

            foreach(Mark i in marks)
            {
                Console.WriteLine(i.ToString());
            }

            Console.ReadLine();

        }
    }
}
