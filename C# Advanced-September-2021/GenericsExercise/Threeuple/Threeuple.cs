using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class Threeuple<Item1, Item2, Item3>
    {
        public Threeuple(Item1 firstItem, Item2 secondItem, Item3 thirdItem)
        {
            FirstItem = firstItem;
            SecondItem = secondItem;
            ThirdItem = thirdItem;
        }

        public Item1 FirstItem { get; set; }

        public Item2 SecondItem { get; set; }

        public Item3 ThirdItem { get; set; }

        public string GetItems()
        {
            return $"{FirstItem} -> {SecondItem} -> {ThirdItem}";
        }
    }
}
