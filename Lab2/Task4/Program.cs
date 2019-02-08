using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Test\B\Red";
            string path1 = @"C:\Test\B\Red\Blue";
            string fileName = "TestFolder1";
            using (File.Create(Path.Combine(path, fileName)))
            {
            };
            File.Copy(Path.Combine(path, fileName), Path.Combine(path1, fileName), true);
            File.Delete(Path.Combine(path, fileName));

        }
    }
}
