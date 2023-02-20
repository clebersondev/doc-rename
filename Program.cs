using System;
using System.IO;

namespace DocRename
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootPath = @"C:\Users\Cleberson\Desktop\teste";

            string[] files = Directory.GetFiles(rootPath);

            foreach(string file in files)
            {
                if(file.Contains(' '))
                {
                    string renameFile = Path.GetFullPath(file.Replace(" ",""));
                    File.Move(file, renameFile);
                }                
            }
            Console.WriteLine("All done!");
            Console.Read();
        }
    }
}