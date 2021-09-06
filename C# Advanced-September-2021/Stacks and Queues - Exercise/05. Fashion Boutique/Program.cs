using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var capacity = int.Parse(Console.ReadLine());
            Stack<int> clothes = new Stack<int>(sequence);
            int sum = 0;
            int racksCount = 1;

            while (clothes.Count > 0)
            {
                sum += clothes.Peek();
              
                if (sum > capacity)
                {
                    sum = 0;
                    racksCount += 1;
                    continue;

                }
                clothes.Pop();



            }
            Console.WriteLine(racksCount);
        }
    }
}
