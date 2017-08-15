namespace Bakery.Models.Tables.Contracts
{
    using Bakery.Models.BakedFoods.Contracts;
    using Bakery.Models.Drinks.Contracts;


    //  / <summary>
    //  Contract that defines what every Table must have.
    //  Any class that implements ITable must provide these properties and methods.
    //  /  </summary>
    public interface ITable
    {
        int TableNumber { get; }

        int Capacity { get; }

        int NumberOfPeople { get; }

        decimal PricePerPerson { get; }

        bool IsReserved { get; }

        decimal Price { get; }

        void Reserve(int numberOfPeople);


        //  The OrderFood method takes an IBakedFood object as a parameter and adds it to the table's order.
        //  This method allows customers to order food items
        //  from the bakery menu and have them associated with their table.
        void OrderFood(IBakedFood food);


        // The OrderDrink method takes an IDrink object as a parameter and adds it to the table's order.
        // This method allows customers to order drink items
        // from the bakery menu and have them associated with their table.
        void OrderDrink(IDrink drink);


        //  The GetBill method calculates and returns the total bill for the table,
        //  which includes the cost of all ordered food and drink items as well as the price for the number of people at the table.
        decimal GetBill();


        // The Clear method resets the state of the table, making it available for new customers.
        // This method clears the list of ordered food and drink items, resets the number of people to zero, and marks the table as not reserved.
        void Clear();

        // The GetFreeTableInfo method returns a string containing information about the table if it is not reserved.
        // This method is used to provide details about available tables to customers, such as the table number, capacity, and price per person.

        string GetFreeTableInfo();
    }
}
