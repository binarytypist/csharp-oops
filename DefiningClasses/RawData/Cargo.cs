public class Cargo
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This class represents the Cargo component of a Car.
     *
     * OOP CONCEPTS USED:
     * - Encapsulation (data is stored inside a class)
     * - Composition (Car HAS-A Cargo)
     * - Real-world modeling (cargo = load in a vehicle)
     */

    /*
     * CONSTRUCTOR:
     * ------------
     * Used to initialize Cargo object with required values.
     * Ensures object is always created in a valid state.
     */
    public Cargo(int weight, string type)
    {
        this.Weight = weight;   // weight of the cargo (state of object)
        this.Type = type;       // type of cargo (fragile, flammable, etc.)
    }

    /*
     * PROPERTIES:
     * -----------
     * This is ENCAPSULATION → data is protected inside the class
     * and accessed through properties.
     */

    public int Weight { get; set; }   // cargo weight (numeric state)
    public string Type { get; set; }   // cargo type/category
}