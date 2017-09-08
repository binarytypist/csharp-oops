using System;

class Startup
{
    private static void Main(string[] args)
    {
        // POLYMORPHISM: base type reference, derived objects

        Shape circle = new Circle(5);          // radius = 5
        Shape rectangle = new Rectangle(4, 6); // height = 4, width = 6

        // Circle output
        Console.WriteLine(circle.Draw());
        Console.WriteLine("Area: " + circle.CalculateArea());
        Console.WriteLine("Perimeter: " + circle.CalculatePerimeter());

        Console.WriteLine("----------------------");

        // Rectangle output
        Console.WriteLine(rectangle.Draw());
        Console.WriteLine("Area: " + rectangle.CalculateArea());
        Console.WriteLine("Perimeter: " + rectangle.CalculatePerimeter());
    }
}