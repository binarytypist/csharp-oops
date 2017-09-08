using System.Text;

// The SolarProvider class represents a type of energy provider in the Minedraft system. It inherits from the base Provider class and provides a specific
// implementation for solar energy production.
// The SolarProvider class has a constructor that takes an id and energyOutput as parameters. The id is passed to the base Provider class constructor,
// while the energyOutput is set using the base constructor as well.
public class SolarProvider : Provider
{
    // The constructor initializes a new instance of the SolarProvider class with the specified id and energy output.
    // The id is passed to the base Provider class constructor, and the energy output is also set using the base constructor.
    // The SolarProvider class does not have any additional properties or methods beyond what is inherited from the Provider class,
    // but it provides a specific implementation for solar energy production, which can be used in the Minedraft system to manage energy
    // resources effectively.   
    public SolarProvider(string id, double energyOutput) : base(id, energyOutput)
    {
        // The constructor does not contain any additional logic beyond calling the base constructor to initialize the
        // provider with the given id and energy output.
    }


    // The ToString method is overridden to provide a specific string representation for the SolarProvider.
    // The output format includes the type of provider, its ID, and its energy output. This method uses a StringBuilder to
    // construct the output string efficiently.
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Solar Provider - {this.Id}");
        sb.Append($"Energy Output: {this.EnergyOutput}");

        return sb.ToString();
    }
}