using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = size[0];
            int cols = size[1];

            char[,] matrix = new char[rows, cols];


            char[] snake = Console.ReadLine().ToCharArray();
            int snakeLength = snake.Length;


            Queue<char> fullTheMatrix = new Queue<char>();

            int matrixCapacity = rows * cols;
            int counter = 0;

            for (int i = 0; i < snakeLength; i++)
            {
                fullTheMatrix.Enqueue(snake[i]);
                counter++;

                if (matrixCapacity == counter)
                {
                    break;
                }

                if (i == snakeLength - 1)
                {
                    i = -1;
                }
            }


            FillTheMatrix(matrix, fullTheMatrix);

            PrintMatrix(matrix);

        }
        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
        static char[,] FillTheMatrix(char[,] matrix, Queue<char> fullTheMatrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = fullTheMatrix.Dequeue();
                    }
                }

                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = fullTheMatrix.Dequeue();
                    }
                }
            }

            return matrix;
        }
    }
    
}
