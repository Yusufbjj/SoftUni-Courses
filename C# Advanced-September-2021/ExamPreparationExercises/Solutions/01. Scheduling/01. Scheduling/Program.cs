using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            Queue<int> threads = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int toBeKilledTask = int.Parse(Console.ReadLine());

            while (true)
            {
                int task = tasks.Peek();

                int thread = threads.Peek();

                if (task == toBeKilledTask)
                {
                    Console.WriteLine($"Thread with value {thread} killed task {toBeKilledTask}");
                    break;
                }

                if (thread >= task)
                {
                    tasks.Pop();

                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine(string.Join(" ",threads));

        }
    }
}
