namespace AquaShop.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Repositories.Contracts;

    /// <summary>
    /// Repository responsible for storing and managing IDecoration objects.
    /// 
    /// Purpose of IDecoration here:
    /// - It is used instead of concrete classes (Ornament, Plant)
    /// - This allows the repository to store ANY type of decoration uniformly
    /// - It enables polymorphism and loose coupling (OOP principle)
    /// - The repository does NOT care about implementation details, only behavior contract
    /// 
    /// This follows the Repository Pattern and Dependency Inversion Principle.
    /// </summary>
    public class DecorationRepository : IRepository<IDecoration>
    {
        // Internal storage of all decorations in memory
        private readonly List<IDecoration> decorations = new List<IDecoration>();

        /// <summary>
        /// Provides a read-only view of stored decorations.
        /// Prevents external modification of internal collection.
        /// </summary>
        public IReadOnlyCollection<IDecoration> Models => decorations.AsReadOnly();

        /// <summary>
        /// Adds a decoration to the repository.
        /// The repository stores only the abstraction (IDecoration),
        /// not concrete implementations like Ornament or Plant.
        /// </summary>
        public void Add(IDecoration model)
        {
            this.decorations.Add(model);
        }

        /// <summary>
        /// Removes a decoration from the repository if it exists.
        /// </summary>
        public bool Remove(IDecoration model)
        {
            return this.decorations.Remove(model);
        }

        /// <summary>
        /// Finds a decoration by its concrete type name (e.g., "Ornament", "Plant").
        /// This is used when selecting specific decoration implementations.
        /// </summary>
        public IDecoration FindByType(string type)
        {
            return this.decorations.FirstOrDefault(x => x.GetType().Name == type);
        }
    }
}