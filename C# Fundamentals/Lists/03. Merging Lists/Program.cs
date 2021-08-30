using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> first = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> second = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = new List<int>();
            int count = Math.Max(first.Count, second.Count);

            for (int i = 0; i < count; i++)
            {
                if (first.Count > i)
                {
                    result.Add(first[i]);
                }
                if (second.Count > i)
                {

                    result.Add(second[i]);
                }
            }
            Console.WriteLine(string.Join(" ", result));

        }
    }
}
