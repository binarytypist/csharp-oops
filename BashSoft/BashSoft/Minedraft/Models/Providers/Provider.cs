using System;


// The Provider class is an abstract base class that represents a generic energy provider in the Minedraft system. 
// It inherits from the Machine class and defines a property called EnergyOutput, which represents the amount of energy the
// provider can produce in a day.
// The Provider class is designed to be inherited by specific types of providers, such as SolarProvider and PressureProvider, which can have additional
// properties and behaviors specific to their type.

public abstract class Provider : Machine
{

    private double energyOutput;

    // The Provider class has a constructor that takes an id and energyOutput as parameters. The id is passed to the base Machine class constructor,
    // while the energyOutput is set using the property, which includes validation logic to ensure that the value is within an acceptable range.
    // If the value is invalid, an ArgumentException is thrown with a message indicating that the provider cannot be registered due to its EnergyOutput.
    // The Provider class serves as a base for all provider types in the Minedraft system, providing common functionality and enforcing a consistent interface for all providers.

    public Provider(string id, double energyOutput) : base(id)
    {
        this.EnergyOutput = energyOutput;
    }


    // The EnergyOutput property has a getter and a protected setter. The setter includes validation to ensure that the energy output is between 0 and 10000.
    // If the value is invalid, an ArgumentException is thrown with a message indicating that the provider cannot be registered due to its EnergyOutput.
    // The EnergyOutput property represents the amount of energy the provider can produce in a day. It is a crucial property for determining the productivity of the provider and its contribution to the overall energy resources in the Minedraft system.
    // The EnergyOutput property has a getter and a protected setter. The setter includes validation to ensure that the energy output is between 0 and 10000.

    public double EnergyOutput
    {
        get { return this.energyOutput; }
        protected set
        {
            if (value <= 0 || value >= 10000)
            {
                throw new ArgumentException($"Provider is not registered, because of it's EnergyOutput");
            }

            this.energyOutput = value;
        }
    }
}