using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(" ",
                StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> upperCaseFirstLetter = word => char.IsUpper(word[0]);
            var upperLetterWords = words.Where(upperCaseFirstLetter);

            foreach (var word in upperLetterWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
