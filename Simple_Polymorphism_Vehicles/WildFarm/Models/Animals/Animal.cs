using Problem3_WildFarm.Models.Foods;

namespace Problem3_WildFarm.Models.Animals
{
    // Abstract base class representing a generic animal in the Wild Farm system
    // All specific animals (Mouse, Zebra, Tiger, etc.) inherit from this class
    public abstract class Animal
    {
        // Encapsulated fields storing animal state
        private string animalName;
        private string animalType;
        private double animalWeight;
        private int foodEaten;

        // Constructor initializes shared animal properties
        public Animal(string animalName, string animalType, double animalWeight)
        {
            this.AnimalName = animalName;
            this.AnimalType = animalType;
            this.AnimalWeight = animalWeight;

            // All animals start with 0 food eaten
            this.FoodEaten = 0;
        }

        // Property tracking how much food the animal has eaten
        public int FoodEaten
        {
            get { return this.foodEaten; }
            protected set { this.foodEaten = value; }
        }

        // Property representing animal weight
        public double AnimalWeight
        {
            get { return this.animalWeight; }
            protected set { this.animalWeight = value; }
        }

        // Property representing the type/species of the animal
        public string AnimalType
        {
            get { return this.animalType; }
            protected set { this.animalType = value; }
        }

        // Property representing the animal's name
        public string AnimalName
        {
            get { return this.animalName; }
            protected set { this.animalName = value; }
        }

        // Abstract method: each animal must define how it makes sound
        public abstract void MakeSound();

        // Abstract method: each animal defines how it eats different food types
        public abstract void Eat(Food food);
    }
}