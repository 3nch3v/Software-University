using System;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] table = new char[n, n];
            table = ReadMatrix(table);

            int knightCounter = 0;

            while (true)
            {
                int mostDangerous = 0;
                int positionRow = -1;
                int positionCol = -1;

                for (int row = 0; row < table.GetLength(0); row++)
                {
                    for (int col = 0; col < table.GetLength(1); col++)
                    {
                        int dangerousIndex = 0;
                        char currChar = table[row, col];

                        if (currChar == 'K')
                        {
                            char knight = table[row, col];

                            int upLeftRow = row - 2;
                            int upLeftCol = col - 1;
                            int upRightRow = row - 2;
                            int upRightCol = col + 1;

                            int downLeftRow = row + 2;
                            int downLeftCol = col - 1;
                            int downRightRow = row + 2;
                            int downRightCol = col + 1;

                            int leftUpRow = row - 1;
                            int leftUpCol = col - 2;
                            int leftDownRow = row + 1;
                            int leftDownCol = col - 2;

                            int rightUpRow = row - 1;
                            int rightUpCol = col + 2;
                            int rightDownRow = row + 1;
                            int rightDownCol = col + 2;

                            if ((upLeftRow >= 0 && upLeftCol >= 0)
                                && table[upLeftRow, upLeftCol] == knight)
                            {
                                dangerousIndex++;
                            }

                            if ((upRightRow >= 0 && upRightCol < table.GetLength(1))
                                && table[upRightRow, upRightCol] == knight)
                            {
                                dangerousIndex++;
                            }

                            if ((downLeftRow < table.GetLength(0) && downLeftCol >= 0)
                                && table[downLeftRow, downLeftCol] == knight)
                            {
                                dangerousIndex++;
                            }

                            if ((downRightRow < table.GetLength(0) && downRightCol < table.GetLength(1))
                                && table[downRightRow, downRightCol] == knight)
                            {
                                dangerousIndex++;
                            }

                            if ((leftUpRow >= 0 && leftUpCol >= 0)
                                && table[leftUpRow, leftUpCol] == knight)
                            {
                                dangerousIndex++;
                            }

                            if ((leftDownRow < table.GetLength(0) && leftDownCol >= 0)
                               && table[leftDownRow, leftDownCol] == knight)
                            {
                                dangerousIndex++;
                            }

                            if ((rightUpRow >= 0 && rightUpCol < table.GetLength(1))
                              && table[rightUpRow, rightUpCol] == knight)
                            {
                                dangerousIndex++;
                            }

                            if ((rightDownRow < table.GetLength(0) && rightDownCol < table.GetLength(1))
                             && table[rightDownRow, rightDownCol] == knight)
                            {
                                dangerousIndex++;
                            }

                            if (dangerousIndex > mostDangerous)
                            {
                                mostDangerous = dangerousIndex;
                                positionRow = row;
                                positionCol = col;
                            }
                        }
                    }
                }

                if (positionRow != -1)
                {
                    table[positionRow, positionCol] = '0';

                    knightCounter++;

                    mostDangerous = 0;
                    positionRow = -1;
                    positionCol = -1;
                }

                else
                {
                    break;
                }
            }

            Console.WriteLine(knightCounter);
        }

        static char[,] ReadMatrix(char[,] matrix)
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
