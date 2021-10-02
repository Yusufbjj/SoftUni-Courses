using System;
using System.IO;

namespace _6._Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderPath = Console.ReadLine();
            var files = Directory.GetFiles(folderPath);
            long fileSizes = 0;
            foreach (var filePath in files)
            {
                FileInfo file = new FileInfo(filePath);
                Console.WriteLine(file.FullName);
                Console.WriteLine(file.Length);
                Console.WriteLine(file.Extension);
                fileSizes += file.Length;
            }

            Console.WriteLine(fileSizes/1024.0/1024.0);
        }
    }
}
