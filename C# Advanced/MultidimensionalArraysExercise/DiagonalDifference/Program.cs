using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = ReadMatrix(size, size);

            int primaryDiagonalSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = row; col <= row; col++)
                {
                    primaryDiagonalSum += matrix[row, col];
                }
            }

            int secondaryDiagonalSum = 0;
            int rowCounter = 0;

            for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
            {
                for (int row = rowCounter; row <= rowCounter; row++)
                {
                    secondaryDiagonalSum += matrix[row, col];
                }

                rowCounter++;
            }

            decimal result = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);

            Console.WriteLine(result);
        }

        static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
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
