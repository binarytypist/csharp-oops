using System;
using System.Text;

// Abstraction:
// Monument is the base abstract class representing a structure that provides
// an affinity bonus to a nation. It cannot be instantiated directly.
public abstract class Monument
{
    // Encapsulation:
    // Stores the monument name privately
    private string name;

    // Constructor:
    // Initializes the common property for all monuments
    public Monument(string name)
    {
        this.Name = name;
    }

    // Property:
    // Provides controlled access to the name field
    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }

    // Polymorphism (Abstract Method):
    // Each derived monument must implement its own affinity logic
    public abstract int GetAffinity();
}