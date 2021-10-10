using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace RawDate
{
    public class Cargo
    {
        public Cargo(string type, int weight)
        {
            Type = type;
            Weight = weight;
        }

        public string Type { get; set; }

        public int Weight { get; set; }
    }
}
