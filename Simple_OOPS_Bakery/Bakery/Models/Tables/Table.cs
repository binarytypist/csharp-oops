using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Models.Tables
{

    // The Table class is an abstract base class for all types of tables in the bakery. It implements the ITable interface,
    // which defines the properties and methods that all tables must have.
    public abstract class Table : ITable
    {
        // The Table class has several properties, including TableNumber, Capacity, NumberOfPeople, PricePerPerson, IsReserved, and Price.
        // The Table class also has two private fields, foodOrders and drinkOrders, which are lists that store the food and
        // drink orders associated with the table.
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;

        // The constructor of the Table class initializes the properties of the table.
        // The constructor takes three parameters: tableNumber, capacity, and pricePerPerson, which are used to set the corresponding properties.
        // The constructor also initializes the foodOrders and drinkOrders lists to be empty, allowing the table to start with no orders.
        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {

            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            // The foodOrders and drinkOrders lists are initialized as empty lists, allowing the table to start with no orders.
            // This ensures that when a new table is created, it does not have any pre-existing food or drink orders, and customers
            // can start placing their orders from scratch.
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
        }

        // The TableNumber property represents the unique identifier for the table. It is set in the constructor and cannot be changed afterwards.
        // The Capacity property represents the maximum number of people that can be seated at the table. It includes validation to ensure that the
        // capacity is not negative.
        public int TableNumber { get; private set; }

        // The NumberOfPeople property represents the current number of people seated at the table.
        // It includes validation to ensure that the number of people is greater than zero.
        // The PricePerPerson property represents the price per person for the table, which is set in the constructor
        // and cannot be changed afterwards.
        public int Capacity
        {
            // The Capacity property includes validation to ensure that the capacity is not negative.

            // the getter for the Capacity property simply returns the value of the private field capacity,
            // which stores the actual capacity value for the table.
            get => this.capacity;


            // the setter for the Capacity property includes validation logic to ensure that the capacity value is not negative.
            private set
            {
                if (value < 0)
                {
                    // If an invalid capacity is provided (i.e., a negative number), the setter throws an ArgumentException with a message from the ExceptionMessages class.
                    // an ArgumentException is thrown with a message from the ExceptionMessages class, indicating
                    // that the provided capacity is invalid according to the business rules of the bakery.
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                // If the provided capacity value is valid (i.e., zero or positive), the setter assigns the value to the private field capacity,
                // allowing the table to have a valid capacity for seating customers.
                this.capacity = value;
            }
        }

        // The NumberOfPeople property includes validation to ensure that the number of people is greater than zero.

        public int NumberOfPeople
        {

            //  The getter for the NumberOfPeople property simply returns the value of the private field numberOfPeople,
            get => this.numberOfPeople;

            // The setter for the NumberOfPeople property includes validation logic to ensure that the number of people is greater than zero.   
            private set
            {
                if (value <= 0)
                {
                    // If an invalid number of people is provided (i.e., zero or negative), the setter throws an ArgumentException with a message
                    // from the ExceptionMessages class.
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                // If the provided number of people is valid (i.e., greater than zero), the setter assigns the value to the
                // private field numberOfPeople,
                this.numberOfPeople = value;
            }
        }
        // The PricePerPerson property represents the price per person for the table, which is set in the constructor and cannot be changed afterwards.
        public decimal PricePerPerson { get; private set; }

        // The IsReserved property indicates whether the table is currently reserved or not. It is set to true when the Reserve method is called
        // and reset to false when the Clear method is called.
        public bool IsReserved { get; private set; }
        // The Price property calculates the total price for the table based on the number of 
        // people and the price per person. It multiplies the NumberOfPeople property by the PricePerPerson 
        // property to get the total price for the table, which is used when calculating the bill for the customers seated at the table.
        public decimal Price => this.NumberOfPeople * this.PricePerPerson;
        // The FoodOrders and DrinkOrders properties provide read-only access to the lists of food and drink orders associated with the table.
        // These properties return the foodOrders and drinkOrders lists as read-only collections, allowing external code to view the orders
        // without being able to modify them directly.
        public IReadOnlyCollection<IBakedFood> FoodOrders => this.foodOrders.AsReadOnly();
        //  The FoodOrders and DrinkOrders properties provide read-only access to the lists of food and drink orders associated with the table.
        // These properties return the foodOrders and drinkOrders lists as read-only collections, allowing external code to view the orders
        // without being able to modify them directly.
        public IReadOnlyCollection<IDrink> DrinkOrders => this.drinkOrders.AsReadOnly();

        // The Reserve method is used to reserve the table for a specific number of people. It sets the IsReserved property to true and assigns the provided number
        // of people to the NumberOfPeople property.
        public void Reserve(int numberOfPeople)
        {
            // The Reserve method is used to reserve the table for a specific number of people.
            // It sets the IsReserved property to true and assigns the provided number
            IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }

        // The OrderFood method takes an IBakedFood object as a parameter and adds it to the table's order.
        // This method allows customers to order food items
        public void OrderFood(IBakedFood food)
        {
            // The OrderFood method takes an IBakedFood object as a parameter and adds it to the table's order.
            foodOrders.Add(food);
        }

        // The OrderDrink method takes an IDrink object as a parameter and adds it to the table's order.
        // This method allows customers to order drink items
        // from the bakery menu and have them associated with their table.
        public void OrderDrink(IDrink drink)
        {

            // The OrderDrink method takes an IDrink object as a parameter and adds it to the table's order.
            // This method allows customers to order drink items from the bakery menu and have them associated with their table.
            // 
            drinkOrders.Add(drink);
        }

        // The GetBill method calculates and returns the total bill for the table, which includes the cost of all ordered food and
        // drink items as well as the price for the number of people at the table.
        public decimal GetBill()
        {
            // The GetBill method calculates and returns the total bill for the table, which includes the cost of all ordered food and
            // drink items as well as the price for the number of people at the table.
            var drinks = drinkOrders.Sum(x => x.Price);
            var food = foodOrders.Sum(x => x.Price);

            return drinks + food;
        }


        // The Clear method resets the state of the table, making it available for new customers.
        // This method clears the list of ordered food and drink items,

        public void Clear()
        {
            drinkOrders.Clear();
            foodOrders.Clear();
            IsReserved = false;
            this.numberOfPeople = 0;
        }

        // The GetFreeTableInfo method returns a string containing information about the table if it is not reserved.
        // This method is used to provide details about available tables to customers, such as the table number, capacity, and price per person.
        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().TrimEnd();
        }
    }
}