using System;

namespace PizzaCalories.Models
{
    public class Topping
    {
        // Encapsulation: internal state hidden
        private string toppingType;
        private int weight;

        // Constructor ensures valid object creation
        public Topping(string toppingType, int weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        // Validates topping weight
        private int Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException("Topping weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        // Validates allowed topping types
        private string ToppingType
        {
            get { return this.toppingType; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) ||
                    (value.ToLower() != "meat" &&
                     value.ToLower() != "veggies" &&
                     value.ToLower() != "cheese" &&
                     value.ToLower() != "sauce"))
                {
                    throw new ArgumentException("Cannot place topping on pizza.");
                }

                this.toppingType = value;
            }
        }

        // Business logic: calculates topping calories
        public double CalculateCalories()
        {
            double baseCalories = 2 * this.weight;

            double modifier = 1.0;

            switch (this.toppingType.ToLower())
            {
                case "meat":
                    modifier = 1.2;
                    break;
                case "veggies":
                    modifier = 0.8;
                    break;
                case "cheese":
                    modifier = 1.1;
                    break;
                case "sauce":
                    modifier = 0.9;
                    break;
            }

            return baseCalories * modifier;
        }
    }
}