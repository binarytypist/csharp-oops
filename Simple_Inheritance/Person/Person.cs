using System;
using System.Text;

namespace Person
{
    public class Person
    {
        // Encapsulation: fields are hidden from external access
        private string name;
        private int age;

        // Constructor ensures object is created in a valid state
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        // Virtual property allows derived classes (e.g., Child) to override behavior
        public virtual int Age
        {
            get { return this.age; }
            protected set
            {
                // Validation rule: age cannot be negative
                if (value < 0)
                {
                    throw new ArgumentException("Age must be positive!");
                }

                this.age = value;
            }
        }

        // Encapsulated property with validation logic
        public string Name
        {
            get { return this.name; }
            protected set
            {
                // Business rule: name must have minimum length
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException("Name's length should not be less than 3 symbols!");
                }

                this.name = value;
            }
        }

        // Provides a readable representation of the object
        public override string ToString()
        {
            // StringBuilder used for efficient string construction
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("Name: {0}, Age: {1}", this.Name, this.Age);

            return stringBuilder.ToString();
        }
    }
}