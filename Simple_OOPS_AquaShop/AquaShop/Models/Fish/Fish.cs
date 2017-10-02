namespace AquaShop.Models.Fish
{
    using System;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Utilities.Messages;

    /// <summary>
    /// Abstract base class representing a Fish in the AquaShop domain.
    /// 
    /// This class provides shared state and validation logic for all fish types
    /// (e.g., FreshwaterFish, SaltwaterFish).
    /// 
    /// Responsibilities:
    /// - Ensures valid fish identity (Name, Species)
    /// - Maintains core properties (Size, Price)
    /// - Defines common contract for behavior (Eat)
    /// 
    /// This class uses abstraction to enforce consistent structure across all fish types
    /// while allowing specialization through inheritance.
    /// </summary>
    public abstract class Fish : IFish
    {
        private string name;
        private string species;
        private decimal price;

        protected Fish(string name, string species, decimal price)
        {
            // Initialize fish with validated core properties
            this.Name = name;
            this.Species = species;
            this.Price = price;
        }

        /// <summary>
        /// Gets the unique name of the fish.
        /// Must be a non-empty string.
        /// </summary>
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishName);
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets the species type of the fish.
        /// Represents biological classification.
        /// </summary>
        public string Species
        {
            get => this.species;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishSpecies);
                }

                this.species = value;
            }
        }

        /// <summary>
        /// Gets the current size of the fish.
        /// Size increases when the fish eats (defined in derived classes).
        /// </summary>
        public int Size { get; protected set; }

        /// <summary>
        /// Gets the price of the fish.
        /// Must be greater than zero.
        /// </summary>
        public decimal Price
        {
            get => this.price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishPrice);
                }

                this.price = value;
            }
        }

        /// <summary>
        /// Defines the eating behavior of a fish.
        /// Each fish type implements its own growth logic.
        /// </summary>
        public abstract void Eat();
    }
}