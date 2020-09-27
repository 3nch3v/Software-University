using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = ReadMatrix(size[0], size[1]);

            int startRowIndex = -1;
            int startColIndex = -1;
            int maxSum = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                                  + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] 
                                  + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        startRowIndex = row;
                        startColIndex = col;
                    }

                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            PrintSquareMatrixWithMaxSum(matrix, startRowIndex, startColIndex);
        }

        static void PrintSquareMatrixWithMaxSum(int[,] matrix, int startRowIndex, int startColIndex)
        {
            for (int row = startRowIndex; row <= startRowIndex + 2; row++)
            {
                for (int col = startColIndex; col <= startColIndex + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
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
