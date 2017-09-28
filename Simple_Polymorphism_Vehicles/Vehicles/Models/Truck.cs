using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_Vehicles.Models
{
    // Truck inherits from Vehicle (base class)
    public class Truck : Vehicle
    {
        // Constructor: initializes Truck and passes values to base Vehicle
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + 1.6, tankCapacity)
        {
            // Trucks consume extra 1.6 fuel per km due to load weight and inefficiency
        }

        // Refuel logic specific to Truck
        public override void Refuel(double liters)
        {
            // Call base validation (if any exists in Vehicle)
            base.Refuel(liters);

            // Truck loses 5% of fuel during refueling (fuel is not fully retained)
            // Only 95% of the fuel actually stays in the tank
            this.FuelQuantity += (liters * 0.95);
        }
    }
}