using System;
using System.Linq;

namespace _2.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixLength = int.Parse(Console.ReadLine());

            int countOfCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixLength, matrixLength];

            int playerRow = 0;
            int playerCol = 0;


            for (int rows = 0; rows < matrix.GetLength(0); rows++) //fill matrix 
            {
                var row = Console.ReadLine();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = (row[cols]);

                    if (matrix[rows, cols] == 'f')
                    {
                        playerRow = rows;
                        playerCol = cols;
                    }

                }
            }


            while (true)
            {

                string command = Console.ReadLine();

                countOfCommands--;

                matrix[playerRow, playerCol] = '-';

                if (command == "up") //up command
                {
                    if (playerRow - 1 >= 0) //valid index 
                    {
                        if (matrix[playerRow - 1, playerCol] == 'B') // if there is bonus on this position
                        {
                            if (playerRow - 2 >= 0)
                            {
                                matrix[playerRow, playerCol] = '-';

                                playerRow = playerRow - 2; //set new col position
                            }
                            else
                            {
                                matrix[playerRow, playerCol] = '-';

                                playerRow = matrixLength - 1; //set new col position if car goes out of matrix
                            }
                        }
                        else if (matrix[playerRow - 1, playerCol] == 'T')
                        {
                            // no change because trap returns car to the old position
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';

                            playerRow -= 1; //set new col position,no bonus or trap found
                        }
                    }
                    else if (playerRow - 1 < 0)
                    {
                        playerRow = matrixLength - 1; //set new col position if car goes out of matrix
                    }
                }
                else if (command == "down")
                {
                    if (playerRow + 1 < matrixLength)
                    {
                        if (matrix[playerRow + 1, playerCol] == 'B')
                        {
                            if (playerRow + 2 < matrixLength)
                            {
                                matrix[playerRow, playerCol] = '-';

                                playerRow = playerRow + 2;
                            }
                            else
                            {
                                matrix[playerRow, playerCol] = '-';

                                playerRow = 0;
                            }
                        }
                        else if (matrix[playerRow + 1, playerCol] == 'T')
                        {
                            //stays the same
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';

                            playerRow += 1;
                        }
                    }
                    else if (playerRow + 1 >= matrixLength)
                    {
                        playerRow = 0;
                    }
                }
                else if (command == "right")
                {
                    if (playerCol + 1 < matrixLength)
                    {
                        if (matrix[playerRow, playerCol + 1] == 'B')
                        {
                            if (playerCol + 2 < matrixLength)
                            {
                                matrix[playerRow, playerCol] = '-';

                                playerCol = playerCol + 2;
                            }
                            else
                            {
                                matrix[playerRow, playerCol] = '-';

                                playerCol = 0;
                            }
                        }
                        else if (matrix[playerRow, playerCol + 1] == 'T')
                        {
                            //stays the same
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';

                            playerCol += 1;
                        }
                    }
                    else if (playerCol + 1 >= matrixLength)
                    {
                        playerCol = 0;
                    }
                }
                else if (command == "left")
                {
                    if (playerCol - 1 >= 0)
                    {
                        if (matrix[playerRow, playerCol - 1] == 'B')
                        {
                            if (playerCol - 2 >= 0)
                            {
                                matrix[playerRow, playerCol] = '-';

                                playerCol = playerCol - 2;
                            }
                            else
                            {
                                matrix[playerRow, playerCol] = '-';

                                playerCol = matrixLength - 1;
                            }
                        }
                        else if (matrix[playerRow, playerCol - 1] == 'T')
                        {
                            //stays the same
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';

                            playerCol -= 1;
                        }

                    }
                    else if (playerCol - 1 < 0)
                    {
                        playerCol = matrixLength - 1;
                    }
                }

                if (matrix[playerRow, playerCol] == 'F')
                {
                    matrix[playerRow, playerCol] = 'f';
                    Console.WriteLine("Player won!");
                    break;
                }

                matrix[playerRow, playerCol] = 'f';

                if (countOfCommands == 0)
                {
                    Console.WriteLine("Player lost!");
                    break;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++) // print matrix
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }

        }
    }
}
