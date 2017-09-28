namespace Problem3_WildFarm.Models.Animals
{
    // Feline is an abstract class representing all cat-like animals
    // It inherits from Mammal and adds no new logic, only structure grouping
    public abstract class Feline : Mammal
    {
        // Constructor passes all required properties to the Mammal base class
        public Feline(
            string animalName,
            string animalType,
            double animalWeight,
            string livingRegion
        ) : base(animalName, animalType, animalWeight, livingRegion)
        {
        }
    }
}