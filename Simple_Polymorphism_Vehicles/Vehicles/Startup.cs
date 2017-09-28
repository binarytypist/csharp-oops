using Problem1_Vehicles.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem1_Vehicles
{
    class Startup
    {
        private static void Main(string[] args)
        {
            var carInfo = "Car 100 1 10".Split(' ');
            Vehicle car = new Car(
                double.Parse(carInfo[1]),
                double.Parse(carInfo[2]),
                double.Parse(carInfo[3])
            );

            var truckInfo = "Truck 300 2 20".Split(' ');
            Vehicle truck = new Truck(
                double.Parse(truckInfo[1]),
                double.Parse(truckInfo[2]),
                double.Parse(truckInfo[3])
            );

            var busInfo = "Bus 200 3 15".Split(' ');
            Vehicle bus = new Bus(
                double.Parse(busInfo[1]),
                double.Parse(busInfo[2]),
                double.Parse(busInfo[3])
            );

            List<Vehicle> vehicles = new List<Vehicle> { car, truck, bus };

            // -------------------------
            // DUMMY COMMANDS
            // -------------------------

            List<string> commands = new List<string>
            {
                "Drive Car 30",
                "Drive Truck 40",
                "Drive Bus 50",
                "Refuel Car 20",
                "DriveEmpty Bus 10"
            };

            foreach (var line in commands)
            {
                try
                {
                    var commandTokens = line.Split(' ');

                    var currentVehicle = vehicles
                        .FirstOrDefault(v => v.GetType().Name == commandTokens[1]);

                    var number = double.Parse(commandTokens[2]);

                    if (commandTokens[0] == "Drive")
                    {
                        currentVehicle.Drive(number);
                    }
                    else if (commandTokens[0] == "Refuel")
                    {
                        currentVehicle.Refuel(number);
                    }
                    else if (commandTokens[0] == "DriveEmpty")
                    {
                        (currentVehicle as Bus).DriveEmpty(number);
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            // -------------------------
            // OUTPUT RESULT
            // -------------------------

            Console.WriteLine($"{car}\n{truck}\n{bus}");
        }
    }
}