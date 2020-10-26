using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int[,] garden = CreatMatrix(matrixSize[0], matrixSize[1]);

            string comand;

            while ((comand = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] currCordinates = comand
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int row = currCordinates[0];
                int col = currCordinates[1];

                if (row < 0 || row >= garden.GetLength(0)
                 || col < 0 || col >= garden.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                garden[row, col] = 1;
            }

            List<int[]> flowers = GetFlowerPosition(garden);

            BloomFlowers(garden, flowers);

            PrintMatrix(garden);
        }

        static void BloomFlowers(int[,] garden, List<int[]> flowers)
        {
            foreach (var flower in flowers)
            {
                int row = flower[0];
                int col = flower[1];

                for (int i = 0; i < garden.GetLength(1); i++)
                {
                    if (i != col)
                    {
                        garden[row, i]++;
                    }
                }

                for (int j = 0; j < garden.GetLength(0); j++)
                {
                    if (j != row)
                    {
                        garden[j, col]++;
                    }
                }
            }
        }

        static int[,] CreatMatrix(int rowSize, int colSize)
        {
            int[,] matrix = new int[rowSize, colSize];

            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < colSize; col++)
                {
                    matrix[row, col] = 0;
                }
            }

            return matrix;
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

        static List<int[]> GetFlowerPosition(int[,] matrix)
        {
            List<int[]> flowersPosition = new List<int[]>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 1)
                    {
                        int[] currPosition = new int[2];
                        currPosition[0] = row;
                        currPosition[1] = col;

                        flowersPosition.Add(currPosition);
                    }
                }
            }

            return flowersPosition;
        }
    }
}
