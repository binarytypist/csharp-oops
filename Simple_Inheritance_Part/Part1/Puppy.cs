using System;


// Puppy inherits from Dog
// This shows MULTI-LEVEL INHERITANCE:
// Animal → Dog → Puppy
public class Puppy : Dog
{
    // Puppy-specific behavior
    public void Weep()
    {
        Console.WriteLine("weeping...");
    }
}