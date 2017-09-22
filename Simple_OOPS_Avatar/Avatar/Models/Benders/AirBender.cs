using System;
using System.Text;

// Inheritance:
// AirBender is a specialized type of Bender with air-specific power calculation.
public class AirBender : Bender
{
    // Encapsulation:
    // AerialIntegrity is a unique attribute for AirBender
    private double aerialIntegrity;

    // Constructor initializes base Bender properties and air-specific property
    public AirBender(string name, int power, double aerialIntegrity)
        : base(name, power)
    {
        this.AerialIntegrity = aerialIntegrity;
    }

    // Property controlling access to aerial integrity value
    public double AerialIntegrity
    {
        get { return this.aerialIntegrity; }
        set { this.aerialIntegrity = value; }
    }

    // Polymorphism:
    // Each bender type calculates total power differently
    public override double GetBenderTotalPower()
    {
        // Air benders depend on both base power and aerial integrity
        return this.Power * this.AerialIntegrity;
    }

    // Object representation of AirBender
    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.Append(
            $"Air Bender: {this.Name}, " +
            $"Power: {this.Power}, " +
            $"Aerial Integrity: {this.AerialIntegrity:F2}");

        return sb.ToString();
    }
}