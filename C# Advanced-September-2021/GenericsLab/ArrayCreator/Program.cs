using System;
using GenericArrayCreator;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] arrsStrings = ArrayCreator.Create(5, "Pepi");
            Console.WriteLine(string.Join(" ", arrsStrings));
            int[] numInts = ArrayCreator.Create(5, 5);

        }
    }
}
