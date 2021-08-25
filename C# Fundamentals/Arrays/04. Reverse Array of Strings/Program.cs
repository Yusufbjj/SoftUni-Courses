using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] arr = Console.ReadLine().Split().Reverse().ToArray();
            Console.WriteLine(string.Join(" ", arr));
            
        }
    }
}
