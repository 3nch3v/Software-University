using System;

namespace TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = ReadMatrix(matrixSize);

            int firstPlayerRow = -1;
            int firstPlayerCol = -1;

            int secondPlayerRow = -1;
            int secondPlayerCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'f')
                    {
                         firstPlayerRow = row;
                         firstPlayerCol = col;
                    }

                    if (matrix[row, col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }
                }
            }

            while (true)
            {
                string[] comand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string firstPlComad = comand[0];
                string seconPlComad = comand[1];

                int[] firstPlCordinats = MovePlayer(firstPlComad, firstPlayerRow, firstPlayerCol, matrix);
                int firstPlNewRow = firstPlCordinats[0];
                int firstPlNewCol = firstPlCordinats[1];

                int[] secondPlCordinats = MovePlayer(seconPlComad, secondPlayerRow, secondPlayerCol, matrix);

                int secondPlNewRow = secondPlCordinats[0];
                int secondPlNewCol = secondPlCordinats[1];


                if (matrix[firstPlNewRow, firstPlNewCol] == 's')
                {
                    matrix[firstPlNewRow, firstPlNewCol] = 'x';
                    break;
                }

                else if (matrix[firstPlNewRow, firstPlNewCol] == '*' || matrix[firstPlNewRow, firstPlNewCol] == 'f')
                {
                    matrix[firstPlNewRow, firstPlNewCol] = 'f';
                    firstPlayerRow = firstPlNewRow;
                    firstPlayerCol = firstPlNewCol;
                }


                if (matrix[secondPlNewRow, secondPlNewCol] == 'f')
                {
                    matrix[secondPlNewRow, secondPlNewCol] = 'x';
                    break;
                }

                else if (matrix[secondPlNewRow, secondPlNewCol] == '*' || matrix[secondPlNewRow, secondPlNewCol] == 's')
                {
                    matrix[secondPlNewRow, secondPlNewCol] = 's';
                    secondPlayerRow = secondPlNewRow;
                    secondPlayerCol = secondPlNewCol;
                }
            }

            PrintMatrix(matrix);
        }
        static int[] MovePlayer(string comand, int row, int col, char[,] matrix)
        {
            int[] newCordinates = new int[2];

            if (comand == "up")
            {
                newCordinates[0] = row - 1;
                newCordinates[1] = col;

                if (row - 1 < 0)
                {
                    newCordinates[0] = matrix.GetLength(0) - 1;
                }
            }

            else if (comand == "down")
            {
                newCordinates[0] = row + 1;
                newCordinates[1] = col;

                if (row + 1 > matrix.GetLength(0) - 1)
                {
                    newCordinates[0] = 0;
                }
            }

            else if (comand == "left")
            {
                newCordinates[0] = row;
                newCordinates[1] = col - 1;

                if (col - 1 < 0)
                {
                    newCordinates[1] = matrix.GetLength(1) - 1;
                }
            }

            else if (comand == "right")
            {
                newCordinates[0] = row;
                newCordinates[1] = col + 1;

                if (col + 1 > matrix.GetLength(1) - 1)
                {
                    newCordinates[1] = 0;
                }
            }

            return newCordinates;
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
        static char[,] ReadMatrix(int matrixSize)
        {
            char[,] matrix = new char[matrixSize, matrixSize];

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
