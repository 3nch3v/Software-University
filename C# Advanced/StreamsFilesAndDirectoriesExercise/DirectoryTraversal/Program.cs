using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(@".\");

            string[] filesInfo = Directory.GetFiles(path);

            Dictionary<string, Dictionary<string, double>> dataInfo = new Dictionary<string, Dictionary<string, double>>();

            foreach (var file in filesInfo)
            {
                FileInfo currFile = new FileInfo(file);

                string fileExtension = currFile.Extension;
                string fileName = currFile.Name;
                double size = currFile.Length / 1024.0;

                if (!dataInfo.ContainsKey(fileExtension))
                {
                    dataInfo.Add(fileExtension, new Dictionary<string, double>());
                }

                dataInfo[fileExtension].Add(fileName, size);
            }

            dataInfo = dataInfo
                         .OrderByDescending(f => f.Value.Count)
                         .ThenBy(n => n.Key)
                         .ToDictionary(n => n.Key, f => f.Value);

            StringBuilder output = new StringBuilder();

            foreach (var (extension, fileInfo) in dataInfo)
            {
                output.AppendLine(extension);

                Dictionary<string, double> orderedFilesInfo= fileInfo
                    .OrderBy(s => s.Value)
                    .ToDictionary(f => f.Key, s => s.Value);

                foreach (var (fileName, size) in orderedFilesInfo)
                {
                    output.AppendLine($"--{fileName} - {size:f3}kb");
                }
            }

            string outputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "output.txt");
            File.WriteAllText(outputPath, output.ToString());
        }
    }
}
