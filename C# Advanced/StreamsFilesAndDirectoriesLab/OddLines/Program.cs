using System;
using System.IO;

namespace OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("Data", "Input.txt");
            var fileReader = new StreamReader(path);

            using (fileReader)
            {
                int counter = 0;

                string line = fileReader.ReadLine();

                string output = Path.Combine("Data", "Output.txt");
                var fileWriter = new StreamWriter(output); 

                using (fileWriter)
                {
                    while (line != null)
                    {
                        if (counter % 2 != 0)
                        {
                            fileWriter.WriteLine(line);
                        }

                        line = fileReader.ReadLine();
                        counter++;
                    }
                }
            }
        }
    }
}
