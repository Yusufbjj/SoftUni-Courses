using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var commandInfo = Console.ReadLine().ToLower();
            Stack<int> stack = new Stack<int>(input);
            var sum = 0;

            while (commandInfo != "end")
            {
                var tokens = commandInfo.Split();
                var command = tokens[0].ToLower();
                if (command == "add")
                {
                    int first = int.Parse(tokens[1]);
                    int second = int.Parse(tokens[2]);
                    stack.Push(first);
                    stack.Push(second);
                }
                else if (command == "remove")
                {
                    int elementsToRemove = int.Parse(tokens[1]);
                    if (elementsToRemove > stack.Count)
                    {
                        continue;
                    }
                    else
                    {
                        for (int i = 0; i < elementsToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                commandInfo = Console.ReadLine();
            }
            sum = stack.Sum();
            Console.WriteLine($"Sum: {sum}");

        }
    }
}
