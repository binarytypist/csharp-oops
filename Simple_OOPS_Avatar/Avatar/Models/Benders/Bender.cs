using System;

// Abstraction:
// Bender is the base abstract class that defines common structure for all elemental benders.
public abstract class Bender
{
    // Encapsulation:
    // Common properties shared by all benders are hidden from external modification
    private string name;
    private int power;

    // Constructor initializes shared bender state
    public Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    // Base power of the bender (used in all derived calculations)
    public int Power
    {
        get { return this.power; }
        protected set { this.power = value; }
    }

    // Name of the bender (identity)
    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }

    // Polymorphism (abstract method):
    // Each elemental bender must define how total power is calculated
    public abstract double GetBenderTotalPower();
}