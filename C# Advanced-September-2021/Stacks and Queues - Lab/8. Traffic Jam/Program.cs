using System;
using System.Collections;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var command = Console.ReadLine();
            Queue<string> queue = new Queue<string>();
            var count = 0;

            while (command != "end")
            {
                if (command == "green")
                {
                    
                    for (int i = 0; i < n; i++)
                    {
                        if (queue.Count == 0)
                        {
                            break;
                        }
                        count++;
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
