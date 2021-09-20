using System;
using System.Collections.Generic;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(num))
                {
                    numbers.Add(num, 0);
                }

                numbers[num]++;
            }

            int number = 0;
            foreach (KeyValuePair<int, int> kvp in numbers)
            {
                if (kvp.Value % 2 == 0)
                {
                    number = kvp.Key;
                }
            }

            Console.WriteLine(number);
        }
    }
}
