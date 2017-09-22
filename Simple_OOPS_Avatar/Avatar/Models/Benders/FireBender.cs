using System;
using System.Text;

// Inheritance:
// FireBender is a specialized Bender that uses heat aggression in its power calculation.
public class FireBender : Bender
{
    // Encapsulation:
    // Fire-specific attribute affecting total power output
    private double heatAggression;

    // Constructor initializes base Bender and fire-specific value
    public FireBender(string name, int power, double heatAggression)
        : base(name, power)
    {
        this.HeatAggression = heatAggression;
    }

    // Property controlling access to heat aggression value
    public double HeatAggression
    {
        get { return this.heatAggression; }
        set { this.heatAggression = value; }
    }

    // Polymorphism:
    // Fire benders calculate power differently from other benders
    public override double GetBenderTotalPower()
    {
        // Fire power depends on base power multiplied by heat aggression factor
        return this.Power * this.HeatAggression;
    }

    // Object representation of FireBender
    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.Append(
            $"Fire Bender: {this.Name}, " +
            $"Power: {this.Power}, " +
            $"Heat Aggression: {this.HeatAggression:F2}");

        return sb.ToString();
    }
}