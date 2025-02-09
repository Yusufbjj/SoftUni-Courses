﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const decimal CoffeePrice = (decimal)3.50;
        private const double CoffeeMilliliters = 50;


        public Coffee(string name,double caffeine)
            : base(name, CoffeePrice, CoffeeMilliliters)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; set; }


    }
}
