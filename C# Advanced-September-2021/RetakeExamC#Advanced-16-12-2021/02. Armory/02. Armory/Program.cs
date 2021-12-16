using System;

namespace _02._Armory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int officerRow = 0;
            int officerCol = 0;

            int mirrorOneRow = 0;
            int mirrorOneCol = 0;

            int mirrorTwoRow = 0;
            int mirrorTwoCol = 0;

            double coinsPaidByTheKing = 0;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                string line = Console.ReadLine();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = line[cols];

                    if (matrix[rows, cols] == 'A')
                    {
                        officerRow = rows;
                        officerCol = cols;
                    }

                    if (matrix[rows, cols] == 'M')
                    {
                        if (mirrorOneRow == mirrorTwoRow && mirrorOneCol == mirrorTwoCol)
                        {
                            mirrorOneRow = rows;
                            mirrorOneCol = cols;
                        }
                        else
                        {
                            mirrorTwoRow = rows;
                            mirrorTwoCol = cols;
                        }
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                matrix[officerRow, officerCol] = '-';

                if (command == "up")
                {
                    if (officerRow - 1 >= 0)
                    {
                        if (matrix[officerRow - 1, officerCol] == '-')
                        {
                            matrix[officerRow - 1, officerCol] = 'A'; //officer moved to empty slot

                            officerRow--;
                        }
                        else if (matrix[officerRow - 1, officerCol] == 'M')
                        {
                            matrix[officerRow - 1, officerCol] = '-';

                            matrix[mirrorTwoRow, mirrorTwoCol] = 'A';
                            officerRow = mirrorTwoRow;
                            officerCol = mirrorTwoCol;
                        }
                        else
                        {
                            coinsPaidByTheKing += char.GetNumericValue(matrix[officerRow - 1, officerCol]);

                            matrix[officerRow - 1, officerCol] = 'A';

                            officerRow--;
                        }

                    }
                    else
                    {
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }
                }
                else if (command == "down")
                {
                    if (officerRow + 1 < n)
                    {
                        if (matrix[officerRow + 1, officerCol] == '-')
                        {
                            matrix[officerRow + 1, officerCol] = 'A'; //officer moved to empty slot

                            officerRow++;
                        }
                        else if (matrix[officerRow + 1, officerCol] == 'M')
                        {
                            matrix[officerRow + 1, officerCol] = '-';

                            matrix[mirrorTwoRow, mirrorTwoCol] = 'A';
                            officerRow = mirrorTwoRow;
                            officerCol = mirrorTwoCol;
                        }
                        else
                        {
                            coinsPaidByTheKing += char.GetNumericValue(matrix[officerRow + 1, officerCol]);

                            matrix[officerRow + 1, officerCol] = 'A';

                            officerRow++;
                        }

                    }
                    else
                    {
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }
                }
                else if (command == "left")
                {
                    if (officerCol - 1 >= 0)
                    {
                        if (matrix[officerRow, officerCol - 1] == '-')
                        {
                            matrix[officerRow, officerCol - 1] = 'A'; //officer moved to empty slot

                            officerCol--;
                        }
                        else if (matrix[officerRow, officerCol - 1] == 'M')
                        {
                            matrix[officerRow, officerCol - 1] = '-';

                            matrix[mirrorTwoRow, mirrorTwoCol] = 'A';
                            officerRow = mirrorTwoRow;
                            officerCol = mirrorTwoCol;
                        }
                        else
                        {
                            coinsPaidByTheKing += char.GetNumericValue(matrix[officerRow, officerCol - 1]);

                            matrix[officerRow, officerCol - 1] = 'A';

                            officerCol--;
                        }

                    }
                    else
                    {
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }
                }
                else if (command == "right")
                {
                    if (officerCol + 1 < n)
                    {
                        if (matrix[officerRow, officerCol + 1] == '-')
                        {
                            matrix[officerRow, officerCol + 1] = 'A'; //officer moved to empty slot

                            officerCol++;
                        }
                        else if (matrix[officerRow, officerCol + 1] == 'M')
                        {
                            matrix[officerRow, officerCol + 1] = '-';

                            matrix[mirrorTwoRow, mirrorTwoCol] = 'A';
                            officerRow = mirrorTwoRow;
                            officerCol = mirrorTwoCol;
                        }
                        else
                        {
                            coinsPaidByTheKing += char.GetNumericValue(matrix[officerRow, officerCol + 1]);

                            matrix[officerRow, officerCol + 1] = 'A';

                            officerCol++;
                        }

                    }
                    else
                    {
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }
                }

                if (coinsPaidByTheKing >= 65)
                {
                    Console.WriteLine("Very nice swords, I will come back for more!");
                    break;
                }

            }

            Console.WriteLine($"The king paid {coinsPaidByTheKing} gold coins.");

            for (int i = 0; i < matrix.GetLength(0); i++)
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
