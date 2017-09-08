using System.Collections.Generic;
using System.Linq;

public class Car
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This class represents a Car entity in an OOP system.
     *
     * OOP CONCEPTS USED:
     * - Encapsulation (data is wrapped inside class properties)
     * - Composition (Car HAS Engine, Cargo, Tires)
     * - Object aggregation (objects are passed into constructor)
     * - Real-world modeling (car structure simulation)
     */

    /*
     * CONSTRUCTOR:
     * ------------
     * Initializes a Car object with:
     * - Model (basic identity)
     * - Engine (performance component)
     * - Cargo (load information)
     * - Tires (collection of tire objects)
     *
     * IMPORTANT FIX:
     * We only take 4 tires because a car logically has 4 wheels.
     */
    public Car(string model, Engine engine, Cargo cargo, ICollection<Tire> tires)
    {
        this.Model = model;                 // car identity (name/model)
        this.Engine = engine;               // HAS-A relationship (Engine object)
        this.Cargo = cargo;                 // HAS-A relationship (Cargo object)

        // COMPOSITION:
        // We ensure only 4 tires are assigned (real-world constraint)
        this.Tires = new List<Tire>(tires.Take(4));
    }

    /*
     * PROPERTIES:
     * -----------
     * These define the STATE of the Car object.
     * This is ENCAPSULATION → data is stored inside object safely.
     */

    public string Model { get; set; }       // car model name
    public Engine Engine { get; set; }      // engine component (HAS-A)
    public Cargo Cargo { get; set; }        // cargo component (HAS-A)
    public ICollection<Tire> Tires { get; set; } // collection (HAS-MANY)
}