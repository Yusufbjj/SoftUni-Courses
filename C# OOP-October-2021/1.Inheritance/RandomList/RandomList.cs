using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {

        private Random random;

        public RandomList()
        {
            this.random = new Random();
        }

        public string RandomString()
        {
            var index = random.Next(0, Count);
            return this[index];
        }

        public void RemoveRandomElement()
        {
            int index = random.Next(0, Count);
            RemoveAt(index);
            
        }
    }
}
