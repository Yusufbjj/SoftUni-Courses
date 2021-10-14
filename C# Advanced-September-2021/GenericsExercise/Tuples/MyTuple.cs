using System;
using System.Collections.Generic;
using System.Text;

namespace Tuples
{
    public class MyTuple<Item1, Item2>
    {
        public MyTuple(Item1 leftItem, Item2 rightItem)
        {
            LeftItem = leftItem;
            RightItem = rightItem;
        }

        public Item1 LeftItem { get; set; }

        public Item2 RightItem { get; set; }

        public string GetItems()
        {
            return $"{LeftItem} -> {RightItem}";
        }
    }
}
