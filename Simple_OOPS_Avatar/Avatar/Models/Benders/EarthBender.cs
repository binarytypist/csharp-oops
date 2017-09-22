using System;
using System.Text;

// Inheritance:
// EarthBender is a specialized type of Bender that uses ground saturation in its power calculation.
public class EarthBender : Bender
{
    // Encapsulation:
    // Earth-specific attribute affecting total power
    private double groundSaturation;

    // Constructor initializes base Bender properties and earth-specific property
    public EarthBender(string name, int power, double groundSaturation)
        : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    // Property controlling access to ground saturation value
    public double GroundSaturation
    {
        get { return this.groundSaturation; }
        set { this.groundSaturation = value; }
    }

    // Polymorphism:
    // Each bender type implements its own power calculation logic
    public override double GetBenderTotalPower()
    {
        // Earth benders rely on stability and terrain influence
        return this.Power * this.GroundSaturation;
    }

    // Object representation of EarthBender
    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.Append(
            $"Earth Bender: {this.Name}, " +
            $"Power: {this.Power}, " +
            $"Ground Saturation: {this.GroundSaturation:F2}");

        return sb.ToString();
    }
}