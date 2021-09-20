using System;
using System.Collections.Generic;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            SortedDictionary<string, Dictionary<string, double>> shops =
                new SortedDictionary<string, Dictionary<string, double>>();
            while (command != "Revision")
            {
                string[] tokens = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);
                if (!shops.ContainsKey(shop))
                {
                    shops[shop] = new Dictionary<string, double>();
                }
                shops[shop].Add(product, price);
                command = Console.ReadLine();
            }

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
