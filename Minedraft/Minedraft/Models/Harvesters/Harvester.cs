using System;


// The Harvester class is an abstract class that represents a mining machine in the
// Minedraft system. It inherits from the Machine class and defines
public abstract class Harvester : Machine
{
    // The Harvester class has two main properties: OreOutput and EnergyRequirement.
    // OreOutput represents the amount of ore the harvester can produce in a day, while EnergyRequirement
    // represents the amount of energy it consumes.
    private double oreOutput;
    private double energyRequirement;


    // The constructor of the Harvester class takes three parameters: id, oreOutput, and energyRequirement.
    // The id is passed to the base Machine class constructor
    // The oreOutput and energyRequirement are set using the properties, which include validation logic to
    // ensure that the values are within acceptable ranges. If the values are invalid, an ArgumentException is thrown.
    // The Harvester class is designed to be inherited by specific types of harvesters, such as SonicHarvester and HammerHarvester,
    // which can have additional properties and behaviors specific to their type.
    // The Harvester class serves as a base for all harvester types in the Minedraft system, providing common functionality
    // and enforcing a consistent interface for all harvesters.
    public Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }


    // The OreOutput property has a getter and a protected setter. The setter includes validation to ensure that the ore output is not negative.
    // If the value is invalid, an ArgumentException is thrown with a message indicating that the harvester cannot be registered due to its OreOutput.
    // The EnergyRequirement property also has a getter and a protected setter. The setter includes validation to ensure that the energy requirement
    // is between 0 and 20000. If the value is invalid, an ArgumentException is thrown with a message indicating that the harvester cannot be registered
    // due to its EnergyRequirement.

    public double EnergyRequirement
    {

        // The EnergyRequirement property has a getter and a protected setter. The setter includes validation to ensure that the energy requirement
        // is between 0 and 20000. If the value is invalid, an ArgumentException is thrown with a message indicating that the harvester cannot be
        // registered
        get { return this.energyRequirement; }

        // The setter for the EnergyRequirement property includes validation logic to ensure that the value is within the acceptable range of 0 to 20000.
        // If the value is less than 0 or greater than 20000, an ArgumentException is thrown with a message indicating that the harvester cannot be
        // registered due to its EnergyRequirement.
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's EnergyRequirement");
            }

            this.energyRequirement = value;
        }
    }

    // The OreOutput property has a getter and a protected setter. The setter includes validation to ensure that the ore output is not negative.
    // If the value is invalid, an ArgumentException is thrown with a message indicating that the harvester cannot be registered due to its OreOutput.
    // The OreOutput property represents the amount of ore the harvester can produce in a day. It is a crucial property for determining the productivity of the harvester.
    // The setter for the OreOutput property includes validation logic to ensure that the value is not negative. If the value is less than 0, an ArgumentException is thrown with a message indicating
    // that the harvester cannot be registered due to its OreOutput.
    public double OreOutput
    {
        // The OreOutput property represents the amount of ore the harvester can produce in a day.
        // It is a crucial property for determining the productivity of the harvester.
        get { return this.oreOutput; }

        // The setter for the OreOutput property includes validation logic to ensure that the value is not negative. If the value is less than 0, an ArgumentException is thrown with a message indicating that the
        // harvester cannot be registered due to its OreOutput.

       protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's OreOutput");
            }

            this.oreOutput = value;
        }
    }
}