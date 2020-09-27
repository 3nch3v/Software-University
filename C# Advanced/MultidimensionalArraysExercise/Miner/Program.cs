using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[] directions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            char[,] matrix = new char[size, size];
            ReadMatrixAlements(matrix);

            int currPositionRow = -1;
            int currPostionCol = -1;

            int maxCoal = 0;
            int currCoal = 0;

            int endIndexRow = -1;
            int endIndexCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char currElement = matrix[row, col];

                    if (currElement == 'c')
                    {
                        maxCoal++;
                    }
                    else if (currElement == 'e')
                    {
                        endIndexRow = row;
                        endIndexCol = col;
                    }
                    else if (currElement == 's')
                    {
                        currPositionRow = row;
                        currPostionCol = col;
                    }
                }
            }

            for (int i = 0; i < directions.Length; i++)
            {
                string move = directions[i];

                if (move == "up")
                {
                    int newRowIndex = currPositionRow - 1;
                    int newColIndex = currPostionCol;

                    if (newRowIndex >= 0)
                    {
                        if (matrix[newRowIndex, newColIndex] == 'c')
                        {
                            currCoal++;

                            if (currCoal == maxCoal)
                            {
                                Console.WriteLine($"You collected all coals! ({newRowIndex}, {newColIndex})");
                                return;
                            }

                            matrix[currPositionRow, currPostionCol] = '*';
                            matrix[newRowIndex, newColIndex] = 's';

                            currPositionRow = newRowIndex;
                            currPostionCol = newColIndex;
                        }

                        else if (matrix[newRowIndex, newColIndex] == 'e')
                        {
                            Console.WriteLine($"Game over! ({newRowIndex}, {newColIndex})");
                            return;
                            
                        }

                        else
                        {
                            matrix[currPositionRow, currPostionCol] = '*';
                            matrix[newRowIndex, newColIndex] = 's';

                            currPositionRow = newRowIndex;
                            currPostionCol = newColIndex;
                        }
                    }
                }

                else if (move == "down")
                {
                    int newRowIndex = currPositionRow + 1;
                    int newColIndex = currPostionCol;

                    if (newRowIndex < matrix.GetLength(0))
                    {
                        if (matrix[newRowIndex, newColIndex] == 'c')
                        {
                            currCoal++;

                            if (currCoal == maxCoal)
                            {
                                Console.WriteLine($"You collected all coals! ({newRowIndex}, {newColIndex})");
                                return;
                            }

                            matrix[currPositionRow, currPostionCol] = '*';
                            matrix[newRowIndex, newColIndex] = 's';

                            currPositionRow = newRowIndex;
                            currPostionCol = newColIndex;
                        }

                        else if (matrix[newRowIndex, newColIndex] == 'e')
                        {
                            Console.WriteLine($"Game over! ({newRowIndex}, {newColIndex})");
                            return;

                        }

                        else
                        {
                            matrix[currPositionRow, currPostionCol] = '*';
                            matrix[newRowIndex, newColIndex] = 's';

                            currPositionRow = newRowIndex;
                            currPostionCol = newColIndex;
                        }
                    }
                }

                else if (move == "left")
                {
                    int newRowIndex = currPositionRow;
                    int newColIndex = currPostionCol - 1;

                    if (newColIndex >= 0)
                    {
                        if (matrix[newRowIndex, newColIndex] == 'c')
                        {
                            currCoal++;

                            if (currCoal == maxCoal)
                            {
                                Console.WriteLine($"You collected all coals! ({newRowIndex}, {newColIndex})");
                                return;
                            }

                            matrix[currPositionRow, currPostionCol] = '*';
                            matrix[newRowIndex, newColIndex] = 's';

                            currPositionRow = newRowIndex;
                            currPostionCol = newColIndex;
                        }

                        else if (matrix[newRowIndex, newColIndex] == 'e')
                        {
                            Console.WriteLine($"Game over! ({newRowIndex}, {newColIndex})");
                            return;

                        }

                        else
                        {
                            matrix[currPositionRow, currPostionCol] = '*';
                            matrix[newRowIndex, newColIndex] = 's';

                            currPositionRow = newRowIndex;
                            currPostionCol = newColIndex;
                        }
                    }
                }

                else if (move == "right")
                {
                    int newRowIndex = currPositionRow;
                    int newColIndex = currPostionCol + 1;

                    if (newColIndex < matrix.GetLength(1))
                    {
                        if (matrix[newRowIndex, newColIndex] == 'c')
                        {
                            currCoal++;

                            if (currCoal == maxCoal)
                            {
                                Console.WriteLine($"You collected all coals! ({newRowIndex}, {newColIndex})");
                                return;
                            }

                            matrix[currPositionRow, currPostionCol] = '*';
                            matrix[newRowIndex, newColIndex] = 's';

                            currPositionRow = newRowIndex;
                            currPostionCol = newColIndex;
                        }

                        else if (matrix[newRowIndex, newColIndex] == 'e')
                        {
                            Console.WriteLine($"Game over! ({newRowIndex}, {newColIndex})");
                            return;

                        }

                        else
                        {
                            matrix[currPositionRow, currPostionCol] = '*';
                            matrix[newRowIndex, newColIndex] = 's';

                            currPositionRow = newRowIndex;
                            currPostionCol = newColIndex;
                        }
                    }
                }
            }

            int remainingCoals = maxCoal - currCoal;
            Console.WriteLine($"{remainingCoals} coals left. ({currPositionRow}, {currPostionCol})");
        }

        static char[,] ReadMatrixAlements(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
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
