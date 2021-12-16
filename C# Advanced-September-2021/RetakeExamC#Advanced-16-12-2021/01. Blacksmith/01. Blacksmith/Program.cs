using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            SortedDictionary<string, int> swords = new SortedDictionary<string, int>();

            swords.Add("Gladius", 0);
            swords.Add("Shamshir", 0);
            swords.Add("Katana", 0);
            swords.Add("Sabre", 0);
            swords.Add("Broadsword", 0);

            int totalSwordsForged = 0;

            while (carbon.Count > 0 && steel.Count > 0)
            {
                if (steel.Peek() + carbon.Peek() == 70)
                {
                    swords["Gladius"]++;

                    totalSwordsForged++;

                    carbon.Pop();
                    steel.Dequeue();
                }
                else if (steel.Peek() + carbon.Peek() == 80)
                {
                    swords["Shamshir"]++;

                    totalSwordsForged++;

                    carbon.Pop();
                    steel.Dequeue();
                }
                else if (steel.Peek() + carbon.Peek() == 90)
                {
                    swords["Katana"]++;

                    totalSwordsForged++;

                    carbon.Pop();
                    steel.Dequeue();
                }
                else if (steel.Peek() + carbon.Peek() == 110)
                {
                    swords["Sabre"]++;

                    totalSwordsForged++;

                    carbon.Pop();
                    steel.Dequeue();
                }
                else if (steel.Peek() + carbon.Peek() == 150)
                {
                    swords["Broadsword"]++;

                    totalSwordsForged++;

                    carbon.Pop();
                    steel.Dequeue();

                }
                else
                {
                    int carbonValue = carbon.Pop();
                    carbonValue += 5;

                    steel.Dequeue();

                    carbon.Push(carbonValue);

                }
            }

            string swordsCreated = totalSwordsForged > 0
                ? $"You have forged {totalSwordsForged} swords."
                : "You did not have enough resources to forge a sword.";

            Console.WriteLine(swordsCreated);

            string resultSteel = steel.Count > 0 ? string.Join(", ", steel) : "none";
            string resultCarbon = carbon.Count > 0 ? string.Join(", ", carbon) : "none";

            Console.WriteLine($"Steel left: {resultSteel}");
            Console.WriteLine($"Carbon left: {resultCarbon}");

            foreach (var sword in swords)
            {
                if (sword.Value > 0)
                {
                    Console.WriteLine($"{sword.Key}: {sword.Value}");
                }
            }
        }
    }
}
