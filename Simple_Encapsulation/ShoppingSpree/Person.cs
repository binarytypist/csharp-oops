using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
        // Encapsulation: fields are kept private to protect internal state
        private decimal money;
        private string name;
        private IList<Product> products;

        // Constructor ensures object is initialized in a valid state
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;

            // Each person starts with an empty product list
            this.Products = new List<Product>();
        }

        // Property controls access and validation for Money
        public decimal Money
        {
            get { return money; }
            set
            {
                // Validation ensures business rule: no negative money
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }

        // Property with validation for Name
        // Setter is private to prevent external modification after creation
        public string Name
        {
            get { return name; }
            private set
            {
                // Validation ensures name is meaningful and not empty
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        // Encapsulation of collection: prevents external replacement of list
        // but allows controlled access through the property
        public IList<Product> Products
        {
            get { return products; }
            private set { products = value; }
        }
    }
}