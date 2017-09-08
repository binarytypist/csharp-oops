namespace Google
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This class represents a COMPANY relationship for a Person.
     *
     * It stores work-related information such as:
     * - Company name
     * - Department
     * - Salary
     *
     * It demonstrates:
     * - Encapsulation (data bundled in a class)
     * - Object modeling (real-world company entity)
     */

    public class Company
    {
        /*
         * CONSTRUCTOR:
         * ------------
         * Initializes a Company object with required values.
         *
         * This ensures the object is created in a valid state.
         */
        public Company(string name, string department, decimal salary)
        {
            this.Name = name;
            this.Department = department;
            this.Salary = salary;
        }

        /*
         * PROPERTIES (ENCAPSULATION):
         * ---------------------------
         * These store the state of the Company object.
         *
         * Name → company name
         * Department → employee department
         * Salary → employee salary in that company
         *
         * They are public so other classes can access them.
         */
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
    }
}