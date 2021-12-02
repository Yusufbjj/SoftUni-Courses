using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double health = 50;
        private const double armor = 25;
        private const double abilityPoints = 40;
        

        public Priest(string name)
            : base(name, health, armor, abilityPoints, new Backpack())
        {

        }

        public void Heal(Character character)
        {
            this.EnsureAlive();

            if (character.IsAlive)
            {
                character.Health += this.AbilityPoints;
            }

        }


    }
}
