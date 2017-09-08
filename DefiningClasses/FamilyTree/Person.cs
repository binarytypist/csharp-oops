using System.Collections.Generic;

namespace FamilyTree
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This class represents a PERSON in a family tree system.
     *
     * Each Person can:
     * - have a name
     * - have a birth date
     * - have parents (relationship)
     * - have children (relationship)
     *
     * This is a classic example of:
     * → OBJECT RELATIONSHIPS (COMPOSITION)
     */

    public class Person
    {
        /*
         * CONSTRUCTOR 1:
         * --------------
         * Creates a Person using First Name + Last Name
         *
         * Used when we know the identity but not the date yet
         */
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            /*
             * IMPORTANT:
             * ----------
             * Every Person must have their own lists
             * so they can store relationships safely.
             */
            this.Parents = new List<Person>();
            this.Children = new List<Person>();
        }

        /*
         * CONSTRUCTOR 2:
         * --------------
         * Creates a Person using ONLY a date
         *
         * Used when identity is unknown but birth date is known
         */
        public Person(string date)
        {
            this.Date = date;

            /*
             * INITIALIZE RELATIONSHIPS LISTS
             * -------------------------------
             * Without this, we would get NullReferenceException
             */
            this.Parents = new List<Person>();
            this.Children = new List<Person>();
        }

        /*
         * CONSTRUCTOR 3 (CONSTRUCTOR CHAINING):
         * -------------------------------------
         * This constructor uses existing constructor logic
         * to avoid code duplication.
         *
         * ": this(firstName, lastName)" means:
         * → First call constructor 1
         * → Then set additional data (date)
         */
        public Person(string firstName, string lastName, string date)
            : this(firstName, lastName)
        {
            this.Date = date;
        }

        /*
         * PROPERTIES (DATA OF THE PERSON)
         * -------------------------------
         * These define what a Person "HAS"
         */

        public string FirstName { get; set; }   // person's first name
        public string LastName { get; set; }    // person's last name
        public string Date { get; set; }        // birth date

        /*
         * RELATIONSHIPS (VERY IMPORTANT OOP CONCEPT)
         * ------------------------------------------
         * This is COMPOSITION:
         *
         * A Person HAS:
         * - Parents (list of Person objects)
         * - Children (list of Person objects)
         *
         * This creates a GRAPH structure in memory.
         */
        public List<Person> Parents { get; set; }
        public List<Person> Children { get; set; }

        /*
         * ToString OVERRIDE:
         * ------------------
         * Controls how Person is printed.
         *
         * Instead of default object format,
         * we show readable information.
         */
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} {this.Date}";
        }
    }
}