using System;

// Inheritance:
// DriftRace is a specialized type of Race that focuses on handling and control.
public class DriftRace : Race
{
    // Constructor passes shared race data to the base Race class
    public DriftRace(int length, string route, int prizePool)
        : base(length, route, prizePool)
    {
    }

    // Polymorphism:
    // Each race type defines its own performance scoring logic.
    public override int GetPerformancePoints(Car car)
    {
        // Drift race focuses on control rather than speed:
        // Suspension represents handling ability
        // Durability represents stability under stress
        return car.Suspension + car.Durability;
    }
}