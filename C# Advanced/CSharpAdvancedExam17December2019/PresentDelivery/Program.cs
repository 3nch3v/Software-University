using System;
using System.Linq;

namespace PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int presentsCount = int.Parse(Console.ReadLine());
            int squareMatrixSize = int.Parse(Console.ReadLine());
            
            char[,] playField = GetMatrixElements(squareMatrixSize);

            int[] playerPosition = GetPlayerPosition(playField);

            int currRow = playerPosition[0];
            int currCol = playerPosition[1];

            int happyChildrens = 0;

            string comand;

            while ((comand = Console.ReadLine()) != "Christmas morning")
            {             
                playField[currRow, currCol] = '-';

                int[] newCordinations = MovePlayer(comand, currRow, currCol);

                int newRow = newCordinations[0];
                int newCol = newCordinations[1];

                if ((newRow >= 0 && newRow < playField.GetLength(0))
                    && newCol >= 0 && newCol < playField.GetLength(1))
                {
                    if (playField[newRow, newCol] == '-' || playField[newRow, newCol] == 'X')
                    {
                        playField[newRow, newCol] = 'S';

                        currRow = newRow;
                        currCol = newCol;
                    }

                    else if (playField[newRow, newCol] == 'V')
                    {
                        playField[newRow, newCol] = 'S';

                        currRow = newRow;
                        currCol = newCol;

                        happyChildrens++;
                        presentsCount--;                       
                    }

                    else if (playField[newRow, newCol] == 'C')
                    {
                        playField[newRow, newCol] = 'S';
                        currRow = newRow;
                        currCol = newCol;

                        if (playField[currRow - 1, currCol] == 'X' || playField[currRow - 1, currCol] == 'V')
                        {
                            playField[currRow - 1, currCol] = '-';

                            presentsCount--;
                        }

                        if (playField[currRow + 1, currCol] == 'X' || playField[currRow + 1, currCol] == 'V')
                        {
                            playField[currRow + 1, currCol] = '-';

                            presentsCount--;
                        }

                        if (playField[currRow, currCol - 1] == 'X' || playField[currRow, currCol - 1] == 'V')
                        {
                            playField[currRow, currCol - 1] = '-';

                            presentsCount--;
                        }

                        if (playField[currRow, currCol + 1] == 'X' || playField[currRow, currCol + 1] == 'V')
                        {
                            playField[currRow, currCol + 1] = '-';

                            presentsCount--;
                        }
                    }

                    if (presentsCount == 0)
                    {
                        Console.WriteLine("Santa ran out of presents!");
                        break;
                    }
                }
            }

            PrintMatrix(playField);

            int niceChildrensWithoutPresent = ChildrensWithoutPresent(playField);

            if (niceChildrensWithoutPresent > 0)
            {
                Console.WriteLine($"No presents for {niceChildrensWithoutPresent} nice kid/s.");
            }

            else
            {
                Console.WriteLine($"Good job, Santa! {happyChildrens} happy nice kid/s.");
            }      
        }

        static int[] MovePlayer(string comand, int currRow, int currCol)
        {
            int[] newCordinations = new int[2];

            if (comand == "up")
            {
                newCordinations[0] = currRow - 1;
                newCordinations[1] = currCol;
            }

            else if (comand == "down")
            {
                newCordinations[0] = currRow + 1;
                newCordinations[1] = currCol;
            }

            else if (comand == "left")
            {
                newCordinations[0] = currRow;
                newCordinations[1] = currCol - 1;
            }

            else if (comand == "right")
            {
                newCordinations[0] = currRow;
                newCordinations[1] = currCol + 1;
            }

            return newCordinations;
        }

        static int ChildrensWithoutPresent(char[,] playField)
        {
            int childrens = 0;

            for (int row = 0; row < playField.GetLength(0); row++)
            {
                for (int col = 0; col < playField.GetLength(1); col++)
                {
                    if (playField[row, col] == 'V')
                    {
                        childrens++;
                    }
                }
            }

            return childrens;
        }

        static int[] GetPlayerPosition(char[,] playField)
        {
            int[] playerPosition = new int[2];

            for (int row = 0; row < playField.GetLength(0); row++)
            {
                for (int col = 0; col < playField.GetLength(1); col++)
                {
                    if (playField[row, col] == 'S')
                    {
                        playerPosition[0] = row;
                        playerPosition[1] = col;                      
                    }
                }
            }

            return playerPosition;
        }

        static void PrintMatrix(char[,] playField)
        {
            for (int row = 0; row < playField.GetLength(0); row++)
            {
                for (int col = 0; col < playField.GetLength(1); col++)
                {
                    Console.Write(playField[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        static char[,] GetMatrixElements(int squareMatrixSize)
        {
            char[,] playField = new char[squareMatrixSize, squareMatrixSize];

            for (int row = 0; row < squareMatrixSize; row++)
            {
                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < squareMatrixSize; col++)
                {
                    playField[row, col] = input[col];
                }
            }

            return playField;
        }
    }
}
