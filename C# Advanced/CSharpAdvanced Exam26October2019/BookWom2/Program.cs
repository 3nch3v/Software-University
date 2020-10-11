using System;
using System.Text;

namespace BookWorm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder text = new StringBuilder(input);


            int squareMatrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = ReadMatrix(squareMatrixSize);
            int[] startCordinates = GetStartPosition(matrix);
            int currRow = startCordinates[0];
            int currCol = startCordinates[1];

            string comand;

            while ((comand = Console.ReadLine()) != "end")
            {
                int[] newPosition = MovePlayer(comand, currRow, currCol);
                int newRow = newPosition[0];
                int newCol = newPosition[1];


                if (newRow < 0 || newRow >= matrix.GetLength(0)
                   || newCol < 0 || newCol >= matrix.GetLength(1))
                {
                    text = text.Remove(text.Length - 1, 1);
                }

                else
                {
                    if (char.IsLetter(matrix[newRow, newCol]) || matrix[newRow, newCol] == '-')
                    {
                        if (char.IsLetter(matrix[newRow, newCol]))
                        {
                            text.Append(matrix[newRow, newCol]);
                        }
                        
                        matrix[currRow, currCol] = '-';
                        matrix[newRow, newCol] = 'P';

                        currRow = newRow;
                        currCol = newCol;
                    }
                }
            }

            Console.WriteLine(text.ToString());

            PrintMatrix(matrix);
        }

        static int[] MovePlayer(string move, int row, int col)
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

        static int[] GetStartPosition(char[,] matrix)
        {
            int[] startCordinates = new int[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'P')
                    {
                        startCordinates[0] = row;
                        startCordinates[1] = col;
                    }
                }
            }

            return startCordinates;
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
