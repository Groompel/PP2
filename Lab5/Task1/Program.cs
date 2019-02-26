using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
namespace Task1
{
    [Serializable()]
    public class ComplexNumber : ISerializable
    {
        public double A { get; set; }
        public double B { get; set; }

        public ComplexNumber()
        {

        }
        
        public ComplexNumber(double A, double B)
        {
            this.A = A;
            this.B = B;
        }

        public ComplexNumber(SerializationInfo info, StreamingContext context)
        {
            A = (double)info.GetValue("A", typeof(double));
            B = (double)info.GetValue("B", typeof(double));

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("A", A);
            info.AddValue("B", B);

        }

        public override string ToString()
        {
            return string.Format("The Complex Number has the real number {0} and the imaginary number {1}", A, B);
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber cn = new ComplexNumber(522, 32.3);

            XmlSerializer sr = new XmlSerializer(typeof(ComplexNumber));

            using (FileStream fs = File.Create(@"C:\Test\cn.xml"))
            {
                sr.Serialize(fs, cn);
            }

            cn = null;

            using (FileStream fs = File.Open(@"C:\Test\cn.xml", FileMode.Open))
            {
                cn = (ComplexNumber)sr.Deserialize(fs);
            }

            Console.WriteLine(cn.ToString());

            Console.ReadLine();

        }
    }
}
