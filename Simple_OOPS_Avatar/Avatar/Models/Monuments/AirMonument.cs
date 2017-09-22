using System;
using System.Text;

// Inheritance:
// AirMonument is a specialized Monument that contributes to Air nation strength.
public class AirMonument : Monument
{
    // Encapsulation:
    // Stores air-specific affinity value
    private int airAffinity;

    // Constructor:
    // Initializes base Monument class and sets Air affinity value
    public AirMonument(string name, int airAffinity) : base(name)
    {
        this.AirAffinity = airAffinity;
    }

    // Property:
    // Provides controlled access to airAffinity field
    public int AirAffinity
    {
        get { return this.airAffinity; }
        set { this.airAffinity = value; }
    }

    // Polymorphism:
    // Each Monument type defines its own way of calculating affinity
    public override int GetAffinity()
    {
        return this.AirAffinity;
    }

    // Object representation:
    // Used when printing AirMonument details
    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.Append($"Air Monument: {this.Name}, Air Affinity: {this.AirAffinity}");

        return sb.ToString();
    }
}