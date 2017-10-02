namespace AquaShop.Utilities.Messages
{
    /// <summary>
    /// Centralized container for all output messages in the AquaShop system.
    /// 
    /// Purpose:
    /// - Ensures consistent user-facing messages across the application
    /// - Avoids duplicated string literals in business logic
    /// - Improves maintainability and readability
    /// 
    /// These messages are used for successful operations and system feedback,
    /// typically returned by the Controller layer.
    /// </summary>
    public static class OutputMessages
    {
        /// <summary>Used when an entity (Aquarium, Fish, Decoration) is successfully created.</summary>
        public const string SuccessfullyAdded = "Successfully added {0}.";

        /// <summary>Used when an entity is successfully inserted into an aquarium.</summary>
        public const string EntityAddedToAquarium = "Successfully added {0} to {1}.";

        /// <summary>Used when a fish cannot be placed in a given aquarium due to incompatibility.</summary>
        public const string UnsuitableWater = "Water not suitable.";

        /// <summary>Used when fish feeding operation is performed successfully.</summary>
        public const string FishFed = "Fish fed: {0}";

        /// <summary>
        /// Used when calculating the total value of an aquarium.
        /// {0} = Aquarium name, {1} = total calculated value (formatted to 2 decimals)
        /// </summary>
        public const string AquariumValue = "The value of Aquarium {0} is {1:f2}.";
    }
}