using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

public class Map : IMap
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * Map is the CORE BUSINESS LOGIC of the racing system.
     *
     * It controls:
     * - Whether a race can happen
     * - How racers are evaluated
     * - How winner is determined
     *
     * OOP CONCEPTS USED:
     * 1. Abstraction:
     *    - Implements IMap interface
     *
     * 2. Encapsulation:
     *    - Internal logic is hidden inside private methods
     *
     * 3. Polymorphism:
     *    - Works with IRacer interface, not concrete racer classes
     *
     * 4. Separation of concerns:
     *    - Map handles race logic only
     *    - Does NOT manage cars, racers, or engine directly
     */

    public string StartRace(IRacer racerOne, IRacer racerTwo)
    {
        // ===============================
        // VALIDATION: CHECK RACER AVAILABILITY
        // ===============================
        if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
        {
            return OutputMessages.RaceCannotBeCompleted;
        }

        if (!racerOne.IsAvailable())
        {
            return string.Format(
                OutputMessages.OneRacerIsNotAvailable,
                racerTwo.Username,
                racerOne.Username);
        }

        if (!racerTwo.IsAvailable())
        {
            return string.Format(
                OutputMessages.OneRacerIsNotAvailable,
                racerOne.Username,
                racerTwo.Username);
        }

        // ===============================
        // RACE EXECUTION (STATE CHANGE)
        // ===============================
        racerOne.Race();
        racerTwo.Race();

        // ===============================
        // RACE POWER CALCULATION
        // ===============================
        double racerOneChance = CalculateChance(racerOne);
        double racerTwoChance = CalculateChance(racerTwo);

        // ===============================
        // WINNER DECISION LOGIC
        // ===============================
        string winner = racerOneChance > racerTwoChance
            ? racerOne.Username
            : racerTwo.Username;

        return string.Format(
            OutputMessages.RacerWinsRace,
            racerOne.Username,
            racerTwo.Username,
            winner);
    }

    /*
     * HELPER METHOD (ENCAPSULATED LOGIC):
     * -----------------------------------
     * Calculates race performance score based on:
     * - Car HorsePower
     * - Driver experience
     * - Racing behavior multiplier
     *
     * This keeps StartRace method clean and readable.
     */
    private double CalculateChance(IRacer racer)
    {
        double multiplier =
            racer.RacingBehavior == "strict" ? 1.2 :
            racer.RacingBehavior == "aggressive" ? 1.1 : 1.0;

        return racer.Car.HorsePower * racer.DrivingExperience * multiplier;
    }
}