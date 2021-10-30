using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public double DefaultFuelConsumption
        {
            get => DefaultFuelConsumption = 1.25;
            set { }
        }

        public virtual double FuelConsumption { get => DefaultFuelConsumption; set { } }

        public double Fuel { get; set; }

        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            var usedFuelInLiters = kilometers * FuelConsumption;

            Fuel -= usedFuelInLiters;
        }
    }
}
