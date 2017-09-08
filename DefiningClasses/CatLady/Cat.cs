namespace CatLady
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This is a BASE class for all cats in the system.
     *
     * It represents shared data that ALL cats have in common.
     *
     * Example:
     * - SiameseCat
     * - CymricCat
     * - StreetCat
     *
     * All of them will inherit from this class.
     */

    public class Cat
    {
        /*
         * PRIVATE FIELD:
         * --------------
         * This stores the actual value of the cat's name.
         *
         * It is private so it cannot be accessed directly from outside.
         * This is called ENCAPSULATION (important OOP concept).
         */
        private string name;

        /*
         * PUBLIC PROPERTY:
         * ----------------
         * This is how outside code interacts with the name field.
         *
         * It provides controlled access to the private variable.
         */
        public string Name
        {
            // GETTER:
            // Returns the value stored in the private field
            get { return name; }

            // SETTER:
            // Assigns a value to the private field
            set { name = value; }
        }
    }
}