namespace CarRacing.Models.Cars
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * SuperCar is a CONCRETE CAR TYPE in the system.
     *
     * OOP CONCEPTS USED:
     * 1. Inheritance:
     *    - Inherits from abstract class Car
     *    - Reuses shared logic (Make, Model, VIN, etc.)
     *
     * 2. Encapsulation:
     *    - Fixed values for fuel are hidden as constants
     *
     * 3. Polymorphism:
     *    - Can be treated as a Car (base type reference)
     *    - Behavior is consistent with Car contract
     */

    public class SuperCar : Car
    {
        /*
         * CONSTANTS (CLASS-SPECIFIC CONFIGURATION):
         * -----------------------------------------
         * These values define SuperCar behavior:
         * - Initial fuel available
         * - Fuel consumption per race
         *
         * Using constants avoids magic numbers in code.
         */
        private const double InitialAvailableFuel = 80;
        private const double ConsumptionPerRace = 10;

        /*
         * CONSTRUCTOR:
         * ------------
         * Passes fixed SuperCar rules to base Car class.
         *
         * This ensures:
         * - All SuperCars behave consistently
         * - Base class handles validation + storage
         */
        public SuperCar(string make, string model, string vin, int horsePower)
            : base(make, model, vin, horsePower, InitialAvailableFuel, ConsumptionPerRace)
        {
        }
    }
}