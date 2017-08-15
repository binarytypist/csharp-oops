namespace Bakery.Utilities.Messages
{
    // The ExceptionMessages class is a static
    // class that contains constant string fields representing error messages used throughout the bakery application.
    // These messages are used in various parts of the application to provide consistent and 
    // informative error messages when exceptions are thrown due to invalid input or other issues.
    public static class ExceptionMessages
    {
        public const string InvalidName = "Name cannot be null or white space!";

        public const string InvalidPortion = "Portion cannot be less or equal to zero";

        public const string InvalidPrice = "Price cannot be less or equal to zero!";

        public const string InvalidBrand = "Brand cannot be null or white space!";

        public const string InvalidTableCapacity = "Capacity has to be greater than 0";

        public const string InvalidNumberOfPeople = "Cannot place zero or less people!";


    }
}
