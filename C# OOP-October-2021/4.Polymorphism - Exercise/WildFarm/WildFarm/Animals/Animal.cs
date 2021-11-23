using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food;

namespace WildFarm.Animals
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
        public abstract string ProduceSound();

        public abstract void Eat(IFood food);

        protected void ThrowInvalidOperationExceptionForFood(IAnimal animalType, IFood foodType)
        {
            throw new InvalidOperationException($"{animalType.GetType().Name} does not eat {foodType.GetType().Name}!");
        }



    }
}
