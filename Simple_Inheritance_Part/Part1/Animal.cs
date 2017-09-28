
// =======================
// BASE CLASS (PARENT)
// =======================

// Animal is the base class (superclass)
// It contains common behavior shared by all animals
using System;

public class Animal
{
    // Common method inherited by all derived classes
    public void Eat()
    {
        Console.WriteLine("eating...");
    }
}