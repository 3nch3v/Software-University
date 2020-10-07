using System;
using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("Data", "Input.txt");
            var reader = new StreamReader(path);

            using (reader)
            {
                string line = reader.ReadLine();

                string outputPath = Path.Combine("Data", "Output.txt");
                var writer = new StreamWriter(outputPath);

                using (writer)
                {
                    int counter = 1; 

                    while (line != null)
                    {
                        string nemberedLine = $"{counter}. {line}";
                        writer.WriteLine(nemberedLine);

                        line = reader.ReadLine();
                        counter++;
                    }
                }
            }


        }
    }
}
