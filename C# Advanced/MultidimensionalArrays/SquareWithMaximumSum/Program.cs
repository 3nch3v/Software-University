using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = ReadMatrix(size[0], size[1]);

            int maxSum = int.MinValue;
            int topLeftRow = 0;
            int topLeftCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currSquareSum = matrix[row,col]
                                        + matrix[row + 1, col]
                                        + matrix[row, col + 1]
                                        + matrix[row + 1 , col + 1];
                    if (currSquareSum > maxSum)
                    {
                        maxSum = currSquareSum;
                        topLeftRow = row;
                        topLeftCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[topLeftRow, topLeftCol]} {matrix[topLeftRow, topLeftCol + 1]}\r\n"  +
                              $"{matrix[topLeftRow + 1, topLeftCol]} {matrix[topLeftRow + 1, topLeftCol + 1]}");
           Console.WriteLine(maxSum);
        }

        static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
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
