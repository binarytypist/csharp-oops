namespace Google
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This class represents a CHILD entity in a person's profile.
     *
     * It is a simple DATA MODEL (also called a DTO).
     *
     * It demonstrates:
     * - Encapsulation (data grouped inside a class)
     * - Object modeling (real-world entity representation)
     */

    public class Child
    {
        /*
         * CONSTRUCTOR:
         * ------------
         * Used to initialize a Child object with required data.
         *
         * This ensures the object is always created in a valid state.
         */
        public Child(string name, string bday)
        {
            this.Name = name;
            this.Birthday = bday;
        }

        /*
         * PROPERTIES (ENCAPSULATION):
         * ---------------------------
         * These represent the state of the object.
         *
         * Name → child's name
         * Birthday → child's birth date
         *
         * They are public so other classes can read/write them.
         */
        public string Name { get; set; }
        public string Birthday { get; set; }
    }
}