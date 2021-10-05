using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    class Person
    {
        public string Name;

        public int Age;

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                var parts = line.Split(", ");
                var person = new Person();
                person.Name = parts[0];
                person.Age = int.Parse(parts[1]);
                people.Add(person);

            }

            var filterName = Console.ReadLine();
            var ageToCompareWith = int.Parse(Console.ReadLine());

            Func<Person, bool> filter = p => true;
            if (filterName == "younger")
            {
                filter = p => p.Age < ageToCompareWith;

            }
            else if (filterName == "older")
            {
                filter = p => p.Age >= ageToCompareWith;
            }

            var filteredPeople = people.Where(filter);

            var printName = Console.ReadLine();
            Func<Person, string> printFunc = p => p.Name + " " + p.Age;

            if (printName == "name age")
            {
                printFunc = p => p.Name + " - " + p.Age;
            }
            else if (printName == "name")
            {
                printFunc = p => p.Name;
            }
            else if (printName == "age")
            {
                printFunc = p => p.Age.ToString();
            }

            var personAsString = filteredPeople.Select(printFunc);

            foreach (var str in personAsString)
            {
                Console.WriteLine(str);
            }
        }
    }
}
