using System;

// Inheritance:
// CasualRace derives from the base Race class and inherits
// common race properties such as Length, Route, PrizePool, and Participants.
public class CasualRace : Race
{
    // Constructor passes race information to the base class
    public CasualRace(int length, string route, int prizePool)
        : base(length, route, prizePool)
    {
    }

    // Polymorphism:
    // Overrides the abstract/virtual method from Race.
    // Each race type calculates performance points differently.
    public override int GetPerformancePoints(Car car)
    {
        // Casual race scoring formula:
        // - HorsePower / Acceleration measures performance
        // - Suspension contributes to handling
        // - Durability contributes to reliability
        return (car.HorsePower / car.Acceleration)
               + car.Suspension
               + car.Durability;
    }
}