using System;
using System.Collections.Generic;

class Startup
{
    private static void Main(string[] args)
    {
        var manager = new DraftManager();

        // Dummy Harvesters
        Console.WriteLine(
            manager.RegisterHarvester(
                new List<string>
                {
                    "Hammer",
                    "H1",
                    "100",
                    "50"
                }));

        Console.WriteLine(
            manager.RegisterHarvester(
                new List<string>
                {
                    "Sonic",
                    "H2",
                    "200",
                    "100",
                    "4"
                }));

        // Dummy Providers
        Console.WriteLine(
            manager.RegisterProvider(
                new List<string>
                {
                    "Solar",
                    "P1",
                    "500"
                }));

        Console.WriteLine(
            manager.RegisterProvider(
                new List<string>
                {
                    "Pressure",
                    "P2",
                    "300"
                }));

        Console.WriteLine();

        // Simulate day
        Console.WriteLine(manager.Day());

        Console.WriteLine();

        // Change mode
        Console.WriteLine(
            manager.Mode(
                new List<string>
                {
                    "Half"
                }));

        Console.WriteLine();

        // Simulate another day
        Console.WriteLine(manager.Day());

        Console.WriteLine();

        // Check machines
        Console.WriteLine(
            manager.Check(
                new List<string>
                {
                    "H1"
                }));

        Console.WriteLine();

        Console.WriteLine(
            manager.Check(
                new List<string>
                {
                    "P1"
                }));

        Console.WriteLine();
        Console.WriteLine(manager.ShutDown());
    }
}