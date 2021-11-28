namespace SpaceStation.Models.Bags.Contracts
{
    using System.Collections.Generic;

    public abstract class IBag
    {
        public abstract ICollection<string> Items { get; }
    }
}
