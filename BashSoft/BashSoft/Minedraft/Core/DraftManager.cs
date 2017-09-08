using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    // Current operating mode: Full, Half, Energy
    private string currentMode;

    // Stored energy accumulated from providers
    private double totalStoredEnergy;

    // Total mined ore across all days
    private double totalMinedOre;

    // Factories for creating entities
    private readonly HarvesterFactory harvesterFactory;
    private readonly ProviderFactory providerFactory;

    // Registered machines
    private readonly List<Harvester> harvesters;
    private readonly List<Provider> providers;

    public DraftManager()
    {
        this.currentMode = "Full";
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();
    }

    // Registers a new harvester
    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var harvester = this.harvesterFactory.Get(arguments);
            this.harvesters.Add(harvester);
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }

        return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
    }

    // Registers a new provider
    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var provider = this.providerFactory.Get(arguments);
            this.providers.Add(provider);
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }

        return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
    }

    // Simulates a single day of operation
    public string Day()
    {
        // Add energy from all providers
        double energyFromProviders = this.providers.Sum(p => p.EnergyOutput);
        this.totalStoredEnergy += energyFromProviders;

        double oreMinedToday = 0;

        // Pre-calculate harvester stats once
        double totalEnergyNeeded = this.harvesters.Sum(h => h.EnergyRequirement);
        double totalOreOutput = this.harvesters.Sum(h => h.OreOutput);

        switch (this.currentMode)
        {
            case "Full":
                if (this.totalStoredEnergy >= totalEnergyNeeded)
                {
                    oreMinedToday = totalOreOutput;
                    this.totalStoredEnergy -= totalEnergyNeeded;
                }
                break;

            case "Half":
                totalEnergyNeeded *= 0.60;

                if (this.totalStoredEnergy >= totalEnergyNeeded)
                {
                    oreMinedToday = totalOreOutput * 0.50;
                    this.totalStoredEnergy -= totalEnergyNeeded;
                }
                break;

            case "Energy":
                // No ore extraction in Energy mode
                break;
        }

        this.totalMinedOre += oreMinedToday;

        // Build output
        var sb = new StringBuilder();
        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {energyFromProviders}");
        sb.Append($"Plumbus Ore Mined: {oreMinedToday}");

        return sb.ToString();
    }

    // Changes operating mode
    public string Mode(List<string> arguments)
    {
        this.currentMode = arguments[0];
        return $"Successfully changed working mode to {this.currentMode} Mode";
    }

    // Checks details of a harvester or provider by ID
    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        var harvester = this.harvesters.FirstOrDefault(h => h.Id == id);
        if (harvester != null)
        {
            return harvester.ToString();
        }

        var provider = this.providers.FirstOrDefault(p => p.Id == id);
        if (provider != null)
        {
            return provider.ToString();
        }

        return $"No element found with id - {id}";
    }

    // System shutdown summary
    public string ShutDown()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {this.totalStoredEnergy}");
        sb.Append($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return sb.ToString();
    }
}