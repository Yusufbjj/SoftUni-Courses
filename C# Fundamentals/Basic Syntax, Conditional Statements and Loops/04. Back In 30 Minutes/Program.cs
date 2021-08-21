using System;

namespace _04._Back_In_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = 30 + int.Parse(Console.ReadLine());

            if (minutes > 59)
            {
                hours += 1;
                minutes -= 60;
            }
            if (hours > 23)
            {
                hours = 0;

            }
            Console.WriteLine($"{hours}:{minutes:D2}");

        }
    }
}
