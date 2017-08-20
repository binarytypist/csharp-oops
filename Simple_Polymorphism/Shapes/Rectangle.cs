// Rectangle IS-A Shape
// Shows polymorphic behavior with different formulas
public class Rectangle : Shape
{
    private double height;
    private double width;

    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }

    // Encapsulation for height
    public double Height
    {
        get { return this.height; }
        private set { this.height = value; }
    }

    // Encapsulation for width
    public double Width
    {
        get { return this.width; }
        private set { this.width = value; }
    }

    // Area = height × width
    public override double CalculateArea()
    {
        return this.Height * this.Width;
    }

    // Perimeter = 2(h + w)
    public override double CalculatePerimeter()
    {
        return 2 * (this.Height + this.Width);
    }

    // Polymorphic draw behavior
    public override string Draw()
    {
        return base.Draw() + this.GetType().Name;
    }
}