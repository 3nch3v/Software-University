using System;
using System.IO;
using System.IO.Compression;

namespace ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine("Data");
            string zipPath = Path.Combine("result.zip");
            string extractPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "extract");

            ZipFile.CreateFromDirectory(filePath, zipPath);
            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}
