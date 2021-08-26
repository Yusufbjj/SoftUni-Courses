using System;
using System.Linq;

namespace _06._Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int even = 0;
            int odd = 0;
            int result = 0;
            foreach (var item in nums)
            {
                if (item%2==0)
                {
                    even += item;
                }
                else
                {
                    odd += item;
                }
            }
            result = even - odd;
            Console.WriteLine(result);
        }
    }
}
