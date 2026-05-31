// ReSharper disable InconsistentNaming
namespace CarRacing.Models.Cars.Contracts
{
    /*
     * PURPOSE OF THIS INTERFACE:
     * --------------------------
     * ICar defines a CONTRACT for all car types in the system.
     *
     * OOP CONCEPTS:
     * 1. Abstraction:
     *    - Hides implementation details
     *    - Only exposes WHAT a Car can do, not HOW it does it
     *
     * 2. Polymorphism:
     *    - Different car types can implement ICar differently
     *    - Engine can work with any ICar without knowing the concrete class
     *
     * 3. Loose Coupling:
     *    - System depends on interface, not concrete classes
     *    - Makes code flexible and extensible
     */
    public interface ICar
    {
        // BASIC IDENTIFICATION PROPERTIES
        string Make { get; }     // Manufacturer (e.g., BMW, Ferrari)
        string Model { get; }    // Model name (e.g., M3, F8)
        string VIN { get; }      // Unique Vehicle Identification Number

        // PERFORMANCE PROPERTY
        int HorsePower { get; }  // Engine strength of the car

        // FUEL SYSTEM
        double FuelAvailable { get; }          // Current fuel in tank
        double FuelConsumptionPerRace { get; } // Fuel used per race

        /*
         * BEHAVIOR (ACTION METHOD):
         * -------------------------
         * Drive() defines what happens when a car participates in a race.
         *
         * Implementation is left to concrete classes because:
         * - Different cars may consume fuel differently
         * - Different cars may have different racing behavior
         */
        void Drive();
    }
}