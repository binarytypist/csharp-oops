using System;

namespace ShoppingSpree
{
    public class Product
    {
        // Encapsulation: fields are private to protect internal state
        private decimal cost;
        private string name;

        // Constructor ensures the object is always created in a valid state
        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        // Property controls access and validation for Cost
        public decimal Cost
        {
            get { return cost; }
            private set
            {
                // Business rule: cost cannot be negative
                if (value < 0)
                {
                    throw new ArgumentException("Cost cannot be negative");
                }

                cost = value;
            }
        }

        // Property controls access and validation for Name
        public string Name
        {
            get { return name; }
            private set
            {
                // Validation ensures product has a valid name
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }
    }
}