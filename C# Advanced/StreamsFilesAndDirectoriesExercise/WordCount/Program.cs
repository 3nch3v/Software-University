using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string textPath = Path.Combine("Data", "text.txt");
            string[] texReader = File.ReadAllLines(textPath);

            string wordsPath = Path.Combine("Data", "words.txt");
            string[] wordsReader = File.ReadAllLines(wordsPath);

            Dictionary<string, int> wordsCounter = new Dictionary<string, int>();

            foreach (var line in texReader)
            {
                string[] wordsInLine = line
                    .ToLower()
                    .Split(new char[] {'-', ',', ' ', '.', '?', '!'}, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in wordsReader)
                {
                    string currWord = word.ToLower();

                    foreach (var lineWord in wordsInLine)
                    {
                        if (currWord == lineWord)
                        {
                            if (!wordsCounter.ContainsKey(currWord))
                            {
                                wordsCounter.Add(currWord, 0);
                            }

                            wordsCounter[currWord]++;
                        }
                    }
                }
            }

            wordsCounter = wordsCounter
                .OrderByDescending(n => n.Value)
                .ToDictionary(w => w.Key, n => n.Value);

            string resultPath = Path.Combine("Data", "actualResult.txt");

            foreach (var word in wordsCounter)
            {
                string wordInfo = $"{word.Key} - {word.Value}";
                File.AppendAllText(resultPath, wordInfo + Environment.NewLine);
            }
        }
    }
}
