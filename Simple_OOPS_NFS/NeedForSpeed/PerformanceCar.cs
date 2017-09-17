using System;
using System.Collections.Generic;

// Inheritance:
// PerformanceCar is a specialized Car with boosted performance stats and extra features (add-ons).
public class PerformanceCar : Car
{
    // Encapsulation:
    // Stores tuning add-ons applied to the car
    private IList<string> addOns;

    // Constructor:
    // Applies performance modifications immediately by increasing horsepower and reducing suspension
    public PerformanceCar(
        string brand,
        string model,
        int yearOfProduction,
        int horsePower,
        int acceleration,
        int suspension,
        int durability)
        : base(
            brand,
            model,
            yearOfProduction,
            // Performance boost: increase horsepower by 50%
            (horsePower * 150) / 100,
            acceleration,
            // Performance trade-off: reduce suspension by 25%
            (suspension * 75) / 100,
            durability)
    {
        // Initialize collection of add-ons
        this.AddOns = new List<string>();
    }

    // Encapsulated list of performance modifications
    public IList<string> AddOns
    {
        get { return this.addOns; }
        set { this.addOns = value; }
    }

    // Polymorphism:
    // Overrides base tuning logic and extends behavior
    public override void Tune(int tuneIndex, string addOn)
    {
        // Apply base tuning (horsepower and suspension changes)
        base.Tune(tuneIndex, addOn);

        // Extend behavior: store visual/functional upgrade
        this.AddOns.Add(addOn);
    }

    // Object representation of PerformanceCar
    public override string ToString()
    {
        string result = base.ToString();

        // Display additional performance features
        result += "Add-ons: ";

        if (this.AddOns.Count <= 0)
        {
            result += "None";
        }
        else
        {
            result += string.Join(", ", this.AddOns);
        }

        return result;
    }
}