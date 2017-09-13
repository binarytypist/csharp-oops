using System;

namespace Person
{
    public class Child : Person
    {
        // Constructor forwards initialization to base class (Person)
        public Child(string name, int age)
            : base(name, age)
        {
            // Additional validation is handled via overridden Age property
        }

        // Override Age to enforce stricter business rule for Child
        public override int Age
        {
            get
            {
                // Inherits base behavior for retrieving age
                return base.Age;
            }
            protected set
            {
                // Domain rule: Child cannot be 15 or older
                if (value >= 15)
                {
                    throw new ArgumentException("Child's age must be less than 15!");
                }

                // Delegate actual storage to base class implementation
                base.Age = value;
            }
        }
    }
}