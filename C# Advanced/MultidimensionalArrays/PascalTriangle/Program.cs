using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] pascal = new long[rows][];
            int cols = 1;

            for (int row = 0; row < pascal.Length; row++)
            {
                pascal[row] = new long[cols];

                pascal[row][0] = 1;
                pascal[row][pascal[row].Length -1] = 1;

                if (row > 1)
                {
                    for (int col = 1; col < pascal[row].Length -1; col++)
                    {
                        long[] prevRow = pascal[row - 1];
                        long firstNum = prevRow[col];
                        long secondNum = prevRow[col - 1];
                        pascal[row][col] = firstNum + secondNum;
                    }
                }

                cols++;
            }

            foreach (var row in pascal)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
