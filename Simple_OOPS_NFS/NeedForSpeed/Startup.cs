using System;
using System.Collections.Generic;

class Startup
{
    private static void Main(string[] args)
    {
        // CarManager acts as the central service layer.
        // It manages cars, races, parking, tuning, and queries.
        CarManager manager = new CarManager();

        // Dummy commands replace Console.ReadLine() input.
        // This allows testing without user interaction.
        Queue<string> commands = new Queue<string>(new[]
        {
            "register 1 Performance Audi A4 200 300 100 150 1000",
            "register 2 Show BMW M3 250 350 120 180 2000",
            "check 1",
            "open 1 Drag 500 Berlin 100",
            "participate 1 1",
            "start 1",
            "park 2",
            "tune 50 Turbo",
            "unpark 2",
            "check 2",
            "Cops Are Here"
        });

        // Process commands until termination command is reached
        while (commands.Count > 0)
        {
            string input = commands.Dequeue();

            if (input == "Cops Are Here")
            {
                break;
            }

            // Parse command into tokens
            string[] tokens = input.Split(
                new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            switch (tokens[0])
            {
                case "register":
                    // Creates and registers a new car
                    manager.Register(
                        int.Parse(tokens[1]),
                        tokens[2],
                        tokens[3],
                        tokens[4],
                        int.Parse(tokens[5]),
                        int.Parse(tokens[6]),
                        int.Parse(tokens[7]),
                        int.Parse(tokens[8]),
                        int.Parse(tokens[9]));
                    break;

                case "check":
                    // Retrieves information about a car
                    Console.WriteLine(
                        manager.Check(int.Parse(tokens[1])));
                    break;

                case "open":
                    // Creates a race
                    if (tokens[2] == "TimeLimit" ||
                        tokens[2] == "Circuit")
                    {
                        manager.Open(
                            int.Parse(tokens[1]),
                            tokens[2],
                            int.Parse(tokens[3]),
                            tokens[4],
                            int.Parse(tokens[5]),
                            int.Parse(tokens[6]));
                    }
                    else
                    {
                        manager.Open(
                            int.Parse(tokens[1]),
                            tokens[2],
                            int.Parse(tokens[3]),
                            tokens[4],
                            int.Parse(tokens[5]));
                    }
                    break;

                case "participate":
                    // Adds a car to a race
                    manager.Participate(
                        int.Parse(tokens[1]),
                        int.Parse(tokens[2]));
                    break;

                case "start":
                    // Starts a race and prints results
                    Console.WriteLine(
                        manager.Start(int.Parse(tokens[1])));
                    break;

                case "park":
                    // Moves car to parking area
                    manager.Park(int.Parse(tokens[1]));
                    break;

                case "unpark":
                    // Removes car from parking area
                    manager.Unpark(int.Parse(tokens[1]));
                    break;

                case "tune":
                    // Applies tuning to parked cars
                    manager.Tune(
                        int.Parse(tokens[1]),
                        tokens[2]);
                    break;
            }
        }
    }
}