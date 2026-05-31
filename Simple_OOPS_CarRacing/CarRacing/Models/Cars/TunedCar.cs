using System;

namespace CarRacing.Models.Cars
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * TunedCar is a specialized type of Car with modified behavior.
     *
     * OOP CONCEPTS USED:
     * 1. Inheritance:
     *    - Inherits from Car base class
     *
     * 2. Polymorphism:
     *    - Overrides Drive() method to change behavior
     *    - Same method name, different implementation
     *
     * 3. Encapsulation:
     *    - Internal configuration is hidden via constants
     *
     * 4. Behavior extension:
     *    - Adds performance degradation during racing
     */

    public class TunedCar : Car
    {
        /*
         * CLASS CONFIGURATION:
         * --------------------
         * Defines TunedCar-specific racing characteristics.
         */
        private const double InitialAvailableFuel = 65;
        private const double ConsumptionPerRace = 7.50;

        /*
         * CONSTRUCTOR:
         * ------------
         * Passes TunedCar configuration to base Car class.
         */
        public TunedCar(string make, string model, string vin, int horsePower)
            : base(make, model, vin, horsePower, InitialAvailableFuel, ConsumptionPerRace)
        {
        }

        /*
         * OVERRIDE DRIVE METHOD (POLYMORPHISM):
         * -------------------------------------
         * TunedCar behaves differently from normal Car:
         *
         * 1. HorsePower decreases by 3% after each race
         * 2. Then normal fuel consumption is applied
         *
         * This simulates wear-and-tear in tuned engines.
         */
        public override void Drive()
        {
            // Reduce performance (engine wear simulation)
            this.HorsePower -= (int)Math.Round(this.HorsePower * 0.03);

            // Apply base car driving logic (fuel reduction)
            base.Drive();
        }
    }
}