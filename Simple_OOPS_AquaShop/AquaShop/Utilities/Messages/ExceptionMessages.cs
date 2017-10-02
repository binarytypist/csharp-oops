namespace AquaShop.Utilities.Messages
{
    /// <summary>
    /// Centralized container for all exception messages used in the AquaShop system.
    /// 
    /// Purpose:
    /// - Provides consistent error messages across the application
    /// - Avoids magic strings scattered throughout the codebase
    /// - Improves maintainability and readability
    /// 
    /// This class follows the principle of centralization of constants,
    /// ensuring that all validation messages are managed in a single location.
    /// </summary>
    public static class ExceptionMessages
    {
        /// <summary>Thrown when fish name is null or empty.</summary>
        public const string InvalidFishName = "Fish name cannot be null or empty.";

        /// <summary>Thrown when fish species is null or empty.</summary>
        public const string InvalidFishSpecies = "Fish species cannot be null or empty.";

        /// <summary>Thrown when fish price is less than or equal to zero.</summary>
        public const string InvalidFishPrice = "Fish price cannot be below or equal to 0.";

        /// <summary>Thrown when aquarium name is null or empty.</summary>
        public const string InvalidAquariumName = "Aquarium name cannot be null or empty.";

        /// <summary>Thrown when aquarium capacity is exceeded.</summary>
        public const string NotEnoughCapacity = "Not enough capacity.";

        /// <summary>Thrown when an invalid aquarium type is provided.</summary>
        public const string InvalidAquariumType = "Invalid aquarium type.";

        /// <summary>Thrown when an invalid decoration type is provided.</summary>
        public const string InvalidDecorationType = "Invalid decoration type.";

        /// <summary>
        /// Thrown when a requested decoration type does not exist in repository.
        /// {0} is replaced with the decoration type name.
        /// </summary>
        public const string InexistentDecoration = "There isn’t a decoration of type {0}.";

        /// <summary>Thrown when an invalid fish type is provided.</summary>
        public const string InvalidFishType = "Invalid fish type.";
    }
}