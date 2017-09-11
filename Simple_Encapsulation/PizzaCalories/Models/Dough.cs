using System;

namespace PizzaCalories.Models
{
    public class Dough
    {
        // Encapsulation: internal state is hidden
        private string flourType;
        private string technique;
        private int weight;

        // Constructor ensures valid initialization
        public Dough(string flourType, string technique, int weight)
        {
            this.FlourType = flourType;
            this.Technique = technique;
            this.Weight = weight;
        }

        // Validates dough weight (business rule)
        private int Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        // Validates baking technique (domain rules)
        private string Technique
        {
            get { return this.technique; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) ||
                    (value.ToLower() != "crispy" &&
                     value.ToLower() != "chewy" &&
                     value.ToLower() != "homemade"))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.technique = value;
            }
        }

        // Validates flour type (domain constraints)
        private string FlourType
        {
            get { return this.flourType; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) ||
                    (value.ToLower() != "white" &&
                     value.ToLower() != "wholegrain"))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        // Business logic: calculates calories for dough
        public double CalculateCalories()
        {
            double baseCalories = 2 * this.weight;

            // Flour modifier
            double flourModifier = this.flourType.ToLower() == "white" ? 1.5 : 1.0;

            // Technique modifier
            double techniqueModifier = 1.0;

            switch (this.technique.ToLower())
            {
                case "crispy":
                    techniqueModifier = 0.9;
                    break;
                case "chewy":
                    techniqueModifier = 1.1;
                    break;
                case "homemade":
                    techniqueModifier = 1.0;
                    break;
            }

            // Final calculation
            return baseCalories * flourModifier * techniqueModifier;
        }
    }
}