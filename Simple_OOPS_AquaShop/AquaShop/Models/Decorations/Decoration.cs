namespace AquaShop.Models.Decorations
{
    using AquaShop.Models.Decorations.Contracts;

    /// <summary>
    /// Abstract base class representing a Decoration in the AquaShop domain.
    /// 
    /// This class defines shared properties and behavior for all decoration types
    /// (e.g., Ornament, Plant).
    /// 
    /// Decorations are non-living objects that:
    /// - Increase aquarium comfort
    /// - Have a fixed price value used in calculations
    /// 
    /// This class follows the OOP principle of abstraction by providing
    /// common structure while allowing specialized decorations to define
    /// their own specific values.
    /// </summary>
    public abstract class Decoration : IDecoration
    {
        /// <summary>
        /// Initializes a new instance of a Decoration.
        /// Sets immutable core properties: Comfort and Price.
        /// </summary>
        /// <param name="comfort">The comfort value provided by the decoration.</param>
        /// <param name="price">The monetary value of the decoration.</param>
        protected Decoration(int comfort, decimal price)
        {
            this.Comfort = comfort;
            this.Price = price;
        }

        /// <summary>
        /// Gets the comfort value contributed by this decoration.
        /// This value affects the overall aquarium comfort score.
        /// </summary>
        public int Comfort { get; }

        /// <summary>
        /// Gets the price of the decoration.
        /// Used when calculating the total aquarium value.
        /// </summary>
        public decimal Price { get; }
    }
}