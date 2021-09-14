using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = ReadArrayOfIntFromConsoleToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                    if (i == j)
                    {
                        primaryDiagonal += row[j];

                    }
                }
            }
            int k = matrix.GetLength(1);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (k > 0)
                {
                    secondaryDiagonal += matrix[i, k - 1];
                }
                k -= 1;
            }

            Console.WriteLine(Math.Abs(primaryDiagonal-secondaryDiagonal));
        }

        private static int[] ReadArrayOfIntFromConsoleToArray()
        {
            return Console.ReadLine().Split().Select(int.Parse).ToArray();
        }
    }
}
