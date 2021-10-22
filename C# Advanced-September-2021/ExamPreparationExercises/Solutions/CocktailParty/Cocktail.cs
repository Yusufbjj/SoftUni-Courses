using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            ingredients = new List<Ingredient>();
        }


        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public int CurrentAlcoholLevel
        {
            get
            {
                var sum = 0;
                foreach (Ingredient ingredient in ingredients)
                {
                    sum += ingredient.Alcohol;
                }

                return sum;
            }
        }

        public void Add(Ingredient ingredient)
        {
            if (ingredients.FirstOrDefault(i => i.Name == ingredient.Name) == null && ingredients.Count < Capacity)
            {
                ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            var ingredient = ingredients.FirstOrDefault(i => i.Name == name);
            if (ingredient == null)
            {
                return false;
            }

            ingredients.Remove(ingredient);
            return true;
        }

        public Ingredient FindIngredient(string name)
        {
            var ingredient = ingredients.FirstOrDefault(i => i.Name == name);
            return ingredient;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return ingredients.OrderByDescending(i => i.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (Ingredient ingredient in ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().TrimEnd();
        }



    }
}
