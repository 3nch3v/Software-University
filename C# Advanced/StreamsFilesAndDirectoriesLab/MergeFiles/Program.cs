using System;
using System.IO;

namespace MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileOnePath = Path.Combine("Data", "FileOne.txt");
            string fileTwoPath = Path.Combine("Data", "FileTwo.txt");

            StreamReader fileOne = new StreamReader(fileOnePath);
            var fileTwo = new StreamReader(fileTwoPath);

            using (fileOne)
            {
                string firstLine = fileOne.ReadLine();

                using (fileTwo)
                {
                    string secondLine = fileTwo.ReadLine();

                    string outputPath = Path.Combine("Data", "Output.txt");
                    var writer = new StreamWriter(outputPath);

                    using (writer)
                    {
                        while (firstLine != null && secondLine != null)
                        {
                            writer.WriteLine(firstLine);
                            writer.WriteLine(secondLine);

                            firstLine = fileOne.ReadLine();
                            secondLine = fileTwo.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
