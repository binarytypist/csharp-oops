// ABSTRACT CLASS = cannot be instantiated directly
// Purpose: define a common contract for all shapes
// Demonstrates ABSTRACTION + POLYMORPHISM
public abstract class Shape
{
    // Every shape MUST implement perimeter calculation
    public abstract double CalculatePerimeter();

    // Every shape MUST implement area calculation
    public abstract double CalculateArea();

    // Virtual method = shared behavior, can be overridden
    public virtual string Draw()
    {
        return "Drawing "; // common prefix for all shapes
    }
}