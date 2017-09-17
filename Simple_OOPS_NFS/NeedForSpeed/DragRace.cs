using System;

// Inheritance:
// DragRace extends the base Race class and represents a short straight-line race type.
public class DragRace : Race
{
    // Constructor forwards shared race data to base class
    public DragRace(int length, string route, int prizePool)
        : base(length, route, prizePool)
    {
    }

    // Polymorphism:
    // Each race type defines its own performance scoring logic.
    public override int GetPerformancePoints(Car car)
    {
        // Drag race focuses only on raw speed:
        // HorsePower divided by Acceleration represents quick acceleration performance
        return car.HorsePower / car.Acceleration;
    }
}