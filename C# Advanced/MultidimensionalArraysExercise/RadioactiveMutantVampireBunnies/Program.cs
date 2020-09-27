using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = size[0];
            int cols = size[1]; 

            char[,] lair = new char[rows, cols];

            ReadMatrixAlements(lair);


            int currRow = -1;
            int currCol = -1;

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row, col] == 'P')
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
            }


            bool isDead = false;
            bool isWon = false;

            char[] directions = Console.ReadLine().ToCharArray();

            for (int i = 0; i < directions.Length; i++)
            {
                char currMove = directions[i];

                if (currMove == 'U')
                {
                    int newRow = currRow - 1;
                    int newCol = currCol;

                    if (newRow < 0)
                    {
                        lair[currRow, currCol] = '.';
                        isWon = true;
                    }

                    else if (lair[newRow, newCol] == '.')
                    {
                        lair[currRow, currCol] = '.';
                        lair[newRow, newCol] = 'P';

                        currRow = newRow;
                        currCol = newCol;
                    }

                    else if (lair[newRow, newCol] == 'B')
                    {
                        currRow = newRow;
                        currCol = newCol;
                        isDead = true;
                    }

                    RabbitMultiplication(lair);

                    bool isCached = RabbitCachedPlayerChecker(lair);

                    if (isCached)
                    {
                        isDead = true;
                    }

                    if (isDead)
                    {
                        break;
                    }

                    if (isWon)
                    {
                        break;
                    }
                }

                else if (currMove == 'D')
                {
                    int newRow = currRow + 1;
                    int newCol = currCol;

                    if (newRow > lair.GetLength(0) - 1)
                    {
                        lair[currRow, currCol] = '.';
                        isWon = true;
                    }

                    else if (lair[newRow, newCol] == '.')
                    {
                        lair[currRow, currCol] = '.';
                        lair[newRow, newCol] = 'P';

                        currRow = newRow;
                        currCol = newCol;
                    }

                    else if (lair[newRow, newCol] == 'B')
                    {
                        currRow = newRow;
                        currCol = newCol;
                        isDead = true;
                    }

                    RabbitMultiplication(lair);

                    bool isCached = RabbitCachedPlayerChecker(lair);

                    if (isCached)
                    {
                        isDead = true;
                    }

                    if (isDead)
                    {
                        break;
                    }

                    if (isWon)
                    {
                        break;
                    }
                }

                else if (currMove == 'L')
                {
                    int newRow = currRow;
                    int newCol = currCol - 1;

                    if (newCol < 0)
                    {
                        lair[currRow, currCol] = '.';
                        isWon = true;
                    }

                    else if (lair[newRow, newCol] == '.')
                    {
                        lair[currRow, currCol] = '.';
                        lair[newRow, newCol] = 'P';

                        currRow = newRow;
                        currCol = newCol;
                    }

                    else if (lair[newRow, newCol] == 'B')
                    {
                        currRow = newRow;
                        currCol = newCol;
                        isDead = true;
                    }

                    RabbitMultiplication(lair);

                    bool isCached = RabbitCachedPlayerChecker(lair);

                    if (isCached && !isWon)
                    {
                        isDead = true;
                    }

                    if (isDead)
                    {
                        break;
                    }

                    if (isWon)
                    {
                        break;
                    }
                }

                else if (currMove == 'R')
                {
                    int newRow = currRow;
                    int newCol = currCol + 1;

                    if (newCol > lair.GetLength(1) - 1)
                    {
                        lair[currRow, currCol] = '.';
                        isWon = true;
                    }

                    else if (lair[newRow, newCol] == '.')
                    {
                        lair[currRow, currCol] = '.';
                        lair[newRow, newCol] = 'P';

                        currRow = newRow;
                        currCol = newCol;
                    }

                    else if (lair[newRow, newCol] == 'B')
                    {
                        currRow = newRow;
                        currCol = newCol;
                        isDead = true;
                    }

                    RabbitMultiplication(lair);

                    bool isCached = RabbitCachedPlayerChecker(lair);

                    if (isCached)
                    {
                        isDead = true;
                    }

                    if (isDead)
                    {
                        break;
                    }

                    if (isWon)
                    {
                        break;
                    }
                }
            }


            PrintLair(lair);

            if (isDead)
            {
                Console.WriteLine($"dead: {currRow} {currCol}");
            }

            if (isWon)
            {
                Console.WriteLine($"won: {currRow} {currCol}");
            }

        }

        static bool RabbitCachedPlayerChecker(char[,] lair)
        {
            bool isCached = true;

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row, col] == 'P')
                    {
                        isCached = false;
                    }
                }
            }

            return isCached;
        }

        static char[,] RabbitMultiplication(char[,] lair)
        {
            Queue<int> indexes = new Queue<int>();

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row,col] == 'B')
                    {
                        indexes.Enqueue(row);
                        indexes.Enqueue(col);
                    }
                }
            }

            while (indexes.Count > 0)
            {
                int row = indexes.Dequeue();
                int col = indexes.Dequeue();

                if (row - 1 >= 0)
                {
                    lair[row - 1, col] = 'B';
                }

                if (row + 1 < lair.GetLength(0))
                {
                    lair[row + 1, col] = 'B';
                }

                if (col - 1 >= 0)
                {
                    lair[row, col - 1] = 'B';
                }

                if (col + 1 < lair.GetLength(0))
                {
                    lair[row, col + 1] = 'B';
                }
            }

            return lair;
        }

        static void PrintLair(char[,] lair)
        {
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    Console.Write(lair[row, col]);
                }

                Console.WriteLine();
            }
        }

        static char[,] ReadMatrixAlements(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            return matrix;
        }
    }
}
