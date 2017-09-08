namespace CatLady
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This class represents a specific type of Cat: "Siamese"
     *
     * It inherits from the base class "Cat"
     *
     * That means it automatically has:
     * - Name (from Cat class)
     *
     * And it adds its own unique feature:
     * - EarSize
     */

    public class Siamese : Cat
    {
        /*
         * PRIVATE FIELD:
         * --------------
         * Stores the actual ear size value internally.
         * It is hidden from outside (encapsulation principle).
         */
        private int earSize;

        /*
         * CONSTRUCTOR:
         * ------------
         * This runs when we create a Siamese cat object.
         *
         * We must provide:
         * - name (inherited from Cat)
         * - earSize (specific to Siamese)
         */
        public Siamese(string name, int earSize)
        {
            // inherited property from base class Cat
            this.Name = name;

            // specific property for Siamese
            this.EarSize = earSize;
        }

        /*
         * PROPERTY:
         * ---------
         * Controlled access to earSize field.
         */
        public int EarSize
        {
            get { return earSize; }
            set { earSize = value; }
        }

        /*
         * ToString():
         * ----------
         * Controls how this object is printed.
         *
         * Instead of default output,
         * we format it nicely.
         */
        public override string ToString()
        {
            return $"Siamese {this.Name} {this.EarSize}";
        }
    }
}