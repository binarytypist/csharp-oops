using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_Vehicles.Models
{
    // Bus is a specialized Vehicle type (inheritance)
    public class Bus : Vehicle
    {
        // Constructor: passes initial values to the base Vehicle class
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        // Refuel logic for Bus
        public override void Refuel(double liters)
        {
            // First calls base implementation (may include validation in Vehicle)
            base.Refuel(liters);

            // Calculate remaining space in the tank
            double freeSpace = this.TankCapacity - this.FuelQuantity;

            // If trying to add more fuel than space allows → reject
            if (liters > freeSpace)
            {
                Console.WriteLine("Cannot fit fuel in tank");
                return;
            }

            // Otherwise add fuel to the tank
            this.FuelQuantity += liters;
        }

        // Driving logic when bus is NOT empty (passengers inside)
        public override void Drive(double km)
        {
            // Bus consumes extra fuel when carrying passengers (+1.4 L/km)
            this.FuelConsumption += 1.4;

            // Call base Drive method (calculates fuel usage and reduces fuel)
            base.Drive(km);

            // Restore original fuel consumption after trip
            this.FuelConsumption -= 1.4;
        }

        // Driving logic when bus is EMPTY (no extra consumption)
        public void DriveEmpty(double km)
        {
            // Uses base vehicle logic without extra fuel consumption
            base.Drive(km);
        }
    }
}