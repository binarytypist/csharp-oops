namespace AquaShop.Models.Decorations
{
    /// <summary>
    /// Represents a concrete Decoration type: Ornament.
    /// 
    /// Ornament is a simple decorative object that can be placed inside an aquarium
    /// to increase its comfort level.
    /// 
    /// This class inherits from Decoration and defines fixed values for:
    /// - Comfort (how much it improves aquarium environment)
    /// - Price (its cost in the system)
    /// 
    /// It follows OOP principles of inheritance and specialization,
    /// where Ornament is a specific implementation of a general Decoration concept.
    /// </summary>
    public class Ornament : Decoration
    {
        // Defines the comfort value provided by an Ornament.
        // This represents how much it improves the aquarium environment.
        private const int InitialComfort = 1;

        // Defines the fixed price of an Ornament.
        // Used when calculating total aquarium value.
        private const decimal InitialPrice = 5;

        /// <summary>
        /// Initializes a new instance of Ornament with predefined values.
        /// These values are passed to the base Decoration class.
        /// </summary>
        public Ornament()
            : base(InitialComfort, InitialPrice)
        {
        }
    }
}