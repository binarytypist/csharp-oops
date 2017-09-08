using System;
using System.Collections.Generic;

public class HarvesterFactory
{
    // Creates and returns a Harvester based on input arguments
    public Harvester Get(List<string> arguments)
    {
        // First argument defines the type of harvester
        string type = arguments[0];

        // Common properties for all harvesters
        string id = arguments[1];
        double oreOutput = double.Parse(arguments[2]);
        double energyRequirement = double.Parse(arguments[3]);

        switch (type)
        {
            // Sonic harvester requires an additional parameter (fossil factor / sonic factor)
            case "Sonic":
                int sonicFactor = int.Parse(arguments[4]);
                return new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);

            // Hammer harvester uses only base parameters
            case "Hammer":
                return new HammerHarvester(id, oreOutput, energyRequirement);

            // If type is unknown, throw exception
            default:
                throw new ArgumentException("Harvester creation error.");
        }
    }
}