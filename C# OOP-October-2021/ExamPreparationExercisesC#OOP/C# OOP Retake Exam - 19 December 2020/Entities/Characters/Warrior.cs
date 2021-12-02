using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double BaseHealth = 100;
        private const double BaseArmor = 50;
        private const double abilityPoints = 40;
     

        public Warrior(string name)
            : base(name, BaseHealth, BaseArmor, abilityPoints, new Satchel())
        {
            
        }


        public void Attack(Character character)
        {
           this.EnsureAlive();

           if (character.Equals(this))
           {
               throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
           }

           character.TakeDamage(this.AbilityPoints);
        }


    }
}
