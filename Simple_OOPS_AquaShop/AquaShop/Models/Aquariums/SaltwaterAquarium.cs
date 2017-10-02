namespace AquaShop.Models.Aquariums
{
    /// <summary>
    /// Represents a specialized Aquarium type: SaltwaterAquarium.
    /// 
    /// This class inherits from the Aquarium base class and defines
    /// behavior specific to saltwater environments by setting a fixed capacity.
    /// 
    /// It does not add new functionality, but serves as a domain-specific
    /// specialization of Aquarium with different constraints than freshwater aquariums.
    /// 
    /// This follows the OOP principle of inheritance and supports polymorphism,
    /// allowing saltwater aquariums to be treated as general aquariums.
    /// </summary>
    public class SaltwaterAquarium : Aquarium
    {
        // Defines the maximum number of fish allowed in a saltwater aquarium.
        // Saltwater environments are more restrictive, hence lower capacity.
        private const int InitialCapacity = 25;

        /// <summary>
        /// Initializes a new instance of SaltwaterAquarium.
        /// Passes the predefined capacity to the base Aquarium class.
        /// </summary>
        /// <param name="name">The unique name of the aquarium.</param>
        public SaltwaterAquarium(string name)
            : base(name, InitialCapacity)
        {
        }
    }
}