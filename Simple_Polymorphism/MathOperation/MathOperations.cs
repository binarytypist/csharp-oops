// This class demonstrates METHOD OVERLOADING in OOP
// Method overloading = same method name, different parameters (type/number)
public class MathOperations
{
    // Adds two integers
    public int Add(int a, int b)
    {
        return a + b; // simple integer addition
    }

    // Adds three double values
    // Different parameter count + different type (double)
    public double Add(double a, double b, double c)
    {
        return a + b + c; // floating-point addition
    }

    // Adds three decimal values (used for financial precision)
    // Different type again (decimal is more precise than double)
    public decimal Add(decimal a, decimal b, decimal c)
    {
        return a + b + c; // decimal addition
    }
}