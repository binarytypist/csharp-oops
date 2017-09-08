using System.Text;

namespace CarSalesman
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This class represents a CAR in the system.
     *
     * A Car:
     * - has a Model (e.g. BMW, Audi)
     * - has an Engine (important relationship → composition)
     * - may have optional properties like Weight and Color
     * - can print itself in a formatted way using ToString()
     */

    public class Car
    {
        /*
         * CONSTRUCTOR:
         * ------------
         * A car MUST always have:
         * - model
         * - engine (because a car cannot exist without an engine)
         */
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }

        /*
         * REQUIRED PROPERTIES
         */

        // Car name (e.g. BMW, Audi, Ford)
        public string Model { get; set; }

        // IMPORTANT RELATIONSHIP:
        // A Car "HAS AN Engine"
        public Engine Engine { get; set; }

        /*
         * OPTIONAL PROPERTIES
         * These may or may not exist in input data
         */

        // Example: 1500kg
        public int? Weight { get; set; }

        // Example: "Black", "Red"
        public string Color { get; set; }

        /*
         * PURPOSE OF ToString():
         * ----------------------
         * This method defines HOW the object should be printed.
         *
         * Instead of printing raw data, we create a nice formatted output.
         */
        public override string ToString()
        {
            // StringBuilder is used for efficient string building
            var sb = new StringBuilder();

            /*
             * CAR INFORMATION (TOP LEVEL)
             */
            sb.AppendLine($"{this.Model}:");

            /*
             * ENGINE INFORMATION (nested inside Car)
             */
            sb.AppendLine($"  {this.Engine.Model}:");
            sb.AppendLine($"    Power: {this.Engine.Power}");

            /*
             * OPTIONAL ENGINE DATA
             */

            // If engine has no displacement → show "n/a"
            if (this.Engine.Displacement is null)
            {
                sb.AppendLine($"    Displacement: n/a");
            }
            else
            {
                sb.AppendLine($"    Displacement: {this.Engine.Displacement.Value}");
            }

            // If engine has no efficiency → show "n/a"
            if (string.IsNullOrEmpty(this.Engine.Efficiency))
            {
                sb.AppendLine($"    Efficiency: n/a");
            }
            else
            {
                sb.AppendLine($"    Efficiency: {this.Engine.Efficiency}");
            }

            /*
             * OPTIONAL CAR DATA
             */

            // If weight is missing → show "n/a"
            if (this.Weight is null)
            {
                sb.AppendLine($"  Weight: n/a");
            }
            else
            {
                sb.AppendLine($"  Weight: {this.Weight}");
            }

            // If color is missing → show "n/a"
            if (string.IsNullOrEmpty(this.Color))
            {
                sb.AppendLine($"  Color: n/a");
            }
            else
            {
                sb.AppendLine($"  Color: {this.Color}");
            }

            /*
             * FINAL OUTPUT:
             * Return the full formatted string
             */
            return sb.ToString();
        }
    }
}