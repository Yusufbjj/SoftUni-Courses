using System;
using System.Linq;

namespace _02._Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split().Select(n => int.Parse(n)).ToArray();

            var n = dimensions[0];

            int[,] matrix = new int[n, n];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = 0;
                }
            }

            var command = Console.ReadLine();

            while (command != "Bloom Bloom Plow")
            {

                int[] coordinates = command.Split().Select(n => int.Parse(n)).ToArray();

                int row = coordinates[0];

                int col = coordinates[1];

                if (row < n && row >= 0 && col >= 0 && col < n)
                {

                    matrix[row, col] += 1;

                    //up
                    for (int rows = 0; rows < row; rows++)
                    {
                        matrix[rows, col] += 1;
                    }

                    //down
                    for (int rows = row + 1; rows < n; rows++)
                    {
                        matrix[rows, col] += 1;
                    }

                    //left
                    for (int cols = 0; cols < col; cols++)
                    {
                        matrix[row, cols] += 1;
                    }

                    //right 
                    for (int cols = col + 1; cols < n; cols++)
                    {
                        matrix[row, cols] += 1;
                    }

                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }





                command = Console.ReadLine();
            }

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write(matrix[rows,cols] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
