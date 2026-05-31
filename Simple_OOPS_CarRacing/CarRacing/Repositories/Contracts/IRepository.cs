namespace CarRacing.Repositories.Contracts
{
    using System.Collections.Generic;

    /*
     * PURPOSE OF THIS INTERFACE:
     * --------------------------
     * IRepository defines a GENERIC CONTRACT for storing and managing collections of objects.
     *
     * OOP CONCEPTS USED:
     * 1. Abstraction:
     *    - Defines WHAT a repository should do
     *    - Does NOT define HOW data is stored (memory, DB, etc.)
     *
     * 2. Generics:
     *    - Allows repository to work with any type (T)
     *
     * 3. Polymorphism:
     *    - Different implementations can behave differently (List-based, DB-based, etc.)
     *
     * 4. Encapsulation:
     *    - Collection is exposed as read-only to protect internal data
     */

    public interface IRepository<T>
    {
        /*
         * READ-ONLY COLLECTION:
         * ---------------------
         * Exposes stored models safely without allowing external modification
         */
        IReadOnlyCollection<T> Models { get; }

        /*
         * ADD OPERATION:
         * --------------
         * Adds a new item to the repository
         */
        void Add(T model);

        /*
         * REMOVE OPERATION:
         * -----------------
         * Removes an item from the repository
         * Returns true if removal is successful
         */
        bool Remove(T model);

        /*
         * SEARCH OPERATION:
         * -----------------
         * Finds an item by a given property (implementation-defined)
         */
        T FindBy(string property);
    }
}