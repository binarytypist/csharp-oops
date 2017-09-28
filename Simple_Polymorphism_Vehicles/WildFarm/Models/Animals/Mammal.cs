using System;
using Problem3_WildFarm.Models.Foods;

namespace Problem3_WildFarm.Models.Animals
{
    // Mammal is an abstract class that extends Animal
    // It adds shared behavior and properties for all mammal animals
    public abstract class Mammal : Animal
    {
        // Encapsulated field representing where the animal lives
        private string livingRegion;

        // Constructor initializes base Animal properties and living region
        public Mammal(
            string animalName,
            string animalType,
            double animalWeight,
            string livingRegion
        ) : base(animalName, animalType, animalWeight)
        {
            this.LivingRegion = livingRegion;
        }

        // Property controlling access to living region
        public string LivingRegion
        {
            get { return this.livingRegion; }
            protected set { this.livingRegion = value; }
        }

        // String representation of Mammal used for output
        public override string ToString()
        {
            return $"{this.GetType().Name}[{this.AnimalName}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
        }

        // Eating logic for mammals with basic validation rules
        public override void Eat(Food food)
        {
            string animalType = this.GetType().Name;
            string foodType = food.GetType().Name;

            // Zebra and Mouse only eat Vegetables
            if ((animalType == "Zebra" || animalType == "Mouse") && foodType != "Vegetable")
            {
                Console.WriteLine($"{animalType}s are not eating that type of food!");
                return;
            }

            // Tigers only eat Meat
            if (animalType == "Tiger" && foodType != "Meat")
            {
                Console.WriteLine($"{animalType}s are not eating that type of food!");
                return;
            }

            // If valid food, increase eaten quantity
            this.FoodEaten += food.Quantity;
        }
    }
}