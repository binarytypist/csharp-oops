using System;
using System.Collections.Generic;
using System.Linq;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Repositories
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * RacerRepository is responsible for storing and managing IRacer objects.
     *
     * OOP CONCEPTS USED:
     * 1. Encapsulation:
     *    - Internal list is hidden (private)
     *    - External access is read-only (IReadOnlyCollection)
     *
     * 2. Abstraction:
     *    - Implements IRepository<IRacer> contract
     *
     * 3. Polymorphism:
     *    - Works with IRacer interface instead of concrete racer types
     *
     * 4. Separation of Concerns:
     *    - Only handles storage and retrieval
     *    - Does NOT handle race logic or business rules
     */

    public class RacerRepository : IRepository<IRacer>
    {
        /*
         * INTERNAL STORAGE:
         * -----------------
         * Private list ensures controlled access to racer data
         */
        private readonly List<IRacer> racers = new List<IRacer>();

        /*
         * READ-ONLY COLLECTION:
         * ---------------------
         * External code can view racers but cannot modify list directly
         */
        public IReadOnlyCollection<IRacer> Models => racers.AsReadOnly();

        /*
         * ADD METHOD:
         * ----------
         * Adds a racer to repository after validation
         */
        public void Add(IRacer model)
        {
            // Validate input to avoid null references
            if (model is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }

            racers.Add(model);
        }

        /*
         * REMOVE METHOD:
         * -------------
         * Removes racer from repository
         */
        public bool Remove(IRacer model)
        {
            return racers.Remove(model);
        }

        /*
         * FIND METHOD:
         * -----------
         * Finds racer by Username (unique identifier)
         */
        public IRacer FindBy(string property)
        {
            return racers.FirstOrDefault(x => x.Username == property);
        }
    }
}