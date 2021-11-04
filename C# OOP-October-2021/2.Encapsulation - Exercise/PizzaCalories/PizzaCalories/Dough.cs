using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const string DoughExceptionMessage = "Invalid type of dough.";
        private const string WeightExceptionMessage = "Dough weight should be in the range [1..200].";

        private Dictionary<string, double> flourTypeCalories = new Dictionary<string, double>()
        {
            {"white",1.5},
            {"wholegrain",1},

        };

        private Dictionary<string, double> bakingTechniqueCalories = new Dictionary<string, double>()
        {
            {"crispy",0.9},
            {"chewy",1.1},
            {"homemade",1},
           
        };

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public double Weight
        {
            get
            {
                return weight;

            }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(WeightExceptionMessage);
                }

                weight = value;

            }
        }

        public string BakingTechnique
        {
            get
            {
                return bakingTechnique;

            }
            private set
            {
                if (!bakingTechniqueCalories.ContainsKey(value))
                {
                    throw new ArgumentException(DoughExceptionMessage);
                }

                bakingTechnique = value;

            }
        }

        public string FlourType
        {
            get
            {
                return flourType;

            }
            private set
            {
                if (!flourTypeCalories.ContainsKey(value))
                {
                    throw new ArgumentException(DoughExceptionMessage);
                }

                flourType = value;
            }
        }

        public double Calories =>
            2 * Weight * this.flourTypeCalories[this.FlourType] * this.bakingTechniqueCalories[this.bakingTechnique];

    }
}
