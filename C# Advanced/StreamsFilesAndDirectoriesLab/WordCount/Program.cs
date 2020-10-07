using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
        
            string textPath = Path.Combine("Data", "text.txt");
            string wordsPath = Path.Combine("Data", "words.txt");

            var textReader = new StreamReader(textPath);
            var wordsReader = new StreamReader(wordsPath);

            using (textReader)
            {
                string line = textReader.ReadLine();

                using (wordsReader)
                {
                    string[] currWords = wordsReader
                        .ReadToEnd()
                        .ToString()
                        .ToLower()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string writerPath = Path.Combine("Data", "Output.txt");
                    var writer = new StreamWriter(writerPath);

                    while (line != null)
                    {
                        StringBuilder cleanLine = new StringBuilder();

                        for (int i = 0; i < line.Length; i++)
                        {
                            char currCharInLine = line[i];

                            if (char.IsLetterOrDigit(currCharInLine) || char.IsWhiteSpace(currCharInLine))
                            {
                                cleanLine.Append(currCharInLine);
                            }
                        }

                        string[] currLine = cleanLine
                            .ToString()
                            .ToLower()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                        for (int i = 0; i < currLine.Length; i++)
                        {
                            string currWordInLine = currLine[i];

                            for (int j = 0; j < currWords.Length; j++)
                            {
                                string currWord = currWords[j];

                                if (currWordInLine == currWord)
                                {
                                    if (!words.ContainsKey(currWord))
                                    {
                                        words.Add(currWord, 0);
                                    }

                                    words[currWord]++;
                                }
                            }
                        }

                        line = textReader.ReadLine();
                    }

                    using (writer)
                    {
                        words = words
                                    .OrderByDescending(n => n.Value)
                                    .ToDictionary(w => w.Key, n => n.Value); 

                        foreach (var word in words)
                        {
                            string currWord = $"{word.Key} - {word.Value}";

                            writer.WriteLine(currWord);
                        }
                    }
                }
            }
        }
    }
}
