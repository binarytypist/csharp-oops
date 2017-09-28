// =======================
// DERIVED CLASS (CHILD)
// =======================

// Cat inherits from Animal
// This means Cat automatically gets Eat() method
using System;

public class Cat : Animal
{
    // Cat-specific behavior
    public void Meow()
    {
        Console.WriteLine("meowing...");
    }
}