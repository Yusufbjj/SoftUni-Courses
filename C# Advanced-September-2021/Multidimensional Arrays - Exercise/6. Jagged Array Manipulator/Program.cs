using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] matrix = new int[n][];
            for (int rows = 0; rows < n; rows++)
            {
                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                matrix[rows] = currentRow;
            }

            MatrixAnalyze(matrix);


            while (true)
            {
                string[] commandLine = Console.ReadLine().Split().ToArray();
                string command = commandLine[0];
                if (command == "Add")
                {
                    int row = int.Parse(commandLine[1]);
                    int col = int.Parse(commandLine[2]);
                    int value = int.Parse(commandLine[3]);
                    if (IfIndexesAreValid(row, col, matrix))
                    {
                        matrix[row][col] += value;
                    }
                }
                else if (command == "Subtract")
                {
                    int row = int.Parse(commandLine[1]);
                    int col = int.Parse(commandLine[2]);
                    int value = int.Parse(commandLine[3]);
                    if (IfIndexesAreValid(row, col, matrix))
                    {
                        matrix[row][col] -= value;
                    }
                }
                else 
                {

                    printMatrix(matrix);
                    return;
                }

            }

        }
        static void printMatrix(int[][] matrix)
        {
            foreach (int[] row in matrix)
            {
                Console.WriteLine(string.Join(" ",row));
            }
        }

        private static bool IfIndexesAreValid(int row, int col, int[][] matrix)
        {
            return row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length;
        }

        private static void MatrixAnalyze(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] /= 2;
                    }

                    for (int col = 0; col < matrix[row + 1].Length; col++)
                    {
                        matrix[row + 1][col] /= 2;
                    }
                }
            }
        }
    }
}
