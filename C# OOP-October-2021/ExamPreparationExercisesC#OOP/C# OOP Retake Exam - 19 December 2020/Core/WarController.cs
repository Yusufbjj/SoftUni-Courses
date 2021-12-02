using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> party;
        private List<Item> items;

        public WarController()
        {
            this.party = new List<Character>();
            this.items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            Character character = null;

            if (characterType == "Warrior")
            {
                character = new Warrior(name);
            }
            else if (characterType == "Priest")
            {
                character = new Priest(name);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }

            this.party.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item = null;

            if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else if (itemName == "FirePotion")
            {
                item = new FirePotion();
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }


            this.items.Add(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = this.party.FirstOrDefault(x => x.Name == characterName);

            if (character is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }
            Item item = this.items.Last();



            character.Bag.AddItem(item);
            this.items.Remove(item);
            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            Character character = this.party.FirstOrDefault(x => x.Name == characterName);

            if (character is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            Item item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Character character in party.AsReadOnly().OrderByDescending(x => x.IsAlive == true).ThenByDescending(x => x.Health).ToList())
            {
                string status = null;
                if (character.IsAlive)
                {
                    status = "Alive";
                }
                else
                {
                    status = "Dead";
                }
                sb.AppendLine(
                    $"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {status}");
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string atackerName = args[0];
            string receiverName = args[1];
            Warrior attacker = (Warrior)this.party.FirstOrDefault(x => x.Name == atackerName);
            Character receiver = this.party.FirstOrDefault(x => x.Name == receiverName);

            if (attacker is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, atackerName));
            }

            if (receiver is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }


            attacker.Attack(receiver);




            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{atackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (receiver.IsAlive == false)
            {
                sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiverName));
            }

            return sb.ToString().TrimEnd();

        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Priest healer = (Priest)this.party.FirstOrDefault(x => x.Name == healerName);
            Character character = this.party.FirstOrDefault(x => x.Name == healingReceiverName);

            if (healer is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healer));
            }

            if (character is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }

            var isAliveHealer = healer.IsAlive;
            var isAliveReceiver = character.IsAlive;

            if (!isAliveHealer)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }
            else if (!isAliveReceiver)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AffectedCharacterDead));
            }
            else
            {
                healer.Heal(character);
            }



            StringBuilder sb = new StringBuilder();
            sb.AppendLine(
                $"{healer.Name} heals {character.Name} for {healer.AbilityPoints}! {character.Name} has {character.Health} health now!");

            return sb.ToString().TrimEnd();

        }
    }
}
