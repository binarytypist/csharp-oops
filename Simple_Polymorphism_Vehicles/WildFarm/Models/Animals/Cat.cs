using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem3_WildFarm.Models.Foods;

namespace Problem3_WildFarm.Models.Animals
{
    // Cat is a specific type of Feline animal in the WildFarm system
    // It inherits common feline behavior (like living region, weight, etc.)
    public class Cat : Feline
    {
        // Encapsulated field storing cat breed information
        private string breed;

        // Constructor initializes base Feline properties and cat-specific breed
        public Cat(
            string animalName,
            string animalType,
            double animalWeight,
            string livingRegion,
            string catBreed
        ) : base(animalName, animalType, animalWeight, livingRegion)
        {
            this.Breed = catBreed;
        }

        // Property for accessing and setting cat breed (private set for safety)
        public string Breed
        {
            get { return this.breed; }
            private set { this.breed = value; }
        }

        // Polymorphism:
        // Cat overrides MakeSound to produce its specific sound
        public override void MakeSound()
        {
            Console.WriteLine("Meowwww");
        }

        // String representation of Cat object used for printing results
        public override string ToString()
        {
            return $"{this.GetType().Name}[{this.AnimalName}, {this.Breed}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}