﻿using System;
using System.Text;

namespace Drones
{
    public class Drone
    {

        public Drone(string name, string brand, int range)
        {
            Name = name;
            Brand = brand;
            Range = range;
            Available = true;
        }

        public string Name { get; set; }

        public string Brand { get; set; }

        public int Range { get; set; }

        public bool Available { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drone: {Name}");
            sb.AppendLine($"Manufactured by: {Brand}");
            sb.AppendLine($"Range: {Range} kilometers");

            return sb.ToString().TrimEnd();
        }

    }
}
