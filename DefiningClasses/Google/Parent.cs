namespace Google
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This class represents a PARENT entity inside a Person profile system.
     *
     * It is part of a larger object model where a Person can have:
     * - Parents
     * - Children
     *
     * This demonstrates:
     * - Encapsulation (data grouped in one class)
     * - Object modeling (real-world relationship)
     */

    public class Parent
    {
        /*
         * CONSTRUCTOR:
         * ------------
         * Used to initialize a Parent object with required data.
         *
         * This ensures the object is always valid when created.
         */
        public Parent(string name, string bday)
        {
            this.Name = name;
            this.Birthday = bday;
        }

        /*
         * PROPERTIES (ENCAPSULATION):
         * ---------------------------
         * These store the state of the Parent object.
         *
         * Name → parent's name
         * Birthday → parent's birth date
         *
         * They are public so they can be accessed from Person class.
         */
        public string Name { get; set; }
        public string Birthday { get; set; }
    }
}