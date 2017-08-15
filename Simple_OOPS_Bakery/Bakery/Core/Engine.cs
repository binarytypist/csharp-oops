namespace Bakery.Core
{
    using Bakery.Core.Contracts;
    using Bakery.IO;
    using Bakery.IO.Contracts;
    using System;



    // The Engine is the input/output controller of the whole program.
    // It reads commands from the user
    // Sends them to the Controller
    // Prints the result

    // Think of it like this:
    // User Input → Engine → Controller → Engine → Output

    /// <summary>
    /// Engine is responsible for:
    /// - Reading commands from input
    /// - Parsing commands
    /// - Sending them to Controller
    /// - Printing results
    /// </summary>
    public class Engine : IEngine
    {
        private IWriter writer;       // Responsible for output (Console.WriteLine)
        private IReader reader;       // Responsible for input (Console.ReadLine)
        private IController controller; // Handles all business logic

        public Engine()
        {
            // Initialize IO system
            this.writer = new Writer();
            this.reader = new Reader();

            // Initialize main logic controller
            this.controller = new Controller();
        }

        /// <summary>
        /// Main program loop.
        /// Keeps running until "END" command is received.
        /// </summary>
        public void Run()
        {
            // Read first command from console
            string input = Console.ReadLine();

            // Loop until termination command
            while (input != "END")
            {
                // Split command into parts
                string[] arguments = input.Split();

                // First word is the command type
                string command = arguments[0];

                string result = string.Empty;

                try
                {
                    // Decide which controller method to call
                    switch (command)
                    {
                        // =========================
                        // ADD FOOD COMMAND
                        // =========================
                        case "AddFood":
                            string type = arguments[1];
                            string name = arguments[2];
                            decimal price = decimal.Parse(arguments[3]);

                            result = controller.AddFood(type, name, price);
                            break;

                        // =========================
                        // ADD DRINK COMMAND
                        // =========================
                        case "AddDrink":
                            string drinktype = arguments[1];
                            string drinkName = arguments[2];
                            int portion = int.Parse(arguments[3]);
                            string brand = arguments[4];

                            result = controller.AddDrink(
                                drinktype,
                                drinkName,
                                portion,
                                brand);
                            break;

                        // =========================
                        // ADD TABLE COMMAND
                        // =========================
                        case "AddTable":
                            string tableType = arguments[1];
                            int tableNumber = int.Parse(arguments[2]);
                            int capacity = int.Parse(arguments[3]);

                            result = controller.AddTable(
                                tableType,
                                tableNumber,
                                capacity);
                            break;

                        // =========================
                        // RESERVE TABLE COMMAND
                        // =========================
                        case "ReserveTable":
                            int numberOfPeople =
                                int.Parse(arguments[1]);

                            result = controller.ReserveTable(numberOfPeople);
                            break;

                        // =========================
                        // ORDER FOOD COMMAND
                        // =========================
                        case "OrderFood":
                            int tableNum =
                                int.Parse(arguments[1]);
                            string foodName =
                                arguments[2];

                            result = controller.OrderFood(
                                tableNum,
                                foodName);
                            break;

                        // =========================
                        // ORDER DRINK COMMAND
                        // =========================
                        case "OrderDrink":
                            int tableN =
                                int.Parse(arguments[1]);
                            string drName =
                                arguments[2];
                            string drinkBrand =
                                arguments[3];

                            result = controller.OrderDrink(
                                tableN,
                                drName,
                                drinkBrand);
                            break;

                        // =========================
                        // LEAVE TABLE COMMAND
                        // =========================
                        case "LeaveTable":
                            int leftTableNum =
                                int.Parse(arguments[1]);

                            result = controller.LeaveTable(leftTableNum);
                            break;

                        // =========================
                        // FREE TABLE INFO
                        // =========================
                        case "GetFreeTablesInfo":
                            result = controller.GetFreeTablesInfo();
                            break;

                        // =========================
                        // TOTAL INCOME
                        // =========================
                        case "GetTotalIncome":
                            result = controller.GetTotalIncome();
                            break;
                    }

                    // Print result to console
                    writer.WriteLine(result);
                }
                catch (ArgumentNullException ane)
                {
                    // Handle null/empty input errors
                    writer.WriteLine(ane.Message);
                }
                catch (ArgumentException ae)
                {
                    // Handle invalid argument errors
                    writer.WriteLine(ae.Message);
                }

                // Read next command
                input = reader.ReadLine();
            }
        }
    }
}