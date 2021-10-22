using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Warm_Winter
{
    class Program
    {
        static void Main(string[] args)
        {
            var hats = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            List<int> sets = new List<int>();

            var hat = hats.Peek();
            var scarf = scarfs.Peek();
            while (hats.Count > 0 && scarfs.Count > 0)
            {

                if (hat > scarf)
                {
                    var set = hat + scarf;
                    hats.Pop();
                    scarfs.Dequeue();
                    sets.Add(set);
                    if (hats.Any() && scarfs.Any())
                    {
                        hat = hats.Peek();
                        scarf = scarfs.Peek();
                    }
                }
                else if (scarf > hat)
                {
                    hats.Pop();
                    if (hats.Any())
                    {
                        hat = hats.Peek();
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    scarfs.Dequeue();
                    if (scarfs.Any())
                    {
                        scarf = scarfs.Peek();
                        hat += 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.OrderByDescending(p => p).FirstOrDefault()}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
