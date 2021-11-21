using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Rebel : IBuyer
    {
        private string name;
        private int age;
        private string group;

        public Rebel(string name, int age, string @group)
        {
            this.name = name;
            this.age = age;
            this.@group = @group;
            this.Food = 0;
        }
        public int Food { get; private set; }
        public void BuyFood()
        {
            this.Food += 5;
        }

    }
}
