using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem3_Mankind.Models
{
    public class Student : Human
    {
        // Encapsulated field for faculty number
        private string facultyNumber;

        // Constructor enforces valid object creation using base + derived validation
        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        // Property with validation for domain rule (faculty number format)
        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            private set
            {
                // Rule: only letters and digits, length between 5 and 10
                Regex rgx = new Regex(@"^[a-zA-Z0-9]{5,10}$");

                if (!rgx.IsMatch(value))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                this.facultyNumber = value;
            }
        }

        // Provides structured output of student data
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            // Inherited properties from Human class
            sb.AppendLine($"First Name: {this.FirstName}");
            sb.AppendLine($"Last Name: {this.LastName}");

            // Student-specific property
            sb.Append($"Faculty number: {this.FacultyNumber}");

            return sb.ToString();
        }
    }
}