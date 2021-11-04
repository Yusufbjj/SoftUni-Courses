using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public Pizza(string name)
        {
            this.Name = name;
        }

        public Dough Dough
        {
            get
            {
                return dough;

            }
            private set
            {
                dough = value;

            }
        }

        public string Name
        {
            get
            {
                return name;

            }
            private set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;

            }
        }

        public double CalculateTotalCalories()
        {
            double toppingCalories = 0;
            foreach (Topping topping in toppings)
            {
                toppingCalories += topping.Calories;
            }

            double result = this.Dough.Calories + toppingCalories;

            return result;
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == 10)
            {
                throw new InvalidOperationException("Number of toppings should be in range [0..10].");
            }
            this.toppings.Add(topping);
        }

    }
}
