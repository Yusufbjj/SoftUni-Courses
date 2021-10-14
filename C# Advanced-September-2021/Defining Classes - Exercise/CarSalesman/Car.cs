using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{Model}:");

            stringBuilder.AppendLine(Engine.ToString());
            
            stringBuilder.AppendLine($"  Weight: {(Weight > 0 ? Weight.ToString() : "n/a")}");
            stringBuilder.AppendLine($"  Color: {Color ?? "n/a"}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
