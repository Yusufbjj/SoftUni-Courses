using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elementsLength = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            List<int> nums = new List<int>();
            FillSet(elementsLength[0], firstSet);
            FillSet(elementsLength[1], secondSet);
            

            CheckSets(firstSet, secondSet, nums);

            Console.WriteLine(string.Join(" ",nums));
        }

        private static void CheckSets(HashSet<int> firstSet, HashSet<int> secondSet, List<int> nums)
        {
            foreach (var number in firstSet)
            {
                if (secondSet.Contains(number))
                {
                    nums.Add(number);
                }
            }
        }

        private static void FillSet(int elementsLength, HashSet<int> set)
        {
            for (int i = 0; i < elementsLength; i++)
            {
                int n = int.Parse(Console.ReadLine());
                set.Add(n);
            }
        }
    }
}
