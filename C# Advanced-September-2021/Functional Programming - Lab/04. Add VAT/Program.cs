using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbersWithVat = Console.ReadLine()
                .Split(", ")
                .Select(double.Parse)
                .Select(x => x * 1.2);

            foreach (var d in numbersWithVat)
            {
                Console.WriteLine($"{d:F2}");
            }
        }
    }
}
