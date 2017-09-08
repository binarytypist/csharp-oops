using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    // Core manager handling all business logic
    private readonly DraftManager manager;

    public Engine()
    {
        this.manager = new DraftManager();
    }

    // Main input processing loop
    public void Run()
    {
        string input;

        // Continue until "Shutdown" command is received
        while ((input = Console.ReadLine()) != "Shutdown")
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }

            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string command = tokens[0];

            // Extract arguments once to avoid repetition
            List<string> args = tokens.Skip(1).ToList();

            switch (command)
            {
                case "RegisterHarvester":
                    Console.WriteLine(manager.RegisterHarvester(args));
                    break;

                case "RegisterProvider":
                    Console.WriteLine(manager.RegisterProvider(args));
                    break;

                case "Day":
                    Console.WriteLine(manager.Day());
                    break;

                case "Mode":
                    Console.WriteLine(manager.Mode(args));
                    break;

                case "Check":
                    Console.WriteLine(manager.Check(args));
                    break;
            }
        }

        // Final system summary on shutdown
        Console.WriteLine(manager.ShutDown());
    }
}