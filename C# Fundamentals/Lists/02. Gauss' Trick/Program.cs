using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Gauss__Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> number = Console.ReadLine().Split().Select(int.Parse).ToList();
            int count = number.Count;
            for (int i = 0; i < count / 2; i++)
            {
                int first = number[i];
                int last = number[number.Count - 1];
                number.RemoveAt(number.Count - 1);
                number[i] = first + last;

            }
            Console.WriteLine(string.Join(" ",number));
        }
    }
}
