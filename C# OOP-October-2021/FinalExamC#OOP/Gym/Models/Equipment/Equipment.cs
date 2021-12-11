using System;
using System.Collections.Generic;
using System.Text;
using Gym.Models.Equipment.Contracts;

namespace Gym.Models.Equipment
{
    public abstract class Equipment : IEquipment
    {
        private double weight;
        private decimal price;

        protected Equipment(double weight, decimal price)
        {
            Weight = weight;
            Price = price;
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                weight = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            private set
            {
                price = value;
            }
        }
    }
}
