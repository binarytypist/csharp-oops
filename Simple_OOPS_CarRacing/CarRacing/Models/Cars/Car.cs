using System;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Cars
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This is an ABSTRACT BASE CLASS for all Cars in the system.
     *
     * OOP CONCEPTS USED:
     * 1. Abstraction:
     *    - Defines common structure for all cars
     *    - Cannot be instantiated directly
     *
     * 2. Encapsulation:
     *    - Fields are private
     *    - Access controlled via properties with validation
     *
     * 3. Inheritance:
     *    - Other car types will inherit this class
     *
     * 4. Polymorphism:
     *    - Drive() can be overridden in derived classes
     */

    public abstract class Car : ICar
    {
        // =========================
        // PRIVATE BACKING FIELDS
        // =========================
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumptionPerRace;

        // =========================
        // VALIDATED PROPERTIES
        // =========================

        public string Make
        {
            get => this.make;

            private set
            {
                // Encapsulation + validation
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarMake);
                }

                this.make = value;
            }
        }

        public string Model
        {
            get => this.model;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarModel);
                }

                this.model = value;
            }
        }

        public string VIN
        {
            get => this.vin;

            private set
            {
                // Business rule: VIN must always be 17 characters
                if (value.Length != 17)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarVIN);
                }

                this.vin = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarHorsePower);
                }

                this.horsePower = value;
            }
        }

        public double FuelAvailable
        {
            get => this.fuelAvailable;

            private set
            {
                // Fuel cannot be negative (domain rule)
                if (value < 0)
                {
                    value = 0;
                }

                this.fuelAvailable = value;
            }
        }

        public double FuelConsumptionPerRace
        {
            get => this.fuelConsumptionPerRace;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarFuelConsumption);
                }

                this.fuelConsumptionPerRace = value;
            }
        }

        /*
         * CONSTRUCTOR:
         * ------------
         * Forces all derived cars to initialize required state
         */
        protected Car(
            string make,
            string model,
            string vin,
            int horsePower,
            double fuelAvailable,
            double fuelConsumptionPerRace)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = vin;
            this.HorsePower = horsePower;
            this.FuelAvailable = fuelAvailable;
            this.FuelConsumptionPerRace = fuelConsumptionPerRace;
        }

        /*
         * DRIVE METHOD (POLYMORPHISM READY):
         * ----------------------------------
         * Virtual allows derived classes to change behavior.
         *
         * Current logic:
         * - reduces fuel based on race consumption
         *
         * In real systems:
         * - could include speed, wear, conditions, etc.
         */
        public virtual void Drive()
        {
            this.fuelAvailable -= this.fuelConsumptionPerRace;
        }
    }
}