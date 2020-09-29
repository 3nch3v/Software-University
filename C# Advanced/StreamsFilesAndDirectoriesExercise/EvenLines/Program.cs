using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("Data", "text.txt");
            StreamReader textReader = new StreamReader(path);

            using (textReader)
            {
                string line = textReader.ReadLine();

                StringBuilder result = new StringBuilder(line);

                int counter = 0;

                while (line != null)
                {
                    if (counter % 2 == 0)
                    {
                        for (int i = 0; i < result.Length; i++)
                        {
                            char currCahr = result[i];

                            if (currCahr == '-'
                                || currCahr == ','
                                || currCahr == '.'
                                || currCahr == '!'
                                || currCahr == '?')
                            {
                                result.Replace(result[i], '@');
                            }
                        }

                        string[] currLine = result.ToString()
                                                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                     .Reverse()
                                                     .ToArray();

                        Console.WriteLine(string.Join(" ", currLine));
                    }

                    line = textReader.ReadLine();
                    result.Clear();
                    result.Append(line);
                    counter++;
                }
            }
        }
    }
}
