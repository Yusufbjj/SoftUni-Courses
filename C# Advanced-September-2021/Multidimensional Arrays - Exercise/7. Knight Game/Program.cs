using System;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] matrix = new char[n][];

            for (int row = 0; row < n; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }

            int removedKnights = 0;
            while (true)
            {
                int knightRow = -1;
                int knightCol = -1;
                int maxAtacked = 0;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (matrix[row][col] == 'K')
                        {
                            int tempAtacks = CountAttacks(matrix, row, col);
                            if (tempAtacks > maxAtacked)
                            {
                                maxAtacked = tempAtacks;
                                knightRow = row;
                                knightCol = col;
                            }
                        }
                    }
                }

                if (maxAtacked > 0)
                {
                    matrix[knightRow][knightCol] = '0';
                    removedKnights++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(removedKnights);
        }

        static int CountAttacks(char[][] matrix, int row, int col)
        {
            int atacks = 0;

            if (IsInMatrix(row + 1, col - 2, matrix.Length) && matrix[row + 1][col - 2] == 'K')
            {
                atacks++;
            }

            if (IsInMatrix(row - 1, col - 2, matrix.Length) && matrix[row - 1][col - 2] == 'K')
            {
                atacks++;
            }

            if (IsInMatrix(row - 1, col + 2, matrix.Length) && matrix[row - 1][col + 2] == 'K')
            {
                atacks++;
            }

            if (IsInMatrix(row + 1, col + 2, matrix.Length) && matrix[row + 1][col + 2] == 'K')
            {
                atacks++;
            }

            if (IsInMatrix(row - 2, col - 1, matrix.Length) && matrix[row - 2][col - 1] == 'K')
            {
                atacks++;
            }
            if (IsInMatrix(row - 2, col + 1, matrix.Length) && matrix[row - 2][col + 1] == 'K')
            {
                atacks++;
            }
            if (IsInMatrix(row + 2, col - 1, matrix.Length) && matrix[row + 2][col - 1] == 'K')
            {
                atacks++;
            }
            if (IsInMatrix(row + 2, col + 1, matrix.Length) && matrix[row + 2][col + 1] == 'K')
            {
                atacks++;
            }
            return atacks;
        }

        private static bool IsInMatrix(int row, int col, int length)
        {
            return row >= 0 && row < length && col >= 0 && col < length;
        }
    }
}
