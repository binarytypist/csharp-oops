public class Employee
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This class represents an Employee in a company system.
     *
     * It is a DATA MODEL (also called a POCO in C#).
     * It stores employee information like:
     * - Name
     * - Salary
     * - Position
     * - Department
     * - Optional: Email
     * - Optional: Age
     */

    /*
     * CONSTRUCTOR 1 (MAIN CONSTRUCTOR)
     * ---------------------------------
     * This constructor is used when we only know basic employee info.
     *
     * Required fields:
     * - name
     * - salary
     * - position
     * - department
     */
    public Employee(string name, decimal salary, string position, string department)
    {
        // Assign values to properties
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
    }

    /*
     * CONSTRUCTOR 2 (OVERLOADED + CHAINING)
     * --------------------------------------
     * This constructor is used when we have EXTRA optional data:
     * - email
     * - age
     *
     * IMPORTANT CONCEPT:
     * ------------------
     * ": this(...)"
     * means:
     * → Call Constructor 1 first (reuse code)
     * → Then add extra values
     *
     * This avoids repeating code (VERY IMPORTANT OOP PRINCIPLE)
     */
    public Employee(string name, decimal salary, string position, string department, string email, int age)
        : this(name, salary, position, department) // constructor chaining
    {
        // extra optional data
        this.Email = email;
        this.Age = age;
    }

    /*
     * PROPERTIES (DATA FIELDS)
     * ------------------------
     * These define what an Employee "has"
     */

    public string Name { get; set; }        // employee name
    public decimal Salary { get; set; }     // employee salary
    public string Position { get; set; }    // job title
    public string Department { get; set; }  // department name

    /*
     * OPTIONAL FIELDS
     * ---------------
     * These may or may not exist depending on input
     */

    public string Email { get; set; }       // email can be missing

    public int? Age { get; set; }           // nullable int (can be null)
}