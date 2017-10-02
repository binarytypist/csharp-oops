namespace AquaShop.Models.Decorations
{
    /// <summary>
    /// Represents a concrete Decoration type: Plant.
    /// 
    /// Plant is a more valuable and effective decoration compared to simpler decorations like Ornament.
    /// It improves the aquarium environment by providing higher comfort.
    /// 
    /// This class inherits from Decoration and defines fixed domain-specific values:
    /// - Higher comfort contribution
    /// - Higher price
    /// 
    /// It demonstrates inheritance and specialization in OOP,
    /// where Plant is a stronger type of Decoration with different properties.
    /// </summary>
    public class Plant : Decoration
    {
        // Defines the comfort value of a Plant.
        // Plants provide higher environmental benefit than ornaments.
        private const int InitialComfort = 5;

        // Defines the price of a Plant.
        // Plants are more expensive due to higher value contribution.
        private const decimal InitialPrice = 10;

        /// <summary>
        /// Initializes a new instance of Plant with predefined values.
        /// These values are passed to the base Decoration class.
        /// </summary>
        public Plant()
            : base(InitialComfort, InitialPrice)
        {
        }
    }
}