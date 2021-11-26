using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int ornamentComfort = 5;
        private const decimal ornamentPrice = 10.0m;

        public Plant()
            : base(ornamentComfort, ornamentPrice)
        {

        }
    }
}
