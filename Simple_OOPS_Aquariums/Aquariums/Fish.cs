namespace Aquariums
{
    /// <summary>
    /// Represents a fish in the aquarium.
    /// </summary>
    public class Fish
    {
        public Fish(string name)
        {
            // Fish name
            this.Name = name;

            // New fish are available by default
            this.Available = true;
        }

        /// <summary>
        /// Name of the fish.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicates whether the fish is available.
        /// False when sold.
        /// </summary>
        public bool Available { get; set; }
    }
}