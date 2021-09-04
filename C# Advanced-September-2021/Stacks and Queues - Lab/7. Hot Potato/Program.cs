using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();
            Queue<string> kids = new Queue<string>(input);
            var n = int.Parse(Console.ReadLine());
            var count = 0;
            while (kids.Count>1)
            {
                count++;

                if (count == n)
                {
                    count = 0;
                    Console.WriteLine($"Removed {kids.Dequeue()}");
                }
                else
                {
                    kids.Enqueue(kids.Dequeue());
                }
            }
            Console.WriteLine($"Last is {kids.Dequeue()}");

        }
    }
}
