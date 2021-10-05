using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> getSmallestNum = numbers =>
            {
                int minValue = Int32.MaxValue;
                foreach (var number in numbers)
                {
                    if (number < minValue)
                    {
                        minValue = number;
                    }
                }

                return minValue;
            };
            int[] inputNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(getSmallestNum(inputNums));
        }
    }
}
