using System;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int jaggedArrayRows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = ReadJaggedArray(jaggedArrayRows);

            string cmd;

            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] currCmd = cmd
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string comand = currCmd[0];

                int row = int.Parse(currCmd[1]);
                int col = int.Parse(currCmd[2]);
                int value = int.Parse(currCmd[3]);

                if (comand == "Add")
                {
                    if (CheckCordinates(jaggedArray, row, col))
                    {
                        jaggedArray[row][col] += value;
                    }

                    else
                    {
                        PrintIvalidCordinatesMassage();
                    }
                }

                else if (comand == "Subtract")
                {
                    if (CheckCordinates(jaggedArray, row, col))
                    {
                        jaggedArray[row][col] -= value;
                    }

                    else
                    {
                        PrintIvalidCordinatesMassage();
                    }
                }
            }

            PrintMatrix(jaggedArray);
        }

        static int[][] ReadJaggedArray(int rows)
        {
            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[row] = new int[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    jaggedArray[row][col] = input[col];
                }
            }

            return jaggedArray;
        }

        static void PrintMatrix(int[][] jaggedArray)
        {
            foreach (var row in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", row));
            }

        }

        static bool CheckCordinates(int[][] jaggedArray, int row, int col)
        {
            bool isValid = false;

            if (row >= 0
                && row < jaggedArray.Length
                && col >= 0
                && col < jaggedArray[row].Length)
            {
                isValid = true;
            }

            return isValid;
        }

        static void PrintIvalidCordinatesMassage()
        {
            Console.WriteLine("Invalid coordinates");
        }
    }
}
