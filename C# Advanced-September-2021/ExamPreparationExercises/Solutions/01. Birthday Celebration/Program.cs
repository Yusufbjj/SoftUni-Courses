using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Birthday_Celebration
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] guestsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> guests = new Queue<int>(guestsInput);
            int[] platesInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Stack<int> plates = new Stack<int>(platesInput);
            int wasteFood = 0;
            while (true)
            {
                //int guest = guests.Peek();
                //int plate = plates.Peek();
                if (plates.Peek() >= guests.Peek())
                {
                    int guest = guests.Peek();
                    int plate = plates.Peek();
                    wasteFood += plate - guest;
                    guest = guest - plate;
                    if (guest <= 0)
                    {
                        guests.Dequeue();
                        plates.Pop();
                    }
                }
                else
                {
                    int guest = guests.Peek();
                    int plate = plates.Peek();
                    int n = guest - plate;
                    while (n > 0)
                    {
                        plates.Pop();
                        plate = plates.Peek();
                        n = n - plate;
                    }

                    wasteFood += Math.Abs(n);
                    guests.Dequeue();
                    plates.Pop();

                }
                if (guests.Count == 0)
                {
                    Console.WriteLine($"Plates: {string.Join(" ", plates)}");
                    break;
                }
                if (plates.Count == 0)
                {
                    Console.WriteLine($"Guests: {string.Join(" ", guests)}");
                    break;
                }
            }
            Console.WriteLine($"Wasted grams of food: {wasteFood}");
        }
    }
}
