using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> grades = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (grades.ContainsKey(tokens[0]))
                {
                    grades[tokens[0]].Add(decimal.Parse(tokens[1]));
                }
                else
                {
                    grades.Add(tokens[0], new List<decimal>()
                    {
                        decimal.Parse(tokens[1])
                    });
                }
            }

            foreach (var grade in grades)
            {
                Console.WriteLine($"{grade.Key} -> {string.Join(" ",grade.Value.Select(v=>v.ToString("F2")))} (avg: {grade.Value.Average():F2})");
            }
        } 

    }
}
