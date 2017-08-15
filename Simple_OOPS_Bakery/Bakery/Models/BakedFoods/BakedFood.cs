using System;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Models.BakedFoods
{

    //  The BakedFood class is an abstract base class for all baked food items in the bakery menu.
    //  It implements the IBakedFood interface, which defines the properties that all baked foods must have: Name, Portion, and Price.
    //  The BakedFood class provides a constructor to initialize these properties and includes validation to ensure that the values are valid (e.g., name cannot be null or whitespace,
    //  portion and price must be greater than zero).
    //  The ToString method is overridden to provide a string representation of the baked food item, which includes its name, portion size in grams,
    //  and price formatted to two decimal places.
    public abstract class BakedFood : IBakedFood
    {
        // Backing fields for the properties
        // These fields store the actual values for the Name, Portion, and Price properties.
        // The properties will use these fields to get and set their values, allowing for validation logic in the setters.
        

        private string name;
        private int portion;
        private decimal price;


        // Constructor to initialize the properties of the baked food item.
        // The constructor takes three parameters: name, portion, and price, which are used to set the corresponding properties.
        // The constructor is protected, meaning it can only be called by derived classes (e.g., Bread and Cake), ensuring that BakedFood cannot be instantiated directly.
        protected BakedFood(string name, int portion, decimal price)
        {
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
        }


        //  Properties with validation in the setters to ensure that the values are valid according to the business rules of the bakery.
        //  The Name property cannot be null, empty, or whitespace. If an invalid name is provided, an ArgumentException is thrown with a message from the ExceptionMessages class.
        //  The Portion property must be greater than zero. If an invalid portion is provided, an ArgumentException is thrown with a message from the ExceptionMessages class.
        //  The Price property must be greater than zero. If an invalid price is provided, an ArgumentException is thrown with a message from the ExceptionMessages class.

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }

                this.name = value;
            }
        }

        // The Portion property represents the portion size of the baked food item in grams. It must be a positive integer.
        // The Price property represents the price of the baked food item. It must be a positive decimal value.
        // Both properties include validation in their setters to ensure that the values are valid according to the business rules of the bakery.
        // If an invalid value is provided for either property, an ArgumentException is thrown with a message from the ExceptionMessages class.
        // The ToString method is overridden to provide a string representation of the baked food item, which includes its name, portion size in grams, and price formatted to two decimal places.
        public int Portion
        {
            get => this.portion;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPortion);
                }

                this.portion = value;
            }
        }

        // The Price property represents the price of the baked food item. It must be a positive decimal value.
        // The Price property includes validation in its setter to ensure that the value is valid according to the business rules of the bakery.
        // If an invalid value is provided for the Price property, an ArgumentException is thrown with a message from the ExceptionMessages class.
        // The ToString method is overridden to provide a string representation of the baked food item, which includes its name, portion size in grams, and price formatted to two decimal places.
        public decimal Price
        {
            get => this.price;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }

                this.price = value;
            }
        }

        //  The ToString method is overridden to provide a string representation of the baked food item, which includes its name, portion size in grams,
        //  and price formatted to two decimal places. This method is useful for displaying the details of the baked food item in a user-friendly format,
        //  such as when listing the menu items or showing order details.
        public override string ToString()
        {
            return $"{this.Name}: {this.Portion}g - {this.Price:f2}";
        }
    }
}