namespace Bakery.Core.Contracts
{
    // this interface is used to decouple the controller from the start up class, so that we can test the controller without the need of the start up class
    // the controller is the main class that will be used to interact with the start up class, and it will be used to call the methods of the start up class,
    // and it will be used to return the results of the methods of the start up class

    // the controller will be used to add foods, drinks, tables, reserve tables, order food and drinks, leave tables and calculate bills, track total income and show free tables
    public interface IController
    {
        public string AddFood(string type, string name, decimal price);

        public string AddDrink(string type, string name, int portion, string brand);

        public string AddTable(string type, int tableNumber, int capacity);

        public string ReserveTable(int numberOfPeople);

        public string OrderFood(int tableNumber, string foodName);

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand);

        public string LeaveTable(int tableNumber);

        public string GetFreeTablesInfo();

        public string GetTotalIncome();
    }
}
