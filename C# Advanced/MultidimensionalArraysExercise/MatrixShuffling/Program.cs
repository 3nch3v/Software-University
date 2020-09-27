using System;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = ReadMatrix(size[0], size[1]);

            string comand;

            while ((comand = Console.ReadLine()) != "END")
            {
                string[] currArgs = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (comand.Contains("swap") && currArgs.Length == 5)
                {
                    int firstNumRow = int.Parse(currArgs[1]);
                    int firstNumCol = int.Parse(currArgs[2]);
                    int secondNumRow = int.Parse(currArgs[3]);
                    int secondNumCol = int.Parse(currArgs[4]);

                    if (firstNumRow >= 0 && firstNumRow < matrix.GetLength(0)
                                         && firstNumCol >= 0 && firstNumCol < matrix.GetLength(1)
                                         && secondNumRow >= 0 && secondNumRow < matrix.GetLength(0)
                                         && secondNumCol >= 0 && secondNumCol < matrix.GetLength(1))
                    {
                        string temp = matrix[firstNumRow, firstNumCol];

                        matrix[firstNumRow, firstNumCol] = matrix[secondNumRow, secondNumCol];
                        matrix[secondNumRow, secondNumCol] = temp;

                        PrintMatrix(matrix);
                    }

                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }

                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }

        }
        static string[,] ReadMatrix(int rows, int cols)
        {
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            return matrix;
        }
    }
}
