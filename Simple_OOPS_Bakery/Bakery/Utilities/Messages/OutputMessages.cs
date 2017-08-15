namespace Bakery.Utilities.Messages
{
    // The OutputMessages class contains constant string messages used for output in the bakery system.
    // These messages are used to provide feedback to the user when certain actions are performed, such as adding food or drinks
    // to the menu, reserving tables, placing orders, etc.
    // Each constant string in the OutputMessages class represents a specific message that can be formatted with relevant information (e.g., food name, table number, etc.)
    // when used in the application.
    public static class OutputMessages
    {
        public const string FoodAdded = "Added {0} ({1}) to the menu";

        public const string DrinkAdded = "Added {0} ({1}) to the drink menu";

        public const string TableAdded = "Added table number {0} in the bakery";

        public const string TableReserved = "Table {0} has been reserved for {1} people";

        public const string ReservationNotPossible = "No available table for {0} people";

        public const string WrongTableNumber = "Could not find table {0}";

        public const string NonExistentFood = "No {0} in the menu";

        public const string FoodOrderSuccessful = "Table {0} ordered {1}";

        public const string NonExistentDrink = "There is no {0} {1} available";

        public const string TotalIncome = "Total income: {0:F2}lv";
    }
}
