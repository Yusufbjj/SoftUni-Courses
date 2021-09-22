using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe =
                new Dictionary<string, Dictionary<string, int>>();
            FillDictionary(n, wardrobe);
            var color = NeededClothes(out var clothing);
            PrintDictionary(wardrobe, color, clothing);
        }

        static string NeededClothes(out string clothing)
        {
            string[] neededPiece = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string color = neededPiece[0];
            clothing = neededPiece[1];
            return color;
        }

        static void PrintDictionary(Dictionary<string, Dictionary<string, int>> wardrobe, string color, string clothing)
        {
            foreach (var kvp in wardrobe)
            {
                Console.WriteLine($"{kvp.Key} clothes:");
                foreach (var clothes in kvp.Value)
                {
                    if (clothes.Key == clothing && kvp.Key == color)
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value} (found!)");
                        continue;
                    }
                    Console.WriteLine($"* {clothes.Key} - {clothes.Value}");

                }
            }
        }


        static void FillDictionary(int n, Dictionary<string, Dictionary<string, int>> wardrobe)
        {
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string color = input[0];
                string[] clothes = input[1].Split(",").ToArray();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (var clothe in clothes)
                {
                    if (!wardrobe[color].ContainsKey(clothe))
                    {
                        wardrobe[color].Add(clothe, 0);
                    }

                    wardrobe[color][clothe]++;
                }
            }
        }
    }
}
