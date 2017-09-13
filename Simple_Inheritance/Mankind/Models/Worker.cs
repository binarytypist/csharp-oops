using System;
using System.Text;

namespace Problem3_Mankind.Models
{
    public class Worker : Human
    {
        // Encapsulation: internal state hidden
        private decimal weeklySalary;
        private decimal workHoursPerDay;

        // Constructor enforces valid state on creation
        public Worker(string firstName, string lastName, decimal salary, decimal workingHours)
            : base(firstName, lastName)
        {
            this.WeeklySalary = salary;
            this.WorkHoursPerDay = workingHours;
        }

        // Derived business logic: salary per hour calculation
        public decimal HourlyWage
        {
            get { return CalculateHourlyWage(); }
        }

        // Encapsulated business logic
        private decimal CalculateHourlyWage()
        {
            // Assumes 5 working days per week
            return this.WeeklySalary / (5 * this.WorkHoursPerDay);
        }

        // Validation: working hours must be realistic
        public decimal WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            private set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workHoursPerDay = value;
            }
        }

        // Validation: salary must be above minimum threshold
        public decimal WeeklySalary
        {
            get { return this.weeklySalary; }
            private set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weeklySalary = value;
            }
        }

        // Override Human behavior to enforce stricter last name rule
        public override string LastName
        {
            get => base.LastName;
            protected set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
                }

                base.LastName = value;
            }
        }

        // Object representation (abstraction of internal state)
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"First Name: {this.FirstName}");
            sb.AppendLine($"Last Name: {this.LastName}");
            sb.AppendLine($"Week Salary: {this.WeeklySalary:F2}");
            sb.AppendLine($"Hours per day: {this.WorkHoursPerDay:F2}");
            sb.Append($"Salary per hour: {this.HourlyWage:F2}");

            return sb.ToString();
        }
    }
}