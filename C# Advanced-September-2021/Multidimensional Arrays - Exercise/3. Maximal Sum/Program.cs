using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var matrix = ReadMatrix(sizes);
            int maxValue = Int32.MinValue;
            int currValue = 0;
            int maxRow = 0;
            int maxCol = 0;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    currValue = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                                 matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                                matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (currValue > maxValue)
                    {
                        maxValue = currValue;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxValue}");
            Console.WriteLine($"{matrix[maxRow, maxCol]} {matrix[maxRow, maxCol + 1]} {matrix[maxRow, maxCol + 2]}");
            Console.WriteLine($"{matrix[maxRow + 1, maxCol]} {matrix[maxRow+1, maxCol + 1]} {matrix[maxRow+1, maxCol + 2]}");
            Console.WriteLine($"{matrix[maxRow + 2, maxCol]} {matrix[maxRow+2, maxCol + 1]} {matrix[maxRow+2, maxCol + 2]}");

        }
        private static int[,] ReadMatrix(int[] sizes)
        {
            int[,] matrix = new int[sizes[0], sizes[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            return matrix;
        }
    }
}
