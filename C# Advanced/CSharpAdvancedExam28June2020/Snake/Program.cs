using System;
using System.Collections.Generic;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] territory = ReadMatrix(size);


            int snakeRow = -1;
            int snakeCol = -1;

            Queue<int> burrow = new Queue<int>();

            for (int row = 0; row < size; row++)
            {
                char snake = 'S';

                for (int col = 0; col < size; col++)
                {
                    if (territory[row, col] == snake)
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }

                    if (territory[row, col] == 'B')
                    {
                        burrow.Enqueue(row);
                        burrow.Enqueue(col);
                    }
                }
            }

            int foodQuantity = 0;

            while (true)
            {
                if (foodQuantity >= 10)
                {
                    break;
                }

                string move = Console.ReadLine();

                territory[snakeRow, snakeCol] = '.';

                int[] newCordinats = GetNewPostiont(move, snakeRow, snakeCol);

                int newRow = newCordinats[0];
                int newCol = newCordinats[1];

                if (newRow < 0 || newRow >= territory.GetLength(0)
                    || newCol < 0 || newCol >= territory.GetLength(1))
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if (territory[newRow, newCol] == '*')
                {
                    foodQuantity++;
                    territory[newRow, newCol] = 'S';
                    snakeRow = newRow;
                    snakeCol = newCol;
                }

                else if (territory[newRow, newCol] == '-')
                {
                    territory[newRow, newCol] = 'S';
                    snakeRow = newRow;
                    snakeCol = newCol;
                }

                else if (territory[newRow, newCol] == 'B')
                {
                    int firstRow = burrow.Dequeue();
                    int firstCol = burrow.Dequeue();
                    int secondRow = burrow.Dequeue();
                    int secondCol = burrow.Dequeue();

                    if (newRow == firstRow && newCol == firstCol)
                    {
                        territory[newRow, newCol] = '.';
                        snakeRow = secondRow;
                        snakeCol = secondCol;
                        territory[secondRow, secondCol] = 'S';
                     
                    }

                    else
                    {
                        territory[newRow, newCol] = '.';
                        snakeRow = firstRow;
                        snakeCol = firstCol;
                        territory[firstRow, firstCol] = 'S';
                    }
                }
            }

            if (foodQuantity >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodQuantity}");

            PrintMatrix(territory);
        }

        static int[] GetNewPostiont(string move, int row, int col)
        {
            int[] newCordinats = new int[2];

            if (move == "up")
            {
                newCordinats[0] = row - 1;
                newCordinats[1] = col;
            }

            else if (move == "down")
            {
                newCordinats[0] = row + 1;
                newCordinats[1] = col;
            }

            else if (move == "left")
            {
                newCordinats[0] = row;
                newCordinats[1] = col - 1;
            }

            else if (move == "right")
            {
                newCordinats[0] = row;
                newCordinats[1] = col + 1;
            }

            return newCordinats;
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

        static char[,] ReadMatrix(int size)
        {
            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            return matrix;
        }
    }
}
