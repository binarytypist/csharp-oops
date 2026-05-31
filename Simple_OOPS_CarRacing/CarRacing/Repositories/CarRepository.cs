using System;
using System.Collections.Generic;
using System.Linq;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Repositories
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * CarRepository is a DATA STORAGE class responsible for managing ICar objects.
     *
     * OOP CONCEPTS USED:
     * 1. Encapsulation:
     *    - Internal list is private
     *    - External access is read-only
     *
     * 2. Abstraction:
     *    - Implements IRepository<ICar> contract
     *
     * 3. Polymorphism:
     *    - Works with ICar interface instead of concrete car types
     *
     * 4. Separation of concerns:
     *    - Only responsible for storing and retrieving cars
     *    - Does NOT contain business logic (like racing or validation rules)
     */

    public class CarRepository : IRepository<ICar>
    {
        /*
         * INTERNAL STORAGE:
         * -----------------
         * Private list ensures data cannot be modified directly from outside
         */
        private readonly List<ICar> cars = new List<ICar>();

        /*
         * READ-ONLY EXPOSURE:
         * -------------------
         * Exposes cars safely without allowing modification
         */
        public IReadOnlyCollection<ICar> Models => cars.AsReadOnly();

        /*
         * ADD OPERATION:
         * --------------
         * Adds a car to repository after validation
         */
        public void Add(ICar model)
        {
            // Defensive programming: ensure object is valid
            if (model is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            cars.Add(model);
        }

        /*
         * REMOVE OPERATION:
         * -----------------
         * Removes a car from repository
         */
        public bool Remove(ICar model)
        {
            return cars.Remove(model);
        }

        /*
         * FIND OPERATION:
         * --------------
         * Searches car by VIN (unique identifier)
         *
         * NOTE:
         * VIN is used because it uniquely identifies a car
         */
        public ICar FindBy(string property)
        {
            return cars.FirstOrDefault(x => x.VIN == property);
        }
    }
}