using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamProblem1
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split(" ").Select(char.Parse));
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split(" ").Select(char.Parse));

            Dictionary<string, HashSet<char>> words = new Dictionary<string, HashSet<char>>();
            words["pear"] = new HashSet<char>();
            words["flour"] = new HashSet<char>();
            words["pork"] = new HashSet<char>();
            words["olive"] = new HashSet<char>();

            while (consonants.Count > 0)
            {
                var consonant = consonants.Pop();
                var vowel = vowels.Dequeue();

                foreach (var word in words)
                {
                    string keyName = word.Key;
                    if (keyName.Contains(consonant))
                    {
                        words[keyName].Add(consonant);
                    }

                    if (keyName.Contains(vowel))
                    {
                        words[keyName].Add(vowel);
                    }
                }


                vowels.Enqueue(vowel);

            }

            int foundWords = 0;

            foreach (var word in words)
            {
                string nameKey = word.Key;
                if (nameKey.Length == words[nameKey].Count)
                {
                    foundWords++;
                }
            }

            Console.WriteLine($"Words found: {foundWords}");
            foreach (var word in words)
            {
                string nameKey = word.Key;
                if (nameKey.Length == words[nameKey].Count)
                {
                    Console.WriteLine(nameKey);
                }
            }

        }
    }
}


