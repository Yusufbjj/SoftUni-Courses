using System;

namespace _12._Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            while (!(n % 2 == 0))
            {
                Console.WriteLine("Please write an even number.");
                n = int.Parse(Console.ReadLine());
<<<<<<< HEAD
            }
            Console.WriteLine($"The number is: {Math.Abs(n)}");

=======
               
            }
            Console.WriteLine($"The number is: {Math.Abs(n)}");


>>>>>>> f2c3f1bd5084db7cd8a2de5a6ef5dea425010174
        }
    }
}
