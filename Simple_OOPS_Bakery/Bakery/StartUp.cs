namespace Bakery
{
    using Bakery.Core;
    using System;

    // The bakery can:
    // Add foods(Bread, Cake)
    // Add drinks(Tea, Water)
    // Add tables(InsideTable, OutsideTable)
    // Reserve tables
    // Order food and drinks
    // Leave tables and calculate bills
    // Track total income
    // Show free tables

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Controller controller = new Controller();

            // ==========================
            // Add foods to menu
            // ==========================
            Console.WriteLine(
                controller.AddFood("Bread", "WhiteBread", 3.50m));

            Console.WriteLine(
                controller.AddFood("Cake", "ChocolateCake", 15.00m));

            // ==========================
            // Add drinks to menu
            // ==========================
            Console.WriteLine(
                controller.AddDrink("Tea", "GreenTea", 250, "Lipton"));

            Console.WriteLine(
                controller.AddDrink("Water", "MineralWater", 500, "Evian"));

            // ==========================
            // Add tables
            // ==========================
            Console.WriteLine(
                controller.AddTable("InsideTable", 1, 4));

            Console.WriteLine(
                controller.AddTable("OutsideTable", 2, 6));

            // ==========================
            // Reserve a table
            // ==========================
            Console.WriteLine(
                controller.ReserveTable(3));

            // ==========================
            // Order food
            // ==========================
            Console.WriteLine(
                controller.OrderFood(1, "WhiteBread"));

            Console.WriteLine(
                controller.OrderFood(1, "ChocolateCake"));

            // ==========================
            // Order drinks
            // ==========================
            Console.WriteLine(
                controller.OrderDrink(1,
                    "GreenTea",
                    "Lipton"));

            Console.WriteLine(
                controller.OrderDrink(1,
                    "MineralWater",
                    "Evian"));

            // ==========================
            // Show free tables
            // ==========================
            Console.WriteLine();
            Console.WriteLine("FREE TABLES");
            Console.WriteLine(
                controller.GetFreeTablesInfo());

            // ==========================
            // Customer leaves
            // ==========================
            Console.WriteLine();
            Console.WriteLine(
                controller.LeaveTable(1));

            // ==========================
            // Total income
            // ==========================
            Console.WriteLine();
            Console.WriteLine(
                controller.GetTotalIncome());
        }
    }
}