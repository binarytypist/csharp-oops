namespace AquaShop.Core
{
    using System;
    using AquaShop.Core.Contracts;
    using AquaShop.IO.Contracts;

    /// <summary>
    /// Engine is responsible for application execution flow.
    /// 
    /// It:
    /// - Reads input from IInputProvider
    /// - Sends commands to Controller
    /// - Prints results using IWriter
    /// 
    /// It does NOT contain business logic (SRP principle).
    /// </summary>
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IController controller;
        private readonly IInputProvider inputProvider;

        public Engine(IWriter writer, IController controller, IInputProvider inputProvider)
        {
            this.writer = writer;
            this.controller = controller;
            this.inputProvider = inputProvider;
        }

        /// <summary>
        /// Main execution loop of the system.
        /// Processes all incoming commands sequentially.
        /// </summary>
        public void Run()
        {
            foreach (var inputLine in inputProvider.GetInput())
            {
                string[] input = inputLine.Split();
                string command = input[0];

                try
                {
                    string result = ProcessCommand(input, command);

                    if (command == "Exit")
                    {
                        break;
                    }

                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Routes commands to the correct Controller methods.
        /// Acts like a command dispatcher.
        /// </summary>
        private string ProcessCommand(string[] input, string command)
        {
            return command switch
            {
                "AddAquarium" => controller.AddAquarium(input[1], input[2]),
                "AddDecoration" => controller.AddDecoration(input[1]),
                "InsertDecoration" => controller.InsertDecoration(input[1], input[2]),
                "AddFish" => controller.AddFish(input[1], input[2], input[3], input[4], decimal.Parse(input[5])),
                "FeedFish" => controller.FeedFish(input[1]),
                "CalculateValue" => controller.CalculateValue(input[1]),
                "Report" => controller.Report(),
                "Exit" => string.Empty,
                _ => throw new InvalidOperationException("Invalid command!")
            };
        }
    }
}