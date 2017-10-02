namespace AquaShop.Models.Aquariums.Contracts
{
    using System.Collections.Generic;

    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;

    /// <summary>
    /// Defines the contract for an Aquarium entity.
    /// An aquarium is a container that holds fish and decorations,
    /// manages capacity, and provides behavior for feeding and reporting state.
    /// </summary>
    public interface IAquarium
    {
        /// <summary>
        /// Gets the unique name of the aquarium.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the maximum number of fish the aquarium can hold.
        /// </summary>
        int Capacity { get; }

        /// <summary>
        /// Gets the comfort value provided by decorations inside the aquarium.
        /// </summary>
        int Comfort { get; }

        /// <summary>
        /// Collection of decorations currently placed in the aquarium.
        /// </summary>
        ICollection<IDecoration> Decorations { get; }

        /// <summary>
        /// Collection of fish currently living in the aquarium.
        /// </summary>
        ICollection<IFish> Fish { get; }

        /// <summary>
        /// Adds a fish to the aquarium if capacity allows and water type is compatible.
        /// </summary>
        /// <param name="fish">The fish to add.</param>
        void AddFish(IFish fish);

        /// <summary>
        /// Removes a fish from the aquarium.
        /// </summary>
        /// <param name="fish">The fish to remove.</param>
        /// <returns>True if the fish was successfully removed; otherwise false.</returns>
        bool RemoveFish(IFish fish);

        /// <summary>
        /// Adds a decoration to the aquarium, increasing its comfort.
        /// </summary>
        /// <param name="decoration">The decoration to add.</param>
        void AddDecoration(IDecoration decoration);

        /// <summary>
        /// Feeds all fish in the aquarium.
        /// </summary>
        void Feed();

        /// <summary>
        /// Returns a formatted string with full aquarium information.
        /// </summary>
        /// <returns>A string describing the aquarium state.</returns>
        string GetInfo();
    }
}