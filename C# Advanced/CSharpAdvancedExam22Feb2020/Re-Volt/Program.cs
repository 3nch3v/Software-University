using System;

namespace Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int squareMatrixSize = int.Parse(Console.ReadLine());
            int comandsCount = int.Parse(Console.ReadLine());

            char[,] playField = GetMatrixElements(squareMatrixSize);

            int[] playerPosition = GetPlayerPosition(playField);

            int currRow = playerPosition[0];
            int currCol = playerPosition[1];

            int goBackRow = -1;
            int goBackCol = -1;

            bool isWinner = false;

            for (int i = 0; i < comandsCount; i++)
            {
                string comand = Console.ReadLine();

                playField[currRow, currCol] = '-';

                goBackRow = currRow;
                goBackCol = currCol;

                int[] newPosition = GetNewPosition(playField, comand, currRow, currCol);

                currRow = newPosition[0];
                currCol = newPosition[1];

                if (playField[currRow, currCol] == 'F')
                {
                    playField[currRow, currCol] = 'f';

                    isWinner = true;
                    break;
                }

                else if (playField[currRow, currCol] == '-')
                {
                    playField[currRow, currCol] = 'f';
                }

                else if (playField[currRow, currCol] == 'T')
                {
                    playField[goBackRow, goBackCol] = 'f';
                    currRow = goBackRow;
                    currCol = goBackCol;
                }

                else if (playField[currRow, currCol] == 'B')
                {
                    newPosition = GetNewPosition(playField, comand, currRow, currCol);

                    currRow = newPosition[0];
                    currCol = newPosition[1];

                    if (playField[currRow, currCol] == 'F')
                    {
                        playField[currRow, currCol] = 'f';

                        isWinner = true;
                        break;
                    }

                    playField[currRow, currCol] = 'f';
                }
            }

            PrintGameResult(isWinner);
            PrintMatrix(playField);
        }

        static int[] GetNewPosition(char[,] playField, string comand , int currRow, int currCol)
        {
            int[] newPosotion = new int[2];

            if (comand == "up")
            {
                if (currRow - 1 >= 0)
                {
                    newPosotion[0] = currRow - 1;
                    newPosotion[1] = currCol;
                }

                else
                {
                    newPosotion[0] = playField.GetLength(0) - 1;
                    newPosotion[1] = currCol;
                }
            }

            else if (comand == "down")
            {
                if (currRow + 1 < playField.GetLength(0))
                {
                    newPosotion[0] = currRow + 1;
                    newPosotion[1] = currCol;
                }

                else
                {
                    newPosotion[0] = 0;
                    newPosotion[1] = currCol;
                }
            }

            else if (comand == "left")
            {
                if (currCol - 1 >= 0)
                {
                    newPosotion[0] = currRow;
                    newPosotion[1] = currCol - 1;
                }

                else
                {
                    newPosotion[0] = currRow;
                    newPosotion[1] = playField.GetLength(1) - 1;
                }
            }

            else if (comand == "right")
            {
                if (currCol + 1 < playField.GetLength(1))
                {
                    newPosotion[0] = currRow;
                    newPosotion[1] = currCol + 1;
                }

                else
                {
                    newPosotion[0] = currRow;
                    newPosotion[1] = 0;
                }
            }

            return newPosotion;
        }

        static void PrintGameResult(bool isWinner)
        {
            if (isWinner)
            {
                Console.WriteLine("Player won!");
            }

            else
            {
                Console.WriteLine("Player lost!");
            }
        }

        static int[] GetPlayerPosition(char[,] playField)
        {
            int[] playerPosition = new int[2];


            for (int row = 0; row < playField.GetLength(0); row++)
            {
                for (int col = 0; col < playField.GetLength(1); col++)
                {
                    if (playField[row, col] == 'f')
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
                    Console.Write(playField[row, col]);
                }

                Console.WriteLine();
            }
        }

        static char[,] GetMatrixElements(int squareMatrixSize)
        {
            char[,] playField = new char[squareMatrixSize, squareMatrixSize];

            for (int row = 0; row < squareMatrixSize; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < squareMatrixSize; col++)
                {
                    playField[row, col] = input[col];
                }
            }

            return playField;
        }
    }
}
