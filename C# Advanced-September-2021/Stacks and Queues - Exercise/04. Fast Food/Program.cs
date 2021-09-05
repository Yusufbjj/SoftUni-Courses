using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            var foodQuantity = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(orders);
            Console.WriteLine(queue.Max());
            while (queue.Count > 0)
            {
                if (queue.Peek() <= foodQuantity)
                {
                    foodQuantity -= queue.Peek();
                    queue.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
                    return;
                }
                if (queue.Count == 0)
                {
                    break;
                }
            }
            Console.WriteLine("Orders complete");
        }
    }
}
