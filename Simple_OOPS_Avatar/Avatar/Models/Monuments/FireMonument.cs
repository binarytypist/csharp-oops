using System;
using System.Text;

// Inheritance:
// FireMonument is a specialized Monument that contributes to Fire nation strength.
public class FireMonument : Monument
{
    // Encapsulation:
    // Stores fire-specific affinity value
    private int fireAffinity;

    // Constructor:
    // Initializes base Monument class and sets Fire affinity value
    public FireMonument(string name, int fireAffinity)
        : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    // Property:
    // Provides controlled access to fireAffinity field
    public int FireAffinity
    {
        get => this.fireAffinity;
        set => this.fireAffinity = value;
    }

    // Polymorphism:
    // Each Monument type defines its own affinity calculation logic
    public override int GetAffinity()
    {
        return this.FireAffinity;
    }

    // Object representation:
    // Used when printing FireMonument details
    public override string ToString()
    {
        return $"Fire Monument: {this.Name}, Fire Affinity: {this.FireAffinity}";
    }
}