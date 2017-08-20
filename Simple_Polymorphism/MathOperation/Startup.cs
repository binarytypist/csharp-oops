using System;

class Startup
{
    private static void Main(string[] args)
    {
        // Create instance of MathOperations class
        MathOperations mo = new MathOperations();

        // Calls Add(int, int)
        Console.WriteLine(mo.Add(2, 3));

        // Calls Add(double, double, double)
        Console.WriteLine(mo.Add(2.2, 3.3, 5.5));

        // Calls Add(decimal, decimal, decimal)
        Console.WriteLine(mo.Add(2.2m, 3.3m, 4.4m));
    }
}