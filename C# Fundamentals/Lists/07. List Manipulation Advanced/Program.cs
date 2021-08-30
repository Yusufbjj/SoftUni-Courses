using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            bool change = false;

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }
                string[] tokens = line.Split();
                switch (tokens[0])
                {
                    case "Add":
                        int numberToAdd = int.Parse(tokens[1]);
                        numbers.Add(numberToAdd);
                        change = true;
                        break;
                    case "Remove":
                        int numberToRemove = int.Parse(tokens[1]);
                        numbers.Remove(numberToRemove);
                        change = true;
                        break;
                    case "RemoveAt":
                        int numberToRemoveAt = int.Parse(tokens[1]);
                        numbers.RemoveAt(numberToRemoveAt);
                        change = true;
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(tokens[1]);
                        int index = int.Parse(tokens[2]);
                        numbers.Insert(index, numberToInsert);
                        change = true;
                        break;
                    case "Contains":
                        int number = int.Parse(tokens[1]);
                        if (numbers.Contains(number))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 == 0)));
                        break;
                    case "PrintOdd":
                        Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 == 1)));
                        break;
                    case "GetSum":
                        Console.WriteLine(string.Join(" ", numbers.Sum()));
                        break;
                    case "Filter":
                        string condition = tokens[1];
                        int num = int.Parse(tokens[2]);
                        if (condition == "<")
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(n => n < num)));
                        }
                        else if (condition == ">")
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(n => n > num)));
                        }
                        else if (condition == ">=")
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(n => n >= num)));
                        }
                        else if (condition == "<=")
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(n => n <= num)));
                        }
                        break;
                    default:
                        break;
                }
            }
            if (change)
            {
                Console.WriteLine(string.Join(" ",numbers));
            }
        }
    }
}
