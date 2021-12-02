using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;

        protected Character(string name, double health, double armor, double abilityPoints, IBag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.BaseArmor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Health = health;
            this.Armor = armor;
        }


        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; private set; }
        public double Health { get; set; }

        public double BaseArmor { get; private set; }
        public double Armor { get; private set; }

        public double AbilityPoints { get; private set; }

        public IBag Bag { get; private protected set; }

        public bool IsAlive { get; set; } = true;

        public void TakeDamage(double hitPoints)
        {

            this.EnsureAlive();

            if (hitPoints <= this.Armor)
            {
                this.Armor -= hitPoints;
            }
            else
            {
                hitPoints -= this.Armor;
                this.Armor = 0;
                this.Health -= hitPoints;
            }

            if (this.Health <= 0)
            {
                this.Health = 0;
                this.IsAlive = false;
            }

        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();

            item.AffectCharacter(this);

        }


        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }


    }
}