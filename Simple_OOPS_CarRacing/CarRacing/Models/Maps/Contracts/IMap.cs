namespace CarRacing.Models.Maps.Contracts
{
    using Racers.Contracts;

    /*
     * PURPOSE OF THIS INTERFACE:
     * --------------------------
     * IMap defines the CONTRACT for how races are executed in the system.
     *
     * OOP CONCEPTS USED:
     * 1. Abstraction:
     *    - Hides the race logic implementation details
     *    - Only defines WHAT a map must do, not HOW it does it
     *
     * 2. Polymorphism:
     *    - Different Map implementations can define different race logic
     *
     * 3. Loose Coupling:
     *    - Race logic is separated from Engine/Controller/Racer logic
     *    - System depends on abstraction, not concrete implementation
     */

    public interface IMap
    {
        /*
         * START RACE METHOD:
         * ------------------
         * Takes two racers and executes a race between them.
         *
         * RETURNS:
         * - A string result describing the outcome of the race
         *
         * NOTE:
         * Implementation may vary depending on map rules,
         * racer stats, car performance, etc.
         */
        string StartRace(IRacer racerOne, IRacer racerTwo);
    }
}