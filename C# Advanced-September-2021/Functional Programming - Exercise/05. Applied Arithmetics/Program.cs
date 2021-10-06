using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();

            Func<List<int>, List<int>> add = ints =>
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    nums[i] += 1;
                }

                return nums;
            };
            Func<List<int>, List<int>> multiply = ints =>
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    nums[i] *= 2;
                }

                return nums;
            };
            Func<List<int>, List<int>> subtract = ints =>
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    nums[i] -= 1;
                }

                return nums;
            };
            Action<List<int>> print = ints =>
            {
                Console.WriteLine(string.Join(" ", ints));
            };

            while (command != "end")
            {
                if (command == "add")
                {
                    add(nums);
                }
                else if (command == "multiply")
                {
                    multiply(nums);
                }
                else if (command == "subtract")
                {
                    subtract(nums);
                }
                else if (command == "print")
                {
                    print(nums);
                }

                command = Console.ReadLine();
            }
        }
    }
}
