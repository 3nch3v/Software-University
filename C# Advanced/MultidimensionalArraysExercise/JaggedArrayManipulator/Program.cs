using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[numberOfRows][];

            ReadJaggedArray(jaggedArray);

            JaggedArrayManipulation(jaggedArray);

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = inputArgs[0];
                int row = int.Parse(inputArgs[1]);
                int col = int.Parse(inputArgs[2]);
                int value = int.Parse(inputArgs[3]);

                if (command == "Add")
                {
                    if ((row >= 0 && row < jaggedArray.Length)
                        && (col >= 0 && col < jaggedArray[row].Length))
                    {
                        jaggedArray[row][col] += value;
                    }
                }

                else if (command == "Subtract")
                {
                    if ((row >= 0 && row < jaggedArray.Length)
                        && (col >= 0 && col < jaggedArray[row].Length))
                    {
                        jaggedArray[row][col] -= value;
                    }
                }
            }

            PrintMatrix(jaggedArray);
        }

        static void PrintMatrix(double[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
        static double[][] JaggedArrayManipulation(double[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                int currRowLength = matrix[row].Length;
                int nextRowLength = matrix[row + 1].Length;

                if (currRowLength == nextRowLength)
                {
                    for (int col = 0; col < currRowLength; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row + 1][col] *= 2;
                    }
                }

                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] /= 2;
                    }

                    for (int col = 0; col < matrix[row + 1].Length; col++)
                    {
                        matrix[row + 1][col] /= 2;
                    }
                }
            }

            return matrix;
        }
        static double[][] ReadJaggedArray(double[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                double[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                matrix[row] = input;
            }

            return matrix;
        }
    }
}
