using System;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();
            FillSet(n, elements);

            Console.WriteLine(string.Join(" ", elements));

        }

        private static SortedSet<string> FillSet(int n, SortedSet<string> elements)
        {
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (var element in line)
                {

                    elements.Add(element);

                }
            }

            return elements;
        }
    }
}
