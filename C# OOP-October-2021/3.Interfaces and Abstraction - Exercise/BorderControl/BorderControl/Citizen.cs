using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IIdentifiable,IBirthdable,IBuyer
    {
        private string name;

        private int age;


        public Citizen(string name, int age, string id,string birthdate)
        {
            this.name = name;
            this.age = age;
            Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }
        public string Id { get; private set; }
        public string Birthdate { get; private set; }
        public int Food { get; private set; }
        public void BuyFood()
        {
            this.Food += 10;
        }

    }
}
