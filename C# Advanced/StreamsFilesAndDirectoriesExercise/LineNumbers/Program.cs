using System;
using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("Data", "text.txt");

            StreamReader textReader = new StreamReader(path);

            using (textReader)
            {
                int lineNumber = 1;
                string writerPath = Path.Combine("Data", "output.txt");
                StreamWriter writer = new StreamWriter(writerPath);

                using (writer)
                {
                    while (true)
                    {
                        string line = textReader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        string numberedLine = $"Line {lineNumber}: {line}";
                        writer.WriteLine(numberedLine);

                        lineNumber++;
                    }
                }
            }
        }
    }
}
