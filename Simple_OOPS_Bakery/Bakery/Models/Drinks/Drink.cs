using System;
using Bakery.Models.Drinks.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Models.Drinks
{
    /// <summary>
    /// Base abstract class for all drinks in the bakery system.
    /// Implements IDrink interface and provides common logic + validation.
    /// </summary>
    public abstract class Drink : IDrink
    {
        // Backing fields (store actual data)
        private string name;
        private int portion;
        private decimal price;
        private string brand;

        /// <summary>
        /// Constructor used by derived classes (Tea, Water).
        /// Initializes all common drink properties.
        /// </summary>
        protected Drink(string name, int portion, decimal price, string brand)
        {
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
            this.Brand = brand;
        }

        /// <summary>
        /// Name of the drink (e.g. "GreenTea")
        /// </summary>
        public string Name
        {
            get => this.name;
            private set
            {
                // Validation: name cannot be null or empty
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Portion size in ml (e.g. 250ml)
        /// </summary>
        public int Portion
        {
            get => this.portion;
            private set
            {
                // Validation: portion must be > 0
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPortion);
                }

                this.portion = value;
            }
        }

        /// <summary>
        /// Price of the drink
        /// </summary>
        public decimal Price
        {
            get => this.price;
            private set
            {
                // Validation: price must be > 0
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }

                this.price = value;
            }
        }

        /// <summary>
        /// Brand of the drink (e.g. Lipton, Evian)
        /// </summary>
        public string Brand
        {
            get => this.brand;
            private set
            {
                // Validation: brand cannot be empty
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBrand);
                }

                this.brand = value;
            }
        }

        /// <summary>
        /// Converts object to readable string format
        /// Used when printing drink info
        /// </summary>
        public override string ToString()
        {
            return $"{this.Name} {this.Brand} - {this.Portion}ml - {this.Price:f2}lv";
        }
    }
}