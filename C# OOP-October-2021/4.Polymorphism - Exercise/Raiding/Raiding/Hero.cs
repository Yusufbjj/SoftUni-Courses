using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class Hero
    {
        protected Hero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public string Name { get; }

        public int Power { get; }

        public abstract string CastAbility();



    }
}
