using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] allNumbers = Enumerable.Range(1, n).ToArray();

            List<Predicate<int>> predicates = new List<Predicate<int>>();

            foreach (var number in sequence)
            {
                predicates.Add(x => x % number == 0);
            }

            foreach (var curNumber in allNumbers)
            {
                bool isDivisible = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(curNumber))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    Console.Write(curNumber + " ");
                }
            }

        }
    }
}
