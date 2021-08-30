using System;
using System.Collections.Generic;
using System.Linq;
namespace _06._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

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
                        break;
                    case "Remove":
                        int numberToRemove = int.Parse(tokens[1]);
                        numbers.Remove(numberToRemove);
                        break;
                    case "RemoveAt":
                        int numberToRemoveAt = int.Parse(tokens[1]);
                        numbers.RemoveAt(numberToRemoveAt);
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(tokens[1]);
                        int index = int.Parse(tokens[2]);
                        numbers.Insert(index, numberToInsert);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
