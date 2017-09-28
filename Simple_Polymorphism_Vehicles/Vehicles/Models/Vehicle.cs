using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_Vehicles.Models
{
    // Abstract base class representing a general vehicle
    // All specific vehicles (Car, Truck, Bus) inherit from this
    public abstract class Vehicle
    {
        // Encapsulated fields (hidden internal state)
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        // Property representing maximum fuel capacity of the tank
        public double TankCapacity
        {
            get { return this.tankCapacity; }
            protected set { this.tankCapacity = value; }
        }

        // Constructor initializes vehicle state
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        // Property for fuel consumption per km
        // Marked virtual so derived classes can modify behavior
        public virtual double FuelConsumption
        {
            get { return this.fuelConsumption; }
            protected set { this.fuelConsumption = value; }
        }

        // Property for current fuel amount
        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            protected set
            {
                // Validation: fuel cannot be zero or negative
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel must be a positive number");
                }

                this.fuelQuantity = value;
            }
        }

        // Method used to refuel the vehicle
        public virtual void Refuel(double liters)
        {
            // Validation: cannot refuel with zero or negative fuel
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
        }

        // Method used to simulate driving
        public virtual void Drive(double km)
        {
            // Calculate required fuel for distance
            var fuelNeeded = km * this.FuelConsumption;

            // Check if enough fuel is available
            if (this.FuelQuantity - fuelNeeded < 0)
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
                return;
            }

            // Reduce fuel after successful drive
            this.FuelQuantity -= fuelNeeded;

            // Output travel confirmation
            Console.WriteLine($"{this.GetType().Name} travelled {km} km");
        }

        // String representation of vehicle state
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}