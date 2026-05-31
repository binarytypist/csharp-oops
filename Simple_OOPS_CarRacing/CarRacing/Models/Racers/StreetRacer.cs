using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * StreetRacer is a CONCRETE implementation of Racer.
     *
     * It represents a beginner-style racer with:
     * - Lower starting experience
     * - Aggressive racing behavior
     * - Small experience gain per race
     *
     * OOP CONCEPTS USED:
     * 1. Inheritance:
     *    - Inherits common racer logic from Racer base class
     *
     * 2. Polymorphism:
     *    - Overrides Race() method to customize behavior
     *
     * 3. Encapsulation:
     *    - Uses constants to hide configuration details
     *
     * 4. Specialization:
     *    - Defines unique progression rules for street racers
     */

    public class StreetRacer : Racer
    {
        /*
         * CLASS CONFIGURATION:
         * --------------------
         * Default values defining StreetRacer characteristics
         */
        private const string InitialRacingBehavior = "aggressive";
        private const int InitialDrivingExperience = 10;

        /*
         * CONSTRUCTOR:
         * ------------
         * Passes predefined StreetRacer configuration to base class
         */
        public StreetRacer(string username, ICar car)
            : base(username, InitialRacingBehavior, InitialDrivingExperience, car)
        {
        }

        /*
         * OVERRIDE METHOD (POLYMORPHISM):
         * -------------------------------
         * Extends base Race behavior:
         * - Executes base racing logic (car drives)
         * - Adds smaller experience increase than ProfessionalRacer
         */
        public override void Race()
        {
            // Execute base race logic (fuel consumption etc.)
            base.Race();

            // Gain experience after race (slower progression)
            this.DrivingExperience += 5;
        }
    }
}