using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> secondBox = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            List<int> collectedItems = new List<int>();



            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int itemFirstBox = firstBox.Peek();
                int itemSecondBox = secondBox.Peek();

                int itemsSum = itemFirstBox + itemSecondBox;

                if (itemsSum % 2 == 0)
                {
                    itemsSum = itemFirstBox + itemSecondBox;

                    collectedItems.Add(itemsSum);

                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(itemSecondBox);

                    secondBox.Pop();
                }

            }

            if (!firstBox.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (!secondBox.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (collectedItems.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {collectedItems.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {collectedItems.Sum()}");
            }

        }
    }
}
