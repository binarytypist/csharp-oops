using System;
using System.Collections.Generic;
using System.Linq;

// NationsBuilder acts as a central controller for managing all nations,
// their benders, monuments, and war logic.
public class NationsBuilder
{
    // Encapsulation:
    // Each Nation is kept private to prevent external manipulation.
    private Nation airNation;
    private Nation waterNation;
    private Nation fireNation;
    private Nation earthNation;

    // Records all war events in chronological order
    private List<string> records;

    // Constructor initializes all nations and war history storage
    public NationsBuilder()
    {
        this.airNation = new Nation("Air");
        this.waterNation = new Nation("Water");
        this.fireNation = new Nation("Fire");
        this.earthNation = new Nation("Earth");

        this.records = new List<string>();
    }

    // Assigns a bender to the correct nation based on type
    public void AssignBender(List<string> benderArgs)
    {
        string type = benderArgs[0];
        string name = benderArgs[1];
        int power = int.Parse(benderArgs[2]);
        double specialParam = double.Parse(benderArgs[3]);

        switch (type)
        {
            case "Air":
                this.airNation.Benders.Add(new AirBender(name, power, specialParam));
                break;

            case "Water":
                this.waterNation.Benders.Add(new WaterBender(name, power, specialParam));
                break;

            case "Fire":
                this.fireNation.Benders.Add(new FireBender(name, power, specialParam));
                break;

            case "Earth":
                this.earthNation.Benders.Add(new EarthBender(name, power, specialParam));
                break;
        }
    }

    // Assigns a monument to the correct nation
    public void AssignMonument(List<string> monumentArgs)
    {
        string type = monumentArgs[0];
        string name = monumentArgs[1];
        int affinity = int.Parse(monumentArgs[2]);

        switch (type)
        {
            case "Air":
                this.airNation.Monuments.Add(new AirMonument(name, affinity));
                break;

            case "Water":
                this.waterNation.Monuments.Add(new WaterMonument(name, affinity));
                break;

            case "Fire":
                this.fireNation.Monuments.Add(new FireMonument(name, affinity));
                break;

            case "Earth":
                this.earthNation.Monuments.Add(new EarthMonument(name, affinity));
                break;
        }
    }

    // Returns status of a specific nation
    public string GetStatus(string nationsType)
    {
        switch (nationsType)
        {
            case "Air":
                return this.airNation.ToString();

            case "Water":
                return this.waterNation.ToString();

            case "Fire":
                return this.fireNation.ToString();

            case "Earth":
                return this.earthNation.ToString();

            default:
                throw new ArgumentException("Invalid nation type!");
        }
    }

    // War system:
    // Determines the strongest nation and eliminates others
    public void IssueWar(string nationsType)
    {
        // Collect all nations for comparison
        List<Nation> nationsAtWar = new List<Nation>
        {
            this.airNation,
            this.waterNation,
            this.fireNation,
            this.earthNation
        };

        // Determine strongest nation based on total power
        var strongest = nationsAtWar
            .OrderByDescending(n => n.NationsTotalPower)
            .First();

        // Eliminate all losing nations
        foreach (var nation in nationsAtWar)
        {
            if (nation != strongest)
            {
                nation.Benders.Clear();
                nation.Monuments.Clear();
            }
        }

        // Record war event
        this.records.Add($"War {this.records.Count + 1} issued by {nationsType}");
    }

    // Returns full war history
    public string GetWarsRecord()
    {
        return string.Join(Environment.NewLine, this.records);
    }
}