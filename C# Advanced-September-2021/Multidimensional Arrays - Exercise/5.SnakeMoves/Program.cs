using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string snake = Console.ReadLine();
            char[,] stairsMatrix = new char[dimensions[0], dimensions[1]];

            int currentCol = 0;
            Queue<char> snakeQue = new Queue<char>(snake);
            for (int row = 0; row < stairsMatrix.GetLength(0); row++)
            {
                if (currentCol % 2 == 0)
                {
                    for (int col = 0; col < stairsMatrix.GetLength(1); col++)
                    {
                        char currentChar = snakeQue.Dequeue();
                        snakeQue.Enqueue(currentChar);
                        stairsMatrix[row, col] = currentChar;
                    }
                    currentCol++;
                }
                else
                {
                    for (int col = stairsMatrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        char currentChar = snakeQue.Dequeue();
                        snakeQue.Enqueue(currentChar);
                        stairsMatrix[row, col] = currentChar;

                    }
                    currentCol++;
                }
            }

            printMatrix(stairsMatrix);

        }

        static void printMatrix(char[,] stairsMatrix)
        {
            for (int row = 0; row < stairsMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < stairsMatrix.GetLength(1); col++)
                {
                    Console.Write(stairsMatrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
