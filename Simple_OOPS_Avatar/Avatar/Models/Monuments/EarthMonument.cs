using System;
using System.Text;

// Inheritance:
// EarthMonument is a specialized Monument that contributes to Earth nation strength.
public class EarthMonument : Monument
{
    // Encapsulation:
    // Stores earth-specific affinity value
    private int earthAffinity;

    // Constructor:
    // Initializes base Monument class and sets Earth affinity value
    public EarthMonument(string name, int earthAffinity) : base(name)
    {
        this.EarthAffinity = earthAffinity;
    }

    // Property:
    // Provides controlled access to earthAffinity field
    public int EarthAffinity
    {
        get { return this.earthAffinity; }
        set { this.earthAffinity = value; }
    }

    // Polymorphism:
    // Each Monument type defines its own affinity calculation logic
    public override int GetAffinity()
    {
        return this.EarthAffinity;
    }

    // Object representation:
    // Used when printing EarthMonument details
    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.Append($"Earth Monument: {this.Name}, Earth Affinity: {this.EarthAffinity}");

        return sb.ToString();
    }
}