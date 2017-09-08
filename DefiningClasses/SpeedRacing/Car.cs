using System;

public class Car
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This class represents a Car in a simple simulation system.
     *
     * OOP CONCEPTS USED:
     * - Encapsulation (data + behavior inside one class)
     * - State management (fuel changes over time)
     * - Behavior methods (TryExecuteTrip)
     * - Real-world modeling (car driving simulation)
     */

    /*
     * CONSTRUCTOR:
     * ------------
     * Initializes a Car object with starting values.
     * Ensures the object always begins in a valid state.
     */
    public Car(string model, double fuelAmount, double fuelCons)
    {
        this.Model = model;               // car identity
        this.FuelAmount = fuelAmount;     // current fuel in tank
        this.FuelConsumption = fuelCons;  // fuel used per km
        this.DistanceTraveled = 0;        // initially no driving
    }

    /*
     * PROPERTIES:
     * -----------
     * Encapsulation: internal state is stored safely inside object
     */

    public string Model { get; set; }            // car model name
    public double FuelAmount { get; set; }       // current fuel level
    public double FuelConsumption { get; set; }  // fuel per km
    public long DistanceTraveled { get; set; }   // total distance driven

    /*
     * METHOD: TryExecuteTrip
     * ----------------------
     * This method simulates driving the car.
     *
     * OOP CONCEPT:
     * - Object behavior (car performs an action)
     * - State change (fuel decreases, distance increases)
     * - Encapsulation (logic inside class)
     */
    public void TryExecuteTrip(int kilometers)
    {
        double fuelNeeded = kilometers * FuelConsumption;

        // CHECK if enough fuel exists
        if (this.FuelAmount - fuelNeeded >= 0D)
        {
            this.FuelAmount -= fuelNeeded;   // reduce fuel
            this.DistanceTraveled += kilometers; // increase distance
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}

/*
 * DUMMY DATA (NO READLINE)
 * ------------------------
 * Example usage:
 *
 * Car car = new Car("BMW", 50, 0.5);
 * car.TryExecuteTrip(50);
 * car.TryExecuteTrip(30);
 *
 * Console.WriteLine(car.Model);
 * Console.WriteLine(car.FuelAmount);
 * Console.WriteLine(car.DistanceTraveled);
 *
 * This shows how object state changes over time.
 */