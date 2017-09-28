using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_Vehicles.Models
{
    // Car inherits from Vehicle (base class)
    public class Car : Vehicle
    {
        // Constructor: initializes Car and passes values to Vehicle
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + 0.9, tankCapacity)
        {
            // Important rule:
            // Car consumes EXTRA 0.9 fuel per km (air conditioner / engine load simulation)
            // So we add +0.9 to base fuel consumption
        }

        // Refuel logic specific to Car
        public override void Refuel(double liters)
        {
            // Call base validation logic (if any exists in Vehicle)
            base.Refuel(liters);

            // Calculate how much space is left in tank
            double freeSpace = this.TankCapacity - this.FuelQuantity;

            // If fuel exceeds tank capacity → reject refuel
            if (liters > freeSpace)
            {
                Console.WriteLine("Cannot fit fuel in tank");
                return;
            }

            // Otherwise add fuel to current fuel quantity
            this.FuelQuantity += liters;
        }
    }
}