using System;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] field = new char[size, size];

            field = FullMatrix(size);

            int beeRow = -1;
            int beeCol = -1;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    char currElement = field[row, col];

                    if (currElement == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            int pollinatedFlowers = 0;
            bool beeGotLost = false;
            string cmd;

            while ((cmd = Console.ReadLine()) != "End")
            { 
                if (cmd == "up")
                {
                    if (beeRow - 1 >= 0)
                    {
                        if (field[beeRow - 1, beeCol] == '.')
                        {
                            field[beeRow, beeCol] = '.';
                            field[beeRow - 1, beeCol] = 'B';
                            beeRow -= 1;
                        }

                        else if (field[beeRow - 1, beeCol] == 'f')
                        {
                            pollinatedFlowers++;
                            field[beeRow, beeCol] = '.';
                            field[beeRow - 1, beeCol] = 'B';
                            beeRow -= 1;
                        }

                        else if (field[beeRow - 1, beeCol] == 'O')
                        {
                            field[beeRow, beeCol] = '.';
                            field[beeRow - 1, beeCol] = '.';

                            if (beeRow - 2 >= 0)
                            {
                                if (field[beeRow - 2, beeCol] == 'f')
                                {
                                    pollinatedFlowers++;
                                }

                                field[beeRow - 2, beeCol] = 'B';
                                beeRow -= 2;
                            }

                            else
                            {
                                beeGotLost = true;
                                break;
                            }
                        }
                    }

                    else
                    {
                        beeGotLost = true;
                        field[beeRow, beeCol] = '.';
                        break;
                    }
                }

                else if (cmd == "down")
                {
                    if (beeRow + 1 < field.GetLength(0))
                    {
                        if (field[beeRow + 1, beeCol] == '.')
                        {
                            field[beeRow, beeCol] = '.';
                            field[beeRow + 1, beeCol] = 'B';
                            beeRow += 1;
                        }

                        else if (field[beeRow + 1, beeCol] == 'f')
                        {
                            pollinatedFlowers++;
                            field[beeRow, beeCol] = '.';
                            field[beeRow + 1, beeCol] = 'B';
                            beeRow += 1;
                        }

                        else if (field[beeRow + 1, beeCol] == 'O')
                        {
                            field[beeRow, beeCol] = '.';
                            field[beeRow + 1, beeCol] = '.';

                            if (beeRow + 2 < field.GetLength(0))
                            {
                                if (field[beeRow + 2, beeCol] == 'f')
                                {
                                    pollinatedFlowers++;
                                }

                                field[beeRow + 2, beeCol] = 'B';
                                beeRow += 2;
                            }

                            else
                            {
                                beeGotLost = true;
                                break;
                            }
                        }
                    }

                    else
                    {
                        beeGotLost = true;
                        field[beeRow, beeCol] = '.';
                        break;
                    }
                }

                else if (cmd == "left")
                {
                    if (beeCol - 1 >= 0)
                    {
                        if (field[beeRow, beeCol - 1] == '.')
                        {
                            field[beeRow, beeCol] = '.';
                            field[beeRow, beeCol - 1] = 'B';
                            beeCol -= 1;
                        }

                        else if (field[beeRow, beeCol - 1] == 'f')
                        {
                            pollinatedFlowers++;
                            field[beeRow, beeCol] = '.';
                            field[beeRow, beeCol - 1] = 'B';
                            beeCol -= 1;
                        }

                        else if (field[beeRow, beeCol - 1] == 'O')
                        {
                            field[beeRow, beeCol] = '.';
                            field[beeRow, beeCol - 1] = '.';

                            if (beeCol - 2 >= 0)
                            {
                                if (field[beeRow, beeCol - 2] == 'f')
                                {
                                    pollinatedFlowers++;
                                }

                                field[beeRow, beeCol - 2] = 'B';
                                beeCol -= 2;
                            }

                            else
                            {
                                beeGotLost = true;
                                break;
                            }
                        }
                    }

                    else
                    {
                        beeGotLost = true;
                        field[beeRow, beeCol] = '.';
                        break;
                    }
                }

                else if (cmd == "right")
                {
                    if (beeCol + 1 < field.GetLength(1))
                    {
                        if (field[beeRow, beeCol + 1] == '.')
                        {
                            field[beeRow, beeCol] = '.';
                            field[beeRow, beeCol + 1] = 'B';
                            beeCol += 1;
                        }

                        else if (field[beeRow, beeCol + 1] == 'f')
                        {
                            pollinatedFlowers++;
                            field[beeRow, beeCol] = '.';
                            field[beeRow, beeCol + 1] = 'B';
                            beeCol += 1;
                        }

                        else if (field[beeRow, beeCol + 1] == 'O')
                        {
                            field[beeRow, beeCol] = '.';
                            field[beeRow, beeCol + 1] = '.';

                            if (beeCol + 2 < field.GetLength(1))
                            {
                                if (field[beeRow, beeCol + 2] == 'f')
                                {
                                    pollinatedFlowers++;
                                }

                                field[beeRow, beeCol + 2] = 'B';
                                beeCol += 2;
                            }

                            else
                            {
                                beeGotLost = true;
                                break;
                            }
                        }
                    }

                    else
                    {
                        beeGotLost = true;
                        field[beeRow, beeCol] = '.';
                        break;
                    }
                }
            }

            if (beeGotLost)
            {
                Console.WriteLine("The bee got lost!");
            }

            if (pollinatedFlowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            }

            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }

            PrintMatrix(field);

        }

        static void PrintMatrix(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }
        }

        static char[,] FullMatrix(int size)
        {
            char[,] field = new char[size, size];

            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[col];
                }
            }

            return field;
        }
    }
}
