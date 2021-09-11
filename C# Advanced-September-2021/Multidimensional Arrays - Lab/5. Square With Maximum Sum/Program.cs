using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = ToArray();
            int[,] matrix = new int[sizes[0], sizes[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colloumn = ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colloumn[col];
                }
            }
            int maxSum = Int32.MinValue;
            int mxRow = 0;
            int mxCol = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = matrix[row, col] +
                              matrix[row + 1, col] +
                              matrix[row, col + 1] +
                              matrix[row + 1, col + 1];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        mxRow = row;
                        mxCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[mxRow, mxCol]} {matrix[mxRow, mxCol + 1]}");
            Console.WriteLine($"{matrix[mxRow + 1, mxCol]} {matrix[mxRow + 1, mxCol + 1]}");
            Console.WriteLine(maxSum);
        }
        private static int[] ToArray()
        {
            return Console.ReadLine()
                .Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
