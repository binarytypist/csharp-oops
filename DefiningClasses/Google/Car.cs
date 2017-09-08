namespace Google
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This class represents a CAR entity in a Person profile system.
     *
     * Each Person can own ONE Car.
     *
     * This demonstrates:
     * - Encapsulation (data grouped in a class)
     * - Object modeling (real-world object representation)
     * - HAS-A relationship (Person HAS A Car)
     */

    public class Car
    {
        /*
         * CONSTRUCTOR:
         * ------------
         * Initializes a Car object with required data.
         *
         * Ensures the object is created in a valid state.
         */
        public Car(string model, int speed)
        {
            this.Model = model;
            this.Speed = speed;
        }

        /*
         * PROPERTIES (ENCAPSULATION):
         * ---------------------------
         * These store the state of the Car object.
         *
         * Model → car model name (e.g., BMW)
         * Speed → car speed (e.g., 200)
         *
         * They are public so Person class can access them.
         */
        public string Model { get; set; }
        public int Speed { get; set; }
    }
}