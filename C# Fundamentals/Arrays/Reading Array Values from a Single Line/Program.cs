using System;
using System.Linq;

namespace Reading_Array_Values_from_a_Single_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Console.WriteLine(string.Join("-", arr));

        }

    }
}
