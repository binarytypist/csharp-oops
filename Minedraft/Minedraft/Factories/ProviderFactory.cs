using System;
using System.Collections.Generic;

public class ProviderFactory
{

    // Creates and returns a Provider based on input arguments
    // Expected arguments: [type, id, energyOutput]
    
    public Provider Get(List<string> arguments)
    {
        // Validate input arguments
       string type = arguments[0];
        string id = arguments[1];
        double energyOutput = double.Parse(arguments[2]);

        // Type can be "Solar" or "Pressure" 
        // If type is unknown, an ArgumentException is thrown
        switch (type)
        {
            case "Solar":
                return new SolarProvider(id, energyOutput);

            case "Pressure":
                return new PressureProvider(id, energyOutput);

            default:
                throw new ArgumentException("Provider creation error.");
        }
    }
}