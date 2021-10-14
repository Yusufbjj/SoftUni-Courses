using System;
using System.Collections.Generic;

namespace Tuples
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*Adam Smith California
            Mark 2
            23 21.23212321*/
            string[] nameTownInput = Console.ReadLine().Split();
            string name = $"{nameTownInput[0]} {nameTownInput[1]}";
            string town = nameTownInput[2];


            string[] nameBeerInput = Console.ReadLine().Split();
            string beerName = nameBeerInput[0];
            int liters = int.Parse(nameBeerInput[1]);

            string[] numbersInput = Console.ReadLine().Split();
            int integer = int.Parse(numbersInput[0]);
            double doubleNumber = double.Parse(numbersInput[1]);


            MyTuple<string, string> nameTown = new MyTuple<string, string>(name, town);

            MyTuple<string, int> nameBeer = new MyTuple<string, int>(beerName, liters);

            MyTuple<int, double> numbers = new MyTuple<int, double>(integer, doubleNumber);

            Console.WriteLine(nameTown.GetItems());
            Console.WriteLine(nameBeer.GetItems());
            Console.WriteLine(numbers.GetItems());
        }
    }
}
