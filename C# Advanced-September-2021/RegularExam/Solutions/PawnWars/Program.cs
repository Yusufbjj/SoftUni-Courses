using System;
using Microsoft.VisualBasic.CompilerServices;

namespace _02._Pawn_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
        /*  ------b-
            --------
            --------
            --------
            --------
            -w------
            --------
            --------         */


            int n = 8;
            char[,] chessBoard = new char[n, n];

            int whitePawnRow = 0;
            int whitePawnCol = 0;
            int blackPawnRow = 0;
            int blackPawnCol = 0;

            char[] chessCols = new char[8] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };


            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    chessBoard[row, col] = currentRow[col];
                    if (chessBoard[row, col] == 'w')
                    {
                        whitePawnRow = row;
                        whitePawnCol = col;
                    }

                    if (chessBoard[row, col] == 'b')
                    {
                        blackPawnRow = row;
                        blackPawnCol = col;
                    }
                }
            }

            while (true)
            {
                if (isPositionValid(whitePawnRow - 1, whitePawnCol - 1, n, n))
                {

                    if (chessBoard[whitePawnRow - 1, whitePawnCol - 1] == 'b')
                    {
                        Console.WriteLine($"Game over! White capture on {chessCols[whitePawnCol - 1]}{8 - (whitePawnRow - 1)}.");
                        break;
                    }
                }

                if (isPositionValid(whitePawnRow - 1, whitePawnCol + 1, n, n))
                {

                    if (chessBoard[whitePawnRow - 1, whitePawnCol + 1] == 'b')
                    {
                        if (whitePawnRow == 1)
                        {
                            whitePawnRow++;
                        }
                        Console.WriteLine($"Game over! White capture on {chessCols[whitePawnCol + 1]}{8 - (whitePawnRow - 1)}.");
                        break;
                    }
                }

                if (isPositionValid(whitePawnRow, whitePawnCol, n, n))
                {


                    chessBoard[whitePawnRow, whitePawnCol] = '-';
                    whitePawnRow = MoveRow(whitePawnRow, "up");

                    if (whitePawnRow == 0)
                    {
                        whitePawnRow++;
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {chessCols[whitePawnCol]}{8 - (whitePawnRow - 1)}.");
                        break;
                    }
                }

                if (isPositionValid(blackPawnRow - 1, blackPawnCol - 1, n, n))
                {

                    if (chessBoard[blackPawnRow - 1, blackPawnCol - 1] == 'w')
                    {
                        Console.WriteLine($"Game over! White capture on {chessCols[blackPawnCol - 1]}{8 - (blackPawnRow - 1)}.");
                        break;
                    }
                }

                if (isPositionValid(blackPawnRow - 1, blackPawnCol + 1, n, n))
                {

                    if (chessBoard[blackPawnRow - 1, blackPawnCol + 1] == 'w')
                    {
                        Console.WriteLine($"Game over! White capture on {chessCols[blackPawnCol + 1]}{8 - (blackPawnRow - 1)}.");
                        break;
                    }
                }

                if (isPositionValid(blackPawnRow, blackPawnCol, n, n))
                {


                    chessBoard[blackPawnRow, blackPawnCol] = '-';
                    blackPawnRow = MoveRow(blackPawnRow, "down");

                    if (blackPawnRow == n - 1)
                    {
                        blackPawnRow++;
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {chessCols[blackPawnCol - 1]}{8 - (blackPawnRow - 1)}.");
                        break;
                    }

                }
            }
        }
        public static bool isPositionValid(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows)
            {
                return false;
            }

            if (col < 0 || col >= cols)
            {
                return false;
            }

            return true;
        }
        public static int MoveRow(int row, string movement)
        {
            if (movement == "up")
            {
                return row - 1;
            }

            if (movement == "down")
            {
                return row + 1;
            }
            return row;
        }

    }
}
