using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split();

            Action<int, string[]> func = new Action<int, string[]>((n, names) =>
            {
                Console.WriteLine(string.Join(Environment.NewLine, names.Where(name => name.Length <= n)));
            });

            func(n, names);
        }
    }
}
