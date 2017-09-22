using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Represents a Nation that contains Benders and Monuments
// and calculates total elemental power using composition.
public class Nation
{
    // Encapsulation:
    // Internal collections storing domain objects
    private List<Bender> benders;
    private List<Monument> monuments;

    // Type of the nation (Air, Water, Fire, Earth)
    private string nationType;

    // Constructor initializes empty collections and assigns type
    public Nation(string type)
    {
        this.Benders = new List<Bender>();
        this.Monuments = new List<Monument>();
        this.nationType = type;
    }

    // List of Benders in the nation
    public List<Bender> Benders
    {
        get { return this.benders; }
        private set { this.benders = value; }
    }

    // List of Monuments in the nation
    public List<Monument> Monuments
    {
        get { return this.monuments; }
        private set { this.monuments = value; }
    }

    // Computed property:
    // Base power of nation from all benders
    public double NationsBenderPower
        => this.CalculateNationsPower();

    // Computed property:
    // Total power including monument bonuses
    public double NationsTotalPower
        => this.CalculateNationsTotalPowerWithMonuments();

    // Calculates total power from all benders (aggregation)
    private double CalculateNationsPower()
    {
        return this.Benders.Sum(b => b.GetBenderTotalPower());
    }

    // Calculates final power after applying monument affinity bonus
    private double CalculateNationsTotalPowerWithMonuments()
    {
        int increase = this.Monuments.Sum(m => m.GetAffinity());

        // Percentage-based boost from monuments
        return ((this.NationsBenderPower / 100) * increase) + this.NationsBenderPower;
    }

    // String representation of Nation state
    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{this.nationType} Nation");

        // Benders section
        if (this.Benders.Count > 0)
        {
            sb.AppendLine("Benders:");
            foreach (var b in this.Benders)
            {
                sb.AppendLine($"###{b}");
            }
        }
        else
        {
            sb.AppendLine("Benders: None");
        }

        // Monuments section
        if (this.Monuments.Count > 0)
        {
            sb.AppendLine("Monuments:");
            foreach (var m in this.Monuments)
            {
                sb.AppendLine($"###{m}");
            }
        }
        else
        {
            sb.AppendLine("Monuments: None");
        }

        return sb.ToString();
    }
}