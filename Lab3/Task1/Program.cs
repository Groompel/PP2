using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Layer
    {
        public FileSystemInfo[] Content
        {
            get; set;
        }
        public int SelectedItem = 0;

        public void Draw()
        {
            Console.Clear();
            for(int i = 0; i <  Content.Length; i++)
            {
                Console.WriteLine(Content[i].Name);
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Test";
            DirectoryInfo dir = new DirectoryInfo(path);
            Stack<Layer> hist = new Stack<Layer>();
            hist.Push(new Layer
            {
                Content = dir.GetFileSystemInfos(),
                SelectedItem = 0,

            });

            while (true)
            {
                hist.Peek().Draw();
            }
        }

        
    }
}
