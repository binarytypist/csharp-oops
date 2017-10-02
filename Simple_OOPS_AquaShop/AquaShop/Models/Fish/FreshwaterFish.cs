namespace AquaShop.Models.Fish
{
    /// <summary>
    /// Represents a specific type of Fish: FreshwaterFish.
    /// 
    /// This class inherits from Fish and defines behavior specific to freshwater environments.
    /// 
    /// Responsibilities:
    /// - Sets initial size of the fish
    /// - Defines how the fish grows when it eats
    /// 
    /// This class demonstrates inheritance and polymorphism,
    /// where the Eat() behavior is customized for freshwater fish.
    /// </summary>
    public class FreshwaterFish : Fish
    {
        // Default starting size for freshwater fish.
        // All freshwater fish begin at this base size.
        private const int InitialSize = 3;

        /// <summary>
        /// Initializes a new FreshwaterFish instance with base properties.
        /// Sets the initial size specific to freshwater fish.
        /// </summary>
        public FreshwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            this.Size = InitialSize;
        }

        /// <summary>
        /// Defines how freshwater fish grow when fed.
        /// Each time it eats, its size increases by 3 units.
        /// </summary>
        public override void Eat()
        {
            this.Size += 3;
        }
    }
}