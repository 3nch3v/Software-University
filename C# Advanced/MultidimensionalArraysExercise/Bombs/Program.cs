using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixLength = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixLength, matrixLength];

            FillTheMatrix(matrixLength, matrix);

            string[] cordinates = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int c = 0; c < cordinates.Length; c++)
            {
                int[] currBomb = cordinates[c]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int row = currBomb[0];
                int col = currBomb[1];

                if (matrix[row, col] > 0)
                {
                    if ((row - 1 >= 0 && col - 1 >= 0) && matrix[row - 1, col - 1] > 0)
                    {
                        matrix[row - 1, col - 1] -= matrix[row, col];
                    }

                    if (row - 1 >= 0 && matrix[row - 1, col] > 0)
                    {
                        matrix[row - 1, col] -= matrix[row, col];
                    }

                    if ((row - 1 >= 0 && col + 1 < matrixLength) && matrix[row - 1, col + 1] > 0)
                    {
                        matrix[row - 1, col + 1] -= matrix[row, col];
                    }

                    if (col - 1 >= 0 && matrix[row, col - 1] > 0)
                    {
                        matrix[row, col - 1] -= matrix[row, col];
                    }

                    if (col + 1 < matrixLength && matrix[row, col + 1] > 0)
                    {
                        matrix[row, col + 1] -= matrix[row, col];
                    }

                    if ((row + 1 < matrixLength && col - 1 >= 0) && matrix[row + 1, col - 1] > 0)
                    {
                        matrix[row + 1, col - 1] -= matrix[row, col];
                    }

                    if (row + 1 < matrixLength && matrix[row + 1, col] > 0)
                    {
                        matrix[row + 1, col] -= matrix[row, col];
                    }

                    if ((row + 1 < matrixLength && col + 1 < matrixLength) && matrix[row + 1, col + 1] > 0)
                    {
                        matrix[row + 1, col + 1] -= matrix[row, col];
                    }

                    matrix[row, col] = 0;
                }
            }

            int aliveCellsSum = 0;
            int counter = 0;

            foreach (var number in matrix)
            {
                if (number > 0)
                {
                    aliveCellsSum += number;
                    counter++;
                }
            }

            Console.WriteLine($"Alive cells: {counter}");
            Console.WriteLine($"Sum: {aliveCellsSum}");
            PrintMatrix(matrix);
        }

        static void PrintMatrix(int[,] matrix)
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

        private static void FillTheMatrix(int size, int[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                int[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
