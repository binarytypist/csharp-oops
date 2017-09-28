
using System;
// Dog inherits from Animal
// Dog can use Eat() + its own methods
public class Dog : Animal
{
    // Dog-specific behavior
    public void Bark()
    {
        Console.WriteLine("barking...");
    }
}