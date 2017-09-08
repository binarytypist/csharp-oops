public class Engine
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This class represents the Engine component of a Car system.
     *
     * OOP CONCEPTS USED:
     * - Encapsulation (data is stored inside the class)
     * - Composition (Car HAS-A Engine)
     * - Real-world modeling (engine as a physical component)
     */

    /*
     * CONSTRUCTOR:
     * ------------
     * Used to initialize Engine object with required values.
     * Ensures the object is always created in a valid state.
     */
    public Engine(int speed, int power)
    {
        this.Speed = speed;   // engine speed (performance attribute)
        this.Power = power;   // engine power (strength attribute)
    }

    /*
     * PROPERTIES:
     * -----------
     * This is ENCAPSULATION → internal state is stored safely
     * and accessed through controlled properties.
     */

    public int Speed { get; set; }  // engine speed value
    public int Power { get; set; }  // engine power value
}