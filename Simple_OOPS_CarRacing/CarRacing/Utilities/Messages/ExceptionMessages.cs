namespace CarRacing.Utilities.Messages
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * ExceptionMessages is a centralized CONSTANT HOLDER class.
     *
     * OOP CONCEPTS USED:
     * 1. Encapsulation:
     *    - All error messages are hidden inside one class
     *    - Prevents duplication across the project
     *
     * 2. Single Responsibility Principle:
     *    - Only responsible for storing exception strings
     *
     * 3. Maintainability:
     *    - If a message changes, it changes in ONE place only
     *
     * 4. Readability:
     *    - Makes validation logic cleaner in other classes
     */

    public static class ExceptionMessages
    {
        // CAR VALIDATION MESSAGES
        public const string InvalidCarMake = "Car make cannot be null or empty.";
        public const string InvalidCarModel = "Car model cannot be null or empty.";
        public const string InvalidCarVIN = "Car VIN must be exactly 17 characters long.";
        public const string InvalidCarHorsePower = "Horse power cannot be below 0.";
        public const string InvalidCarFuelConsumption = "Fuel consumption cannot be below 0.";

        // RACER VALIDATION MESSAGES
        public const string InvalidRacerName = "Username cannot be null or empty.";
        public const string InvalidRacerBehavior = "Racing behavior cannot be null or empty.";
        public const string InvalidRacerDrivingExperience = "Racer driving experience must be between 0 and 100.";
        public const string InvalidRacerCar = "Car cannot be null or empty.";

        // REPOSITORY VALIDATION MESSAGES
        public const string InvalidAddCarRepository = "Cannot add null in Car Repository";
        public const string InvalidAddRacerRepository = "Cannot add null in Racer Repository";

        // FACTORY / TYPE MESSAGES
        public const string InvalidCarType = "Invalid car type!";
        public const string InvalidRacerType = "Invalid racer type!";

        // SEARCH MESSAGES
        public const string CarCannotBeFound = "Car cannot be found!";
        public const string RacerCannotBeFound = "Racer {0} cannot be found!";
    }
}