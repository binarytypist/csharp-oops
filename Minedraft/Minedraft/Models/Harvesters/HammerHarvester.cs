using System.Text;

public class HammerHarvester : Harvester
{

    // Hammer Harvester has a unique behavior: it produces 3 times the ore output but consumes double
    // the energy requirement compared to the base values provided during creation.
    // This means that the ore output is calculated as: oreOutput + (oreOutput * 2) = oreOutput * 3
    // And the energy requirement is calculated as: energyRequirement * 2
    // The constructor takes the base values and applies these calculations before passing them to the base Harvester constructor.
    // For example, if the input ore output is 100 and energy requirement is 50:
    // The actual ore output for the Hammer Harvester will be 100 + (100 * 2) = 300
    public HammerHarvester(string id, double oreOutput, double energyRequirement) : base(id, (oreOutput += oreOutput * 2), (energyRequirement * 2))
    {

        // The base constructor is called with the modified ore output and energy requirement values.
    }

    // The ToString method is overridden to provide a specific string representation for the Hammer Harvester.
    public override string ToString()
    {
        //  The string representation of the Hammer Harvester includes its type, ID, ore output, and energy requirement.
        //  The output format is as follows:
        //  Hammer Harvester - {ID}
        //  Ore Output: {OreOutput}
        //  Energy Requirement: {EnergyRequirement}
        //  This method uses a StringBuilder to construct the output string efficiently.
        //  The StringBuilder is used to append each line of the output, and then the final string is returned.
        var sb = new StringBuilder();
        sb.AppendLine($"Hammer Harvester - {this.Id}");
        sb.AppendLine($"Ore Output: {this.OreOutput}");
        sb.Append($"Energy Requirement: {this.EnergyRequirement}");

        return sb.ToString();
    }
}