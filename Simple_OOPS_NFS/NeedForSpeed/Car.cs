using System;
using System.Text;

// Abstract base class:
// Cannot be instantiated directly.
// Provides common properties and behavior for all car types.
public abstract class Car
{
    // Encapsulation: internal state is hidden using private fields
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsePower;
    private int acceleration;
    private int suspension;
    private int durability;

    // Constructor initializes all required car data
    public Car(
        string brand,
        string model,
        int yearOfProduction,
        int horsePower,
        int acceleration,
        int suspension,
        int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.HorsePower = horsePower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }

    // Property exposes durability
    public int Durability
    {
        get { return this.durability; }
        set { this.durability = value; }
    }

    // Property exposes suspension value
    public int Suspension
    {
        get { return this.suspension; }
        set { this.suspension = value; }
    }

    // Protected setter:
    // Derived classes can modify acceleration,
    // but external classes cannot.
    public int Acceleration
    {
        get { return this.acceleration; }
        protected set { this.acceleration = value; }
    }

    // Horsepower can be modified by tuning or derived classes
    public int HorsePower
    {
        get { return this.horsePower; }
        set { this.horsePower = value; }
    }

    // Production year should not change from outside
    public int YearOfProduction
    {
        get { return this.yearOfProduction; }
        protected set { this.yearOfProduction = value; }
    }

    // Model should only be set during creation or inheritance logic
    public string Model
    {
        get { return this.model; }
        protected set { this.model = value; }
    }

    // Brand should only be set during creation or inheritance logic
    public string Brand
    {
        get { return this.brand; }
        protected set { this.brand = value; }
    }

    // Virtual method demonstrates polymorphism.
    // Derived classes can override and customize tuning behavior.
    public virtual void Tune(int tuneIndex, string addOn)
    {
        // Increase horsepower
        this.HorsePower += tuneIndex;

        // Improve suspension
        this.Suspension += (tuneIndex / 2);
    }

    // Provides formatted representation of a car
    // Can also be overridden by derived classes if needed.
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        // Basic car information
        sb.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}");

        // Performance information
        sb.AppendLine($"{this.HorsePower} HP, 100 m/h in {this.Acceleration} s");

        // Mechanical condition
        sb.AppendLine($"{this.Suspension} Suspension force, {this.Durability} Durability");

        return sb.ToString();
    }
}