﻿using System.Collections.Generic;
using SpaceStation.Models.Bags.Contracts;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        public Backpack()
        {
            this.Items = new List<string>();
        }

        public override ICollection<string> Items { get; }
    }
}
