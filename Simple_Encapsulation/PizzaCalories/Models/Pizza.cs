using PizzaCalories.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories.Models
{
    public class Pizza
    {
        // Encapsulation: internal state is hidden from external modification
        private string name;
        private Dough dough;
        private IList<Topping> toppings;

        // Constructor ensures mandatory dependencies are provided
        // A Pizza cannot exist without a name and dough
        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;

            // Composition: Pizza owns its toppings collection
            this.Toppings = new List<Topping>();
        }

        // Read-only computed property exposing number of toppings
        public int ToppingsCount => this.toppings.Count;

        // Computed property: total calories derived from internal components
        public double TotalCalories => this.CalculatePizzaCalories();

        // Encapsulated collection to prevent external replacement
        private IList<Topping> Toppings
        {
            get { return toppings; }
            set { toppings = value; }
        }

        // Dough is part of the Pizza composition (has-a relationship)
        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }

        // Name validation ensures business rule consistency
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        // Core business logic: aggregates calories from dough and toppings
        private double CalculatePizzaCalories()
        {
            double doughCalories = this.Dough.CalculateCalories();
            double toppingsCalories = this.toppings.Sum(t => t.CalculateCalories());

            return doughCalories + toppingsCalories;
        }

        // Adds a topping while maintaining encapsulation of internal list
        public void AddTopping(Topping topping)
        {
            this.Toppings.Add(topping);
        }

        // Provides formatted output representation of the object
        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:F2} Calories.";
        }
    }
}