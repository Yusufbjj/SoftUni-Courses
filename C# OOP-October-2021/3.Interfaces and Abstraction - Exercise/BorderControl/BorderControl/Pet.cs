using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pet : IBirthdable
    {
        private string name;

        public Pet(string name, string birthdate)
        {
            this.name = name;
            Birthdate = birthdate;
        }
        public string Birthdate { get; private set; }
    }
}
