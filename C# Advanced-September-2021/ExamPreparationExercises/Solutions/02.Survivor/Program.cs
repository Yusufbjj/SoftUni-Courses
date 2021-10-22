using System;
using System.Linq;

namespace _02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countOfCollected = 0;
            int countOfOpponentsTokens = 0;
            char[][] matrix = new char[n][];
            for (int i = 0; i < n; i++)
            {
                var row = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                matrix[i] = row;
            }

            // commands
            string command = Console.ReadLine();
            countOfCollected = CountOfCollected(command, matrix, countOfCollected, ref countOfOpponentsTokens);
            //print 
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }

            //collected tokens
            Console.WriteLine($"Collected tokens: {countOfCollected}");
            Console.WriteLine($"Opponent's tokens: {countOfOpponentsTokens}");

        }

        private static int CountOfCollected(string command, char[][] matrix, int countOfCollected,
            ref int countOfOpponentsTokens)
        {
            while (command != "Gong")
            {
                string[] commandTokens = command.Split();
                string commandName = commandTokens[0];

                int rowPosition = int.Parse(commandTokens[1]);
                int colPosition = int.Parse(commandTokens[2]);


                if (commandName == "Find")
                {
                    if (isPositionValid(rowPosition, colPosition, matrix))
                    {
                        if (matrix[rowPosition][colPosition] == 'T')
                        {
                            countOfCollected++;
                            matrix[rowPosition][colPosition] = '-';
                        }
                    }
                }
                else if (commandName == "Opponent")
                {
                    string direction = commandTokens[3];

                    if (isPositionValid(rowPosition, colPosition, matrix))
                    {
                        if (matrix[rowPosition][colPosition] == 'T')
                        {
                            countOfOpponentsTokens++;
                            matrix[rowPosition][colPosition] = '-';
                        }

                        switch (direction)
                        {
                            case "up":
                                for (int i = 1; i <= 3; i++)
                                {
                                    rowPosition -= 1;
                                    if (isPositionValid(rowPosition, colPosition, matrix))
                                    {
                                        if (matrix[rowPosition][colPosition] == 'T')
                                        {
                                            countOfOpponentsTokens++;
                                            matrix[rowPosition][colPosition] = '-';
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;
                            case "down":
                                for (int i = 1; i <= 3; i++)
                                {
                                    rowPosition += 1;
                                    if (isPositionValid(rowPosition, colPosition, matrix))
                                    {
                                        if (matrix[rowPosition][colPosition] == 'T')
                                        {
                                            countOfOpponentsTokens++;
                                            matrix[rowPosition][colPosition] = '-';
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;
                            case "left":
                                for (int i = 1; i <= 3; i++)
                                {
                                    colPosition -= 1;
                                    if (isPositionValid(rowPosition, colPosition, matrix))
                                    {
                                        if (matrix[rowPosition][colPosition] == 'T')
                                        {
                                            countOfOpponentsTokens++;
                                            matrix[rowPosition][colPosition] = '-';
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;
                            case "right":
                                for (int i = 1; i <= 3; i++)
                                {
                                    colPosition += 1;
                                    if (isPositionValid(rowPosition, colPosition, matrix))
                                    {
                                        if (matrix[rowPosition][colPosition] == 'T')
                                        {
                                            countOfOpponentsTokens++;
                                            matrix[rowPosition][colPosition] = '-';
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            return countOfCollected;
        }

        public static bool isPositionValid(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length;

        }
    }
}

