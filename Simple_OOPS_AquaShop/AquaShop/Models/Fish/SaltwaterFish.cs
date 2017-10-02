namespace AquaShop.Models.Fish
{
    /// <summary>
    /// Represents a specific type of Fish: SaltwaterFish.
    /// 
    /// This class inherits from the abstract Fish base class and defines
    /// behavior specific to saltwater environments.
    /// 
    /// Responsibilities:
    /// - Sets initial size for saltwater fish
    /// - Defines growth behavior when the fish eats
    /// 
    /// This demonstrates polymorphism, where different fish types
    /// implement their own version of the Eat() behavior.
    /// </summary>
    public class SaltwaterFish : Fish
    {
        // Default starting size for saltwater fish.
        // Saltwater fish begin slightly larger than freshwater fish.
        private const int InitialSize = 5;

        /// <summary>
        /// Initializes a new SaltwaterFish instance with base properties.
        /// Sets the initial size specific to saltwater fish.
        /// </summary>
        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            this.Size = InitialSize;
        }

        /// <summary>
        /// Defines how saltwater fish grow when fed.
        /// Each time it eats, its size increases by 2 units.
        /// </summary>
        public override void Eat()
        {
            this.Size += 2;
        }
    }
}