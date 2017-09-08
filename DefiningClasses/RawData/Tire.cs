public class Tire
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This class represents a Tire object in a Car system.
     *
     * OOP CONCEPTS USED:
     * - Encapsulation (data stored inside class)
     * - Composition (Car HAS-A Tires)
     * - Real-world modeling (physical car component)
     */

    /*
     * CONSTRUCTOR:
     * ------------
     * Used to initialize Tire object with required values.
     * Ensures object is created in a valid state.
     */
    public Tire(int age, double pressure)
    {
        this.Age = age;           // tire usage age (wear level)
        this.Pressure = pressure; // air pressure (condition state)
    }

    /*
     * PROPERTIES:
     * -----------
     * This is ENCAPSULATION → data is stored inside object
     * and accessed through controlled properties.
     */

    public int Age { get; set; }          // tire age (years or cycles)
    public double Pressure { get; set; }  // tire pressure value
}