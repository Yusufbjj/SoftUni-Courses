using System;
using System.Linq;

namespace GenericBoxOfString
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box<double> strBox = new Box<double>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());

                strBox.Add(input);
            }

            double itemToCompare = double.Parse(Console.ReadLine());

            int result = strBox.CountGreaterThan(itemToCompare);

            Console.WriteLine(result);

        }
    }
}
