using System;

// Inheritance:
// ShowCar is a specialized Car used for exhibitions rather than racing performance.
public class ShowCar : Car
{
    // Encapsulation:
    // Stars represent the car's exhibition rating (visual appeal / tuning level)
    private int stars;

    // Property for accessing star rating
    public int Stars
    {
        get { return this.stars; }
        set { this.stars = value; }
    }

    // Constructor initializes base Car properties and sets initial stars to 0
    public ShowCar(
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
            horsePower,
            acceleration,
            suspension,
            durability)
    {
        this.Stars = 0;
    }

    // Polymorphism:
    // Overrides tuning behavior to reflect visual enhancements instead of performance changes
    public override void Tune(int tuneIndex, string addOn)
    {
        // Apply base tuning logic (performance adjustments)
        base.Tune(tuneIndex, addOn);

        // Show-specific behavior: increase star rating
        this.Stars += tuneIndex;
    }

    // Object representation of ShowCar
    public override string ToString()
    {
        var result = base.ToString();

        // Append exhibition rating
        result += $"{this.Stars} *";

        return result;
    }
}