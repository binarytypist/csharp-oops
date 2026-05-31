namespace CarRacing.Utilities.Messages
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * OutputMessages is a centralized constant holder for SUCCESS / RESULT messages.
     *
     * OOP CONCEPTS USED:
     * 1. Encapsulation:
     *    - All output strings are stored in one place
     *
     * 2. Single Responsibility Principle:
     *    - Only responsible for application output messages
     *
     * 3. Maintainability:
     *    - Easy to update UI messages without touching business logic
     *
     * 4. Separation of Concerns:
     *    - Keeps engine/controller logic clean from string formatting
     */

    public static class OutputMessages
    {
        // RACE STATUS MESSAGES
        public const string RaceCannotBeCompleted =
            "Race cannot be completed because both racers are not available!";

        public const string OneRacerIsNotAvailable =
            "{0} wins the race! {1} was not available to race!";

        public const string RacerWinsRace =
            "{0} has just raced against {1}! {2} is the winner!";

        // SUCCESS MESSAGES (CAR / RACER CREATION)
        public const string SuccessfullyAddedCar =
            "Successfully added car {0} {1} ({2}).";

        public const string SuccessfullyAddedRacer =
            "Successfully added racer {0}.";
    }
}