using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int capacity = 100;
        private List<Item> items;
        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                this.capacity = value;
            }
        }

        public int Load
        {
            get
            {
                return this.Items.Sum(x => x.Weight);
            }
        }

        public IReadOnlyCollection<Item> Items { get=>this.items; }
        public void AddItem(Item item)
        {
            if (item.Weight + this.Load > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            items.Add(item);
        }

        public Item GetItem(string name)
        {

            if (this.Items.Count==0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            Item item = this.items.FirstOrDefault(x => x.GetType().Name == name);

            if (item is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag,name));
            }

            this.items.Remove(item);

            return item;
        }
    }
}
