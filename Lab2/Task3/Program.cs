using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Test";
            DirectoryInfo dir = new DirectoryInfo(path);
            PrintInfo(dir, 1);
        }

       private static void PrintInfo(FileSystemInfo fsi, int k)
        {
            string s = new string(' ', k);
            s = s + fsi.Name;
            Console.WriteLine(s);
            if(fsi.GetType() == typeof(DirectoryInfo))
            {
                var items = (fsi as DirectoryInfo).GetFileSystemInfos();
                foreach(var i in items)
                {
                    PrintInfo(i,k +4);
                }
            }
        }
    }
}
