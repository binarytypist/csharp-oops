namespace CatLady
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This class represents a specific type of Cat: "Cymric"
     *
     * It inherits from the base class "Cat"
     *
     * That means it already HAS:
     * - Name (from Cat class)
     *
     * And it adds its own extra feature:
     * - FurLength
     */

    public class Cymric : Cat
    {
        /*
         * PRIVATE FIELD:
         * --------------
         * This stores the actual fur length value.
         * It is hidden from outside (encapsulation).
         */
        private double furLength;

        /*
         * CONSTRUCTOR:
         * ------------
         * This runs when we create a Cymric object.
         *
         * We must provide:
         * - name (from base Cat class)
         * - furLength (specific to Cymric)
         */
        public Cymric(string name, double furLength)
        {
            // inherited property from Cat
            this.Name = name;

            // specific property of Cymric
            this.FurLength = furLength;
        }

        /*
         * PROPERTY:
         * ---------
         * This gives controlled access to furLength.
         */
        public double FurLength
        {
            get { return furLength; }
            set { furLength = value; }
        }

        /*
         * ToString():
         * ----------
         * This controls how the object is printed.
         *
         * Instead of printing raw data,
         * we format it nicely.
         */
        public override string ToString()
        {
            /*
             * F2 means:
             * show 2 digits after decimal point
             *
             * Example:
             * 5.5 → 5.50
             */
            return $"Cymric {this.Name} {this.FurLength:F2}";
        }
    }
}