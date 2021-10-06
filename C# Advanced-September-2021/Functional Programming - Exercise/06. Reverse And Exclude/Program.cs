using System;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            numbers.Reverse();
            int n = int.Parse(Console.ReadLine());


            Console.WriteLine(string.Join(" ", numbers.Where(num => !(num % n == 0))));

        }
    }
}
