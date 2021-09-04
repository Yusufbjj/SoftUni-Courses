using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputName = Console.ReadLine();
            Queue<string> names = new Queue<string>();

            while (inputName != "End")
            {
                

                if (inputName == "Paid")
                {
                    for (int i = names.Count; i > 0; i--)
                    {
                        Console.WriteLine(names.Dequeue());
                    }
                }
                else
                {
                    names.Enqueue(inputName);
                }
                inputName = Console.ReadLine();
            }
            Console.WriteLine($"{names.Count} people remaining.");

        }
    }
}
