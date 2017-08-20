// Circle IS-A Shape
// “IS-A” is a simple way to describe inheritance in OOP.
// IS-A means: one class is a type of another class
// Demonstrates INHERITANCE + METHOD OVERRIDING
using System;

public class Circle : Shape
{
    private double radius; // encapsulated field

    public Circle(double radius)
    {
        this.Radius = radius;
    }

    // Encapsulation: controlled access to radius
    public double Radius
    {
        get { return this.radius; }
        private set { this.radius = value; }
    }

    // Area formula: πr²
    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(this.Radius, 2);
    }

    // Perimeter formula: 2πr
    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * this.Radius;
    }

    // Override Draw to show polymorphism
    public override string Draw()
    {
        return base.Draw() + this.GetType().Name;
    }
}