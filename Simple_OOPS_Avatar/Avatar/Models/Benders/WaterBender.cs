using System;
using System.Text;

// Inheritance:
// WaterBender extends the base Bender class and adds water-specific behavior.
public class WaterBender : Bender
{
    // Encapsulation:
    // Water-specific attribute that influences total power calculation
    private double waterClarity;

    // Constructor initializes base properties and water-specific value
    public WaterBender(string name, int power, double waterClarity)
        : base(name, power)
    {
        this.WaterClarity = waterClarity;
    }

    // Property controlling access to water clarity
    public double WaterClarity
    {
        get { return this.waterClarity; }
        set { this.waterClarity = value; }
    }

    // Polymorphism:
    // Each bender type defines its own power calculation logic
    public override double GetBenderTotalPower()
    {
        // Water benders depend on clarity and flow efficiency
        return this.Power * this.WaterClarity;
    }

    // String representation of the WaterBender object
    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.Append(
            $"Water Bender: {this.Name}, " +
            $"Power: {this.Power}, " +
            $"Water Clarity: {this.WaterClarity:F2}");

        return sb.ToString();
    }
}