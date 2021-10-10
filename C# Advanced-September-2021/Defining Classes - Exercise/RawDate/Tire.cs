using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace RawDate
{
    public class Tire
    {
        public Tire(int age, double pressure)
        {
            Age = age;
            Pressure = pressure;
        }

        public int Age { get; set; }
        public double Pressure { get; set; }
    }
}
