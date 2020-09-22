using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int squareMatrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = ReadMatrix(squareMatrixSize, squareMatrixSize);

            int primaryDiagonalSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = row; col <= row; col++)
                {
                    primaryDiagonalSum += matrix[row, col];
                }
            }

            Console.WriteLine(PrimaryDiagonalSum(matrix));
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

        static int PrimaryDiagonalSum(int[,] matrix)
        {
            int primaryDiagonalSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = row; col <= row; col++)
                {
                    primaryDiagonalSum += matrix[row, col];
                }
            }

            return primaryDiagonalSum;
        }
    }
}
