using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var matrix = ReadMatrix(sizes);

            int count = 0;
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1] &&
                        matrix[i, j] == matrix[i + 1, j] &&
                        matrix[i, j] == matrix[i + 1, j + 1])
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
        private static char[,] ReadMatrix(int[] sizes)
        {
            char[,] matrix = new char[sizes[0], sizes[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] row = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
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
