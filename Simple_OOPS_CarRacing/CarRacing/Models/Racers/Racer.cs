using System;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Racers
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * Racer is an ABSTRACT BASE CLASS representing a generic racer.
     *
     * OOP CONCEPTS USED:
     * 1. Abstraction:
     *    - Defines common structure for all racers
     *    - Cannot be instantiated directly
     *
     * 2. Encapsulation:
     *    - Fields are private
     *    - Validation is enforced in property setters
     *
     * 3. Inheritance:
     *    - Specialized racers (ProfessionalRacer, StreetRacer, etc.) inherit from this class
     *
     * 4. Polymorphism:
     *    - Race() method can be overridden in derived classes
     */

    public abstract class Racer : IRacer
    {
        // =========================
        // PRIVATE BACKING FIELDS
        // =========================
        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;

        // =========================
        // VALIDATED PROPERTIES
        // =========================

        public string Username
        {
            get => this.username;

            private set
            {
                // Encapsulation: validating input before assignment
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }

                this.username = value;
            }
        }

        public string RacingBehavior
        {
            get => this.racingBehavior;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }

                this.racingBehavior = value;
            }
        }

        public int DrivingExperience
        {
            get => this.drivingExperience;

            protected set
            {
                // Business rule: experience must be between 0 and 100
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }

                this.drivingExperience = value;
            }
        }

        public ICar Car
        {
            get => this.car;

            private set
            {
                if (value is null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }

                this.car = value;
            }
        }

        /*
         * CONSTRUCTOR:
         * ------------
         * Initializes a Racer with required data
         * Ensures all invariants are validated before object creation
         */
        protected Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience = drivingExperience;
            this.Car = car;
        }

        /*
         * RACE METHOD (POLYMORPHISM READY):
         * ----------------------------------
         * Default behavior: racer uses their car to drive.
         *
         * Derived classes can extend or override this behavior.
         */
        public virtual void Race()
        {
            this.car.Drive();
        }

        /*
         * AVAILABILITY CHECK:
         * -------------------
         * Determines if racer can participate in a race.
         *
         * Logic:
         * Racer is available only if car has enough fuel
         * for at least one race.
         *
         * NOTE: Potential improvement could include null checks or state validation.
         */
        public bool IsAvailable()
        {
            return Car.FuelAvailable > Car.FuelConsumptionPerRace;
        }
    }
}