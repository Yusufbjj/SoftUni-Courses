using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            Dictionary<string, int> foods = new Dictionary<string, int>();

            foods.Add("Bread", 25);
            foods.Add("Cake", 50);
            foods.Add("Pastry", 75);
            foods.Add("Fruit Pie", 100);

            Dictionary<string, int> foodsCooked = new Dictionary<string, int>();

            foodsCooked.Add("Bread", 0);
            foodsCooked.Add("Cake", 0);
            foodsCooked.Add("Pastry", 0);
            foodsCooked.Add("Fruit Pie", 0);

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int liquid = liquids.Peek();
                int ingredient = ingredients.Pop();

                int sum = liquid + ingredient;

                if (sum == 25)
                {
                    foods.Remove("Bread");
                    foodsCooked["Bread"]++;
                }
                else if (sum == 50)
                {
                    foods.Remove("Cake");
                    foodsCooked["Cake"]++;
                }
                else if (sum == 75)
                {
                    foods.Remove("Pastry");
                    foodsCooked["Pastry"]++;
                }
                else if (sum == 100)
                {
                    foods.Remove("Fruit Pie");
                    foodsCooked["Fruit Pie"]++;
                }
                else
                {
                    liquids.Dequeue();
                    ingredient += 3;
                    ingredients.Push(ingredient);
                    continue;
                }

                liquids.Dequeue();
                
            }

            if (foods.Count == 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Any())
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foreach (var food in foodsCooked.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{food.Key}: {food.Value}");
            }
        }
    }
}
