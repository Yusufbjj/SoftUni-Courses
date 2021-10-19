using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ingridientsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] freshnessInput = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();

            Queue<int> ingridients = new Queue<int>(ingridientsInput);
            Stack<int> freshness = new Stack<int>(freshnessInput);

            int dippingSauce = 0;
            int greenSalad = 0;
            int chocolateCake = 0;
            int lobster = 0;



            SortedDictionary<string, int> preparedDishes = new SortedDictionary<string, int>()
            {
                {"Dipping sauce",dippingSauce},
                {"Green salad",greenSalad},
                {"Chocolate cake",chocolateCake},
                {"Lobster",lobster}

            };

            while (ingridients.Any() && freshness.Any())
            {
                int currentIngidient = ingridients.Peek();
                int currentFreshness = freshness.Peek();

                if (currentIngidient == 0)
                {
                    ingridients.Dequeue();
                    continue;

                }

                if (currentIngidient * currentFreshness == 150)
                {
                    ingridients.Dequeue();
                    freshness.Pop();
                    preparedDishes["Dipping sauce"]++;
                    dippingSauce++;
                }
                else if (currentIngidient * currentFreshness == 250)
                {
                    ingridients.Dequeue();
                    freshness.Pop();
                    preparedDishes["Green salad"]++;
                    greenSalad++;
                }
                else if (currentIngidient * currentFreshness == 300)
                {
                    ingridients.Dequeue();
                    freshness.Pop();
                    preparedDishes["Chocolate cake"]++;
                    chocolateCake++;
                }
                else if (currentIngidient * currentFreshness == 400)
                {
                    ingridients.Dequeue();
                    freshness.Pop();
                    preparedDishes["Lobster"]++;
                    lobster++;
                }

                else
                {
                    freshness.Pop();
                    currentIngidient += 5;
                    ingridients.Enqueue(currentIngidient);
                    ingridients.Dequeue();
                }

            }
            bool succes = dippingSauce >= 1 && greenSalad >= 1 && chocolateCake >= 1 && lobster >= 1;
            var sum = ingridients.Sum();
            if (succes)
            {

                Console.WriteLine("Applause! The judges are fascinated by your dishes! ");
                if (sum != 0)
                {
                    Console.WriteLine($"Ingredients left: {sum}");
                }
                foreach (var dish in preparedDishes)
                {
                    Console.WriteLine($" # {dish.Key} --> {dish.Value}");
                }

            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
                if (sum != 0)
                {
                    Console.WriteLine($"Ingredients left: {sum}");
                }
                foreach (var dish in preparedDishes)
                {
                    if (dish.Value > 0)
                    {
                        Console.WriteLine($" # {dish.Key} --> {dish.Value}");
                    }

                }

            }
        }
    }
}