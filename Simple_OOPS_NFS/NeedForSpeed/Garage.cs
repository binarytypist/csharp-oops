using System;
using System.Collections.Generic;

// Garage class:
// Responsible for storing cars that are not participating in races.
// Demonstrates composition in the CarManager system.
public class Garage
{
    // Encapsulation:
    // HashSet prevents duplicate parked cars automatically
    private HashSet<Car> parkedCars;

    // Constructor initializes the internal collection
    public Garage()
    {
        this.ParkedCars = new HashSet<Car>();
    }

    // Exposes parked cars collection in a controlled way
    // External classes can read and modify the collection,
    // but cannot replace it entirely (private set)
    public HashSet<Car> ParkedCars
    {
        get { return this.parkedCars; }
        private set { this.parkedCars = value; }
    }
}