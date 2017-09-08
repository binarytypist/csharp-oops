using System.Collections.Generic;
using System.Text;

namespace Google
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This is the MAIN entity in the Google problem.
     *
     * It represents a PERSON who has multiple related objects:
     * - Company (HAS-A)
     * - Car (HAS-A)
     * - Pokemon (HAS-MANY)
     * - Parents (HAS-MANY)
     * - Children (HAS-MANY)
     *
     * This is a CLASSIC OOP COMPOSITION MODEL.
     */

    public class Person
    {
        /*
         * CONSTRUCTOR:
         * ------------
         * Initializes a Person with a name and empty collections.
         *
         * IMPORTANT:
         * We initialize lists to avoid NullReferenceException.
         */
        public Person(string name)
        {
            this.Name = name;

            // composition collections (HAS-MANY relationships)
            this.Pokemons = new List<Pokemon>();
            this.Parents = new List<Parent>();
            this.Children = new List<Child>();
        }

        /*
         * PROPERTIES (ENCAPSULATION):
         * ---------------------------
         * These define the state of a Person object.
         */
        public string Name { get; set; }

        // HAS-A relationship (single object)
        public Company Company { get; set; }

        // HAS-MANY relationship (collections)
        public ICollection<Pokemon> Pokemons { get; set; }
        public ICollection<Parent> Parents { get; set; }
        public ICollection<Child> Children { get; set; }

        // HAS-A relationship (single object)
        public Car Car { get; set; }

        /*
         * ToString METHOD (OUTPUT FORMATTING):
         * ------------------------------------
         * This controls how the object is printed.
         *
         * Instead of printing raw memory data,
         * we format it into readable profile-style output.
         */
        public override string ToString()
        {
            var sb = new StringBuilder();

            // BASIC INFO
            sb.AppendLine(this.Name);

            // COMPANY SECTION (HAS-A)
            sb.AppendLine("Company:");
            if (this.Company != null)
            {
                sb.AppendLine($"{this.Company.Name} {this.Company.Department} {this.Company.Salary:F2}");
            }

            // CAR SECTION (HAS-A)
            sb.AppendLine("Car:");
            if (this.Car != null)
            {
                sb.AppendLine($"{this.Car.Model} {this.Car.Speed}");
            }

            // POKEMONS SECTION (HAS-MANY)
            sb.AppendLine("Pokemon:");
            if (this.Pokemons != null)
            {
                foreach (var poke in this.Pokemons)
                {
                    sb.AppendLine($"{poke.Name} {poke.Type}");
                }
            }

            // PARENTS SECTION (HAS-MANY)
            sb.AppendLine("Parents:");
            if (this.Parents != null)
            {
                foreach (var p in this.Parents)
                {
                    sb.AppendLine($"{p.Name} {p.Birthday}");
                }
            }

            // CHILDREN SECTION (HAS-MANY)
            sb.AppendLine("Children:");
            if (this.Children != null)
            {
                foreach (var c in this.Children)
                {
                    sb.AppendLine($"{c.Name} {c.Birthday}");
                }
            }

            return sb.ToString();
        }
    }
}