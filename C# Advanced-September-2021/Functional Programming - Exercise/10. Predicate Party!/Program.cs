using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();
            string line = Console.ReadLine();

            while (line != "Party!")
            {
                string[] tokens = line.Split();
                Predicate<string> predicate = GetPredicate(tokens[1], tokens[2]);

                if (tokens[0] == "Remove")
                {
                    people.RemoveAll(predicate);
                }
                else if (tokens[0] == "Double")
                {
                    List<string> doubleNames = people.FindAll(predicate);
                    if (doubleNames.Any())
                    {
                        int index = doubleNames.FindIndex(predicate);
                        people.InsertRange(index, doubleNames);
                    }
                }

                line = Console.ReadLine();
            }

            if (people.Any())
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }

        private static Predicate<string> GetPredicate(string token, string param)
        {
            if (token == "StartsWith")
            {
                return x => x.StartsWith(param);
            }

            if (token == "EndsWith")
            {
                return x => x.EndsWith(param);
            }

            int length = int.Parse(param);

            return x => x.Length == length;

        }
    }
}
