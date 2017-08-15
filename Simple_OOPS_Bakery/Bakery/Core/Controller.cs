using System;
using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bakery.Models.BakedFoods;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Core
{
    /// <summary>
    /// Main business logic class.
    /// Responsible for managing:
    /// - Foods
    /// - Drinks
    /// - Tables
    /// - Reservations
    /// - Orders
    /// - Income
    /// </summary>
    public class Controller : IController
    {
        // Stores all foods available in the bakery menu
        private List<IBakedFood> bakedFoods = new List<IBakedFood>();

        // Stores all drinks available in the bakery menu
        private List<IDrink> drinks = new List<IDrink>();

        // Stores all tables in the bakery
        private List<ITable> tables = new List<ITable>();

        // Tracks total bakery income
        private decimal total = 0;

        /// <summary>
        /// Adds a food item to the menu.
        /// Creates either Bread or Cake based on the type.
        /// </summary>
        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = default;

            // Create Bread object
            if (type == nameof(Bread))
            {
                food = new Bread(name, price);
            }
            // Create Cake object
            else if (type == nameof(Cake))
            {
                food = new Cake(name, price);
            }

            // Add food to menu collection
            bakedFoods.Add(food);

            // Return success message
            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        /// <summary>
        /// Adds a drink to the menu.
        /// Creates either Water or Tea.
        /// </summary>
        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = default;

            // Create Water object
            if (type == nameof(Water))
            {
                drink = new Water(name, portion, brand);
            }
            // Create Tea object
            else if (type == nameof(Tea))
            {
                drink = new Tea(name, portion, brand);
            }

            // Add drink to menu collection
            drinks.Add(drink);

            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        /// <summary>
        /// Adds a table to the bakery.
        /// Creates either InsideTable or OutsideTable.
        /// </summary>
        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = default;

            // Create inside table
            if (type == nameof(InsideTable))
            {
                table = new InsideTable(tableNumber, capacity);
            }
            // Create outside table
            else if (type == nameof(OutsideTable))
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            // Add table to collection
            tables.Add(table);

            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        /// <summary>
        /// Finds the first free table that can fit the given number of people.
        /// </summary>
        public string ReserveTable(int numberOfPeople)
        {
            var freeTable = tables
                .FirstOrDefault(x =>
                    !x.IsReserved &&
                    x.Capacity >= numberOfPeople);

            // No suitable table found
            if (freeTable is null)
            {
                return string.Format(
                    OutputMessages.ReservationNotPossible,
                    numberOfPeople);
            }

            // Reserve the table
            freeTable.Reserve(numberOfPeople);

            return string.Format(
                OutputMessages.TableReserved,
                freeTable.TableNumber,
                numberOfPeople);
        }

        /// <summary>
        /// Orders food for a specific table.
        /// </summary>
        public string OrderFood(int tableNumber, string foodName)
        {
            // Find table
            var targetTable =
                tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            // Find food in menu
            var targetFood =
                bakedFoods.FirstOrDefault(x => x.Name == foodName);

            // Table does not exist
            if (targetTable is null)
            {
                return string.Format(
                    OutputMessages.WrongTableNumber,
                    tableNumber);
            }

            // Food does not exist
            if (targetFood is null)
            {
                return string.Format(
                    OutputMessages.NonExistentFood,
                    foodName);
            }

            // Add food to table order
            targetTable.OrderFood(targetFood);

            return string.Format(
                OutputMessages.FoodOrderSuccessful,
                tableNumber,
                foodName);
        }

        /// <summary>
        /// Orders a drink for a table.
        /// </summary>
        public string OrderDrink(
            int tableNumber,
            string drinkName,
            string drinkBrand)
        {
            // Find table
            var targetTable =
                tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            // Find drink by name and brand
            var targetDrink =
                drinks.FirstOrDefault(x =>
                    x.Name == drinkName &&
                    x.Brand == drinkBrand);

            // Table does not exist
            if (targetTable is null)
            {
                return string.Format(
                    OutputMessages.WrongTableNumber,
                    tableNumber);
            }

            // Drink does not exist
            if (targetDrink is null)
            {
                return string.Format(
                    OutputMessages.NonExistentDrink,
                    drinkName,
                    drinkBrand);
            }

            // Add drink to table order
            targetTable.OrderDrink(targetDrink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        /// <summary>
        /// Calculates table bill and clears the table.
        /// Customer leaves the bakery.
        /// </summary>
        public string LeaveTable(int tableNumber)
        {
            // Find table
            var targetTable =
                tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            // Calculate bill
            // GetBill() = food + drinks
            // Price = people count * price per person
            var bill =
                targetTable.GetBill() +
                targetTable.Price;

            // Add bill to bakery income
            total += bill;

            // Free the table
            targetTable.Clear();

            return $"Table: {tableNumber}{Environment.NewLine}" +
                   $"Bill: {bill}";
        }

        /// <summary>
        /// Returns information about all free tables.
        /// </summary>
        public string GetFreeTablesInfo()
        {
            // Get all non-reserved tables
            var freeTables =
                tables.Where(table => !table.IsReserved)
                      .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// Returns total bakery income.
        /// </summary>
        public string GetTotalIncome()
        {
            return string.Format(
                OutputMessages.TotalIncome,
                total);
        }
    }
}