namespace Aquariums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents an aquarium that stores fish.
    /// </summary>
    public class Aquarium
    {
        private string name;
        private int capacity;
        private List<Fish> fish;

        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            // Internal collection of fish
            this.fish = new List<Fish>();
        }

        /// <summary>
        /// Aquarium name.
        /// Cannot be null or empty.
        /// </summary>
        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(
                        nameof(value),
                        "Invalid aquarium name!");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Maximum number of fish the aquarium can hold.
        /// </summary>
        public int Capacity
        {
            get => this.capacity;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "Invalid aquarium capacity!");
                }

                this.capacity = value;
            }
        }

        /// <summary>
        /// Current number of fish in the aquarium.
        /// </summary>
        public int Count => this.fish.Count;

        /// <summary>
        /// Adds a fish to the aquarium.
        /// Throws exception if aquarium is full.
        /// </summary>
        public void Add(Fish fish)
        {
            if (this.fish.Count == this.capacity)
            {
                throw new InvalidOperationException(
                    "Aquarium is full!");
            }

            this.fish.Add(fish);
        }

        /// <summary>
        /// Removes a fish by name.
        /// Throws exception if fish does not exist.
        /// </summary>
        public void RemoveFish(string name)
        {
            Fish fishToRemove =
                this.fish.FirstOrDefault(f => f.Name == name);

            if (fishToRemove == null)
            {
                throw new InvalidOperationException(
                    $"Fish with the name {name} doesn't exist!");
            }

            this.fish.Remove(fishToRemove);
        }

        /// <summary>
        /// Sells a fish.
        /// Sold fish become unavailable.
        /// Returns the sold fish.
        /// </summary>
        public Fish SellFish(string name)
        {
            Fish requestedFish =
                this.fish.FirstOrDefault(f => f.Name == name);

            if (requestedFish == null)
            {
                throw new InvalidOperationException(
                    $"Fish with the name {name} doesn't exist!");
            }

            requestedFish.Available = false;

            return requestedFish;
        }

        /// <summary>
        /// Creates a report containing all fish names.
        /// </summary>
        public string Report()
        {
            string fishNames =
                string.Join(", ", this.fish.Select(f => f.Name));

            return $"Fish available at {this.Name}: {fishNames}";
        }
    }
}