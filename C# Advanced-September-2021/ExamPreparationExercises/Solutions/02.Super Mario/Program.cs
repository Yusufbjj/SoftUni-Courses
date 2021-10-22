using System;

namespace _02.Super_Mario
{
    class Program
    {
        static void Main(string[] args)
        {
            int marioLives = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());

            char[][] maze = new char[size][];
            int marioRow = 0;
            int marioCol = 0;

            bool isSuccesfull = false;

            for (int row = 0; row < maze.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();

                maze[row] = currentRow;
                for (int col = 0; col < maze[row].Length; col++)
                {
                    if (maze[row][col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }
            while (true)
            {
                string line = Console.ReadLine();
                var tokens = line.Split();
                char movement = char.Parse(tokens[0]);
                int enemyRow = int.Parse(tokens[1]);
                int enemyCol = int.Parse(tokens[2]);

                maze[enemyRow][enemyCol] = 'B';
                marioLives -= 1;

                switch (movement)
                {
                    case 'W':
                        if (marioRow - 1 < 0)
                        {
                            continue;
                        }

                        maze[marioRow][marioCol] = '-';
                        marioRow -= 1;
                        break;
                    case 'S':
                        if (marioRow + 1 == maze.Length)
                        {
                            continue;
                        }

                        maze[marioRow][marioCol] = '-';
                        marioRow += 1;

                        break;
                    case 'A':
                        if (marioCol - 1 < 0)
                        {
                            continue;
                        }
                        maze[marioRow][marioCol] = '-';
                        marioCol -= 1;

                        break;
                    case 'D':
                        if (marioCol + 1 == maze[marioRow].Length)
                        {

                            continue;

                        }
                        maze[marioRow][marioCol] = '-';
                        marioCol += 1;
                        break;

                }

                if (marioLives <= 0)
                {
                    maze[marioRow][marioCol] = 'X';
                    break;
                }


                if (maze[marioRow][marioCol] == 'P')
                {
                    maze[marioRow][marioCol] = '-';
                    isSuccesfull = true;
                    break;
                }

                if (maze[marioRow][marioCol] == 'B')
                {
                    marioLives -= 2;
                    if (marioLives <= 0)
                    {
                        maze[marioRow][marioCol] = 'X';
                        break;
                    }
                }
                maze[marioRow][marioCol] = 'M';
            }

            if (isSuccesfull)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLives}");
            }
            else
            {
                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
            }

            for (int row = 0; row < size; row++)
            {
                Console.WriteLine(maze[row]);
            }
        }
    }
}
