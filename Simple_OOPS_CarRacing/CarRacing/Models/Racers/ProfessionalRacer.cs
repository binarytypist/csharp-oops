using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * ProfessionalRacer is a concrete implementation of Racer.
     *
     * It represents an experienced racer with:
     * - High initial skill
     * - Strict racing behavior
     * - Skill growth after each race
     *
     * OOP CONCEPTS USED:
     * 1. Inheritance:
     *    - Inherits from base class Racer
     *
     * 2. Polymorphism:
     *    - Overrides Race() method to extend behavior
     *
     * 3. Encapsulation:
     *    - Constants define fixed configuration for this racer type
     *
     * 4. Behavior specialization:
     *    - Adds experience gain after racing
     */

    public class ProfessionalRacer : Racer
    {
        /*
         * CLASS CONFIGURATION:
         * --------------------
         * Defines default characteristics for a Professional Racer
         */
        private const string InitialRacingBehavior = "strict";
        private const int InitialDrivingExperience = 30;

        /*
         * CONSTRUCTOR:
         * ------------
         * Passes predefined professional settings to base Racer class
         *
         * This ensures all ProfessionalRacers start with same rules
         */
        public ProfessionalRacer(string username, ICar car)
            : base(username, InitialRacingBehavior, InitialDrivingExperience, car)
        {
        }

        /*
         * OVERRIDE METHOD (POLYMORPHISM):
         * -------------------------------
         * Enhances base Race behavior:
         * - Executes base racing logic
         * - Increases driving experience after each race
         *
         * This models skill improvement over time
         */
        public override void Race()
        {
            // Execute base race logic
            base.Race();

            // Gain experience after participating in race
            this.DrivingExperience += 10;
        }
    }
}