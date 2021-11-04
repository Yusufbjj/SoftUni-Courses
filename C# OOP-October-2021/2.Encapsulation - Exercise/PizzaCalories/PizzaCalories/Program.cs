using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var pizzaInfo = Console.ReadLine().Split();
                var doughInfo = Console.ReadLine().Split();

                Dough dough = new Dough(doughInfo[1].ToLower(), doughInfo[2].ToLower(), double.Parse(doughInfo[3]));
                Pizza pizza = new Pizza(pizzaInfo[1], dough);

                var toppingType = Console.ReadLine();
                while (toppingType != "END")
                {
                    var tokens = toppingType.Split();
                    Topping topping = new Topping(tokens[1], double.Parse(tokens[2]));
                    pizza.AddTopping(topping);
                    toppingType = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.CalculateTotalCalories():F2} Calories.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
