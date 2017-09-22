


// This project simulates the world of Avatar: The Last Airbender where:

// There are 4 nations:
// Air
// Water
// Fire
// Earth

// Each nation contains:

// Benders(people who control an element)
// Monuments(structures that boost nation power)
// Core idea:

// Each nation has a total power, calculated from:

// Benders’ power
// Monument bonuses

// Then nations can:

// Add benders
// Add monuments
// View status
// Go to war
// War rule:

// When a war happens:

// The strongest nation survives
// All other nations lose all benders and monuments

// How the solution works
// Key design principles used:
// Inheritance → Bender types and Monument types share base classes
// Polymorphism → Each bender/monument calculates power differently
// Encapsulation → Fields are private, accessed via properties
// Composition → Nations contain lists of benders and monument

// Entry point of the application
// Demonstrates the Controller pattern by starting the Engine
class Startup
{
    private static void Main(string[] args)
    {
        var engine = new Engine();
        engine.Run();
    }
}