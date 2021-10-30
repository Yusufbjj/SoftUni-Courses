﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }

        public override double FuelConsumption { get => DefaultFuelConsumption = 3; set { } }
    }
}
