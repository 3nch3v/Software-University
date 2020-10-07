using System;
using System.IO;

namespace FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("TestFolder");

            double sum = 0;

            foreach (var file in files)
            {
                FileInfo currFileInfo = new FileInfo(file);
                sum += currFileInfo.Length;
            }

            sum = sum / 1024 / 1024;
            File.WriteAllText("output.txt", sum.ToString());
        }
    }
}
