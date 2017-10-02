namespace AquaShop.Models.Aquariums
{
    /// <summary>
    /// Represents a specific type of Aquarium: FreshwaterAquarium.
    /// 
    /// This class inherits from the abstract Aquarium base class and
    /// defines a fixed capacity suitable for freshwater fish environments.
    /// 
    /// It does not introduce new behavior, but specializes Aquarium by:
    /// - Setting a predefined capacity (50)
    /// - Enforcing freshwater-specific domain classification
    /// 
    /// This follows the OOP principle of inheritance (is-a relationship),
    /// where FreshwaterAquarium "is a" Aquarium with predefined configuration.
    /// </summary>
    public class FreshwaterAquarium : Aquarium
    {
        // Defines the maximum number of fish this aquarium can hold.
        // This value is fixed for all freshwater aquariums in the system.
        private const int InitialCapacity = 50;

        /// <summary>
        /// Initializes a new instance of FreshwaterAquarium.
        /// Passes the predefined capacity to the base Aquarium class.
        /// </summary>
        /// <param name="name">The unique name of the aquarium.</param>
        public FreshwaterAquarium(string name)
            : base(name, InitialCapacity)
        {
        }
    }
}