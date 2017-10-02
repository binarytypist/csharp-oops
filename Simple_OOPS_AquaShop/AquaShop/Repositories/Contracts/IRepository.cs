namespace AquaShop.Repositories.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Generic repository contract used for managing collections of domain objects.
    /// 
    /// This interface defines a common abstraction for storing, retrieving,
    /// and managing entities in the AquaShop system (e.g., Decorations, Fish).
    /// 
    /// It follows the Repository Pattern, which separates data storage logic
    /// from business logic and provides a clean abstraction over collections.
    /// </summary>
    /// <typeparam name="T">The type of model managed by the repository.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Gets a read-only collection of all stored models.
        /// Prevents external modification of internal repository state.
        /// </summary>
        IReadOnlyCollection<T> Models { get; }

        /// <summary>
        /// Adds a model to the repository.
        /// </summary>
        /// <param name="model">The model to add.</param>
        void Add(T model);

        /// <summary>
        /// Removes a model from the repository.
        /// </summary>
        /// <param name="model">The model to remove.</param>
        /// <returns>True if the model was successfully removed; otherwise false.</returns>
        bool Remove(T model);

        /// <summary>
        /// Finds a model by its type name.
        /// Typically used when retrieving specific implementations (e.g., Ornament, Plant).
        /// </summary>
        /// <param name="type">The type name of the model.</param>
        /// <returns>The matching model if found; otherwise null.</returns>
        T FindByType(string type);
    }
}