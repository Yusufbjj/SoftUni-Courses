using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food;

namespace WildFarm.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight,  double wingSize)
            : base(name, weight, wingSize)
        {

        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                this.FoodEaten += food.Quantity;
                this.Weight += food.Quantity * 0.25;
            }
            else
            {
                ThrowInvalidOperationExceptionForFood(this, food);
            }
        }
    }
}
