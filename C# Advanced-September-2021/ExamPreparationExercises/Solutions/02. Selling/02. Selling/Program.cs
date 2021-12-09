using System;
using System.Linq;

namespace _02._Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];

            int playerRow = 0;
            int playerCol = 0;

            int pillarOneRow = 0;
            int pillarOneCol = 0;

            int pillarTwoRow = 0;
            int pillarTwoCol = 0;

            double money = 0;


            for (int rows = 0; rows < matrixSize; rows++)
            {
                string row = Console.ReadLine();

                for (int cols = 0; cols < matrixSize; cols++)
                {
                    matrix[rows, cols] = row[cols];

                    if (matrix[rows, cols] == 'S') // player position
                    {
                        playerRow = rows;
                        playerCol = cols;

                    }

                    if (matrix[rows, cols] == 'O') //first pillar position
                    {
                        if (pillarOneRow == pillarTwoRow && pillarOneCol == pillarTwoCol)
                        {
                            pillarOneRow = rows;
                            pillarOneCol = cols;
                        }
                        else
                        {
                            pillarTwoRow = rows;
                            pillarTwoCol = cols;
                        }
                    }
                }
            }


            while (true)
            {

                string command = Console.ReadLine();

                matrix[playerRow, playerCol] = '-';

                if (command == "up")
                {
                    if (playerRow - 1 >= 0) //valid index 
                    {
                        if (matrix[playerRow - 1, playerCol] == 'O')
                        {
                            matrix[playerRow - 1, playerCol] = '-';
                            matrix[pillarTwoRow, pillarTwoCol] = 'S';

                            playerRow = pillarTwoRow;
                            playerCol = pillarTwoCol;


                        }
                        else if (matrix[playerRow - 1, playerCol] == '-')
                        {
                            matrix[playerRow - 1, playerCol] = 'S';

                            playerRow -= 1;
                        }
                        else
                        {
                            var number = char.GetNumericValue(matrix[playerRow - 1, playerCol]);

                            money += number;

                            matrix[playerRow - 1, playerCol] = 'S';

                            playerRow -= 1;
                        }
                    }
                    else if (playerRow - 1 < 0)
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        break;
                    }
                }
                else if (command == "down")
                {
                    if (playerRow + 1 < matrixSize) //valid index 
                    {
                        if (matrix[playerRow + 1, playerCol] == 'O')
                        {
                            matrix[playerRow + 1, playerCol] = '-';
                            matrix[pillarTwoRow, pillarTwoCol] = 'S';

                            playerRow = pillarTwoRow;
                            playerCol = pillarTwoCol;
                        }
                        else if (matrix[playerRow + 1, playerCol] == '-')
                        {
                            matrix[playerRow + 1, playerCol] = 'S';

                            playerRow += 1;
                        }
                        else
                        {
                            var number = char.GetNumericValue(matrix[playerRow + 1, playerCol]);

                            money += number;
                            matrix[playerRow + 1, playerCol] = 'S';

                            playerRow += 1;

                        }
                    }
                    else if (playerRow + 1 >= matrixSize)
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        break;
                    }
                }
                else if (command == "left")
                {
                    if (playerCol - 1 >= 0) //valid index 
                    {
                        if (matrix[playerRow, playerCol - 1] == 'O')
                        {
                            matrix[playerRow, playerCol - 1] = '-';
                            matrix[pillarTwoRow, pillarTwoCol] = 'S';

                            playerRow = pillarTwoRow;
                            playerCol = pillarTwoCol;


                        }
                        else if (matrix[playerRow, playerCol - 1] == '-')
                        {

                            matrix[playerRow, playerCol - 1] = 'S';

                            playerCol -= 1;
                        }
                        else
                        {
                            var number = char.GetNumericValue(matrix[playerRow, playerCol-1]);

                            money += number;

                            matrix[playerRow, playerCol - 1] = 'S';

                            playerCol -= 1;
                        }
                    }
                    else if (playerCol - 1 < 0)
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        break;
                    }
                }
                else if (command == "right")
                {
                    if (playerCol + 1 < matrixSize) //valid index 
                    {
                        if (matrix[playerRow, playerCol + 1] == 'O')
                        {
                            matrix[playerRow, playerCol + 1] = '-';
                            matrix[pillarTwoRow, pillarTwoCol] = 'S';

                            playerRow = pillarTwoRow;
                            playerCol = pillarTwoCol;


                        }
                        else if (matrix[playerRow, playerCol + 1] == '-')
                        {

                            matrix[playerRow, playerCol + 1] = 'S';

                            playerCol += 1;
                        }
                        else
                        {
                            var number = char.GetNumericValue(matrix[playerRow, playerCol+1]);

                            money += number;

                            matrix[playerRow, playerCol + 1] = 'S';

                            playerCol += 1;
                        }
                    }
                    else if (playerCol + 1 >= matrixSize)
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        break;
                    }
                }

                if (money >= 50)
                {
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    break;
                }
            }

            Console.WriteLine($"Money: {money}");

            //print

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write(matrix[rows, cols]);
                }

                Console.WriteLine();
            }


        }
    }
}
