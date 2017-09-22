using System;
using System.Text;

// Inheritance:
// WaterMonument is a specialized Monument that contributes to Water nation strength.
public class WaterMonument : Monument
{
    // Encapsulation:
    // Stores water-specific affinity value
    private int waterAffinity;

    // Constructor:
    // Initializes base Monument class and sets Water affinity value
    public WaterMonument(string name, int waterAffinity) : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }

    // Property:
    // Provides controlled access to waterAffinity field
    public int WaterAffinity
    {
        get { return this.waterAffinity; }
        set { this.waterAffinity = value; }
    }

    // Polymorphism:
    // Each Monument type defines its own affinity calculation logic
    public override int GetAffinity()
    {
        return this.WaterAffinity;
    }

    // Object representation:
    // Used when printing WaterMonument details
    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.Append($"Water Monument: {this.Name}, Water Affinity: {this.WaterAffinity}");

        return sb.ToString();
    }
}