namespace CarRacing.Models.Racers.Contracts
{
    using Cars.Contracts;

    /*
     * PURPOSE OF THIS INTERFACE:
     * --------------------------
     * IRacer defines the CONTRACT for all Racer types in the system.
     *
     * OOP CONCEPTS USED:
     * 1. Abstraction:
     *    - Defines WHAT a Racer must have and do
     *    - Hides implementation details
     *
     * 2. Polymorphism:
     *    - Different Racer implementations can behave differently
     *
     * 3. Loose Coupling:
     *    - Map and Engine depend on IRacer, not concrete Racer classes
     *    - Makes system flexible and extensible
     */

    public interface IRacer
    {
        /*
         * BASIC IDENTITY:
         * ---------------
         * Unique username for each racer in the system
         */
        string Username { get; }

        /*
         * BEHAVIOR TYPE:
         * --------------
         * Defines racing style (e.g., "strict", "aggressive")
         * Used for performance multiplier logic
         */
        string RacingBehavior { get; }

        /*
         * EXPERIENCE LEVEL:
         * -----------------
         * Represents skill level of racer
         * Higher value = better performance
         */
        int DrivingExperience { get; }

        /*
         * COMPOSITION RELATIONSHIP:
         * -------------------------
         * Each racer HAS-A car
         */
        ICar Car { get; }

        /*
         * ACTION METHOD:
         * -------------
         * Executes race logic (usually affects car or racer state)
         */
        void Race();

        /*
         * AVAILABILITY CHECK:
         * -------------------
         * Returns whether racer can participate in a race
         * (e.g., car exists, fuel available, etc.)
         */
        bool IsAvailable();
    }
}