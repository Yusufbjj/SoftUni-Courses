using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        public string Model { get; set; }

        public int Power { get; set; }

        public int Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"  {Model}:");
            stringBuilder.AppendLine($"    Power: {Power}");
            stringBuilder.AppendLine($"    Displacement: {(Displacement > 0 ? Displacement.ToString() : "n/a")}");
            stringBuilder.AppendLine($"    Efficiency: {Efficiency ?? "n/a"}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
