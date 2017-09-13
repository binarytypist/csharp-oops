using System;

namespace Problem3_Mankind.Models
{
    public class Human
    {
        // Encapsulation: fields are hidden from external access
        private string firstname;
        private string lastName;

        // Constructor ensures object is created in a valid state
        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        // Virtual property enables inheritance and overriding in derived classes
        public virtual string LastName
        {
            get { return this.lastName; }
            protected set
            {
                // Validation: must start with uppercase letter
                if (char.IsLower(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: lastName");
                }

                // Validation: minimum length constraint
                if (value.Length < 3)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
                }

                this.lastName = value;
            }
        }

        // Encapsulated property with validation rules
        public string FirstName
        {
            get { return this.firstname; }
            protected set
            {
                // Validation: must start with uppercase letter
                if (char.IsLower(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName");
                }

                // Validation: minimum length constraint
                if (value.Length < 4)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                }

                this.firstname = value;
            }
        }
    }
}