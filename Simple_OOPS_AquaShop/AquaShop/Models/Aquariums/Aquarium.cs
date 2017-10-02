namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Utilities.Messages;

    /// <summary>
    /// Abstract base class representing a generic Aquarium in the system.
    /// 
    /// This class defines the shared state and behavior for all aquarium types
    /// (e.g., FreshwaterAquarium, SaltwaterAquarium).
    /// 
    /// Responsibilities:
    /// - Stores fish and decorations
    /// - Enforces capacity rules
    /// - Calculates comfort based on decorations
    /// - Provides basic operations like AddFish, RemoveFish, Feed, and GetInfo
    /// 
    /// This follows the OOP principle of inheritance by allowing specialized aquariums
    /// to extend and reuse common functionality.
    /// </summary>
    public abstract class Aquarium : IAquarium
    {
        // Stores the aquarium's name (validated to ensure it is not null or empty)
        private string name;

        // Internal collection of decorations inside the aquarium
        private readonly List<IDecoration> decorations;

        // Internal collection of fish currently living in the aquarium
        private readonly List<IFish> fishes;

        protected Aquarium(string name, int capacity)
        {
            // Initialize aquarium identity and rules
            this.Name = name;
            this.Capacity = capacity;

            // Initialize internal collections
            this.decorations = new List<IDecoration>();
            this.fishes = new List<IFish>();
        }

        // Aquarium name with validation to ensure valid domain object state
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        // Maximum number of fish allowed in this aquarium
        public int Capacity { get; }

        // Comfort is dynamically calculated from all decorations inside the aquarium
        public int Comfort => this.decorations.Sum(d => d.Comfort);

        // Exposes decorations collection for external read/write operations
        // (could be improved later to read-only collection for stricter encapsulation)
        public ICollection<IDecoration> Decorations => this.decorations;

        // Exposes fish collection for external interaction
        public ICollection<IFish> Fish => this.fishes;

        /// <summary>
        /// Adds a fish to the aquarium if capacity allows.
        /// Ensures domain rule: aquarium cannot exceed its fish capacity.
        /// </summary>
        public void AddFish(IFish fish)
        {
            if (fish == null)
            {
                throw new ArgumentNullException(nameof(fish));
            }

            // Enforce capacity constraint (business rule)
            if (this.fishes.Count >= this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.fishes.Add(fish);
        }

        /// <summary>
        /// Removes a fish from the aquarium if it exists.
        /// </summary>
        public bool RemoveFish(IFish fish)
        {
            return this.fishes.Remove(fish);
        }

        /// <summary>
        /// Adds a decoration to the aquarium.
        /// Decorations increase comfort and improve aquarium environment.
        /// </summary>
        public void AddDecoration(IDecoration decoration)
        {
            if (decoration == null)
            {
                throw new ArgumentNullException(nameof(decoration));
            }

            this.decorations.Add(decoration);
        }

        /// <summary>
        /// Feeds all fish in the aquarium.
        /// This triggers each fish's Eat behavior (polymorphism).
        /// </summary>
        public void Feed()
        {
            foreach (var fish in this.fishes)
            {
                fish.Eat();
            }
        }

        /// <summary>
        /// Builds a formatted string containing full aquarium state information.
        /// Used for reporting and system output.
        /// </summary>
        public string GetInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");

            sb.AppendLine("Fish: " + (this.fishes.Any()
                ? string.Join(", ", this.fishes.Select(f => f.Name))
                : "none"));

            sb.AppendLine($"Decorations: {this.decorations.Count}");

            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }
    }
}