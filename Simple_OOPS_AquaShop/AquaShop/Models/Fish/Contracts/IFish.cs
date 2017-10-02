namespace AquaShop.Models.Fish.Contracts
{
    using System;

    /// <summary>
    /// Defines the contract for a Fish entity in the AquaShop system.
    /// 
    /// A fish is a living entity that exists inside an aquarium and has:
    /// - Identity (Name, Species)
    /// - State (Size, Price)
    /// - Behavior (Eat)
    /// 
    /// This interface follows OOP abstraction by defining what all fish types must implement,
    /// regardless of their specific type (e.g., FreshwaterFish, SaltwaterFish).
    /// </summary>
    public interface IFish
    {
        /// <summary>
        /// Gets the unique name of the fish.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the species classification of the fish.
        /// </summary>
        string Species { get; }

        /// <summary>
        /// Gets the current size of the fish.
        /// Size typically increases when the fish eats.
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Gets the price value of the fish.
        /// Used when calculating the total value of an aquarium.
        /// </summary>
        decimal Price { get; }

        /// <summary>
        /// Defines the behavior of a fish when it is fed.
        /// Typically increases its size or changes internal state.
        /// </summary>
        void Eat();
    }
}