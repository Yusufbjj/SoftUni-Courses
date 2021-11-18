using System;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person("Pepi", 15);

            bool isValIdentity = Validator.IsValid(person);

            Console.WriteLine(isValIdentity);
        }
    }
}
