using PawInc.Core;
using System;

namespace PawInc
{
    // Entry point of the application
    // This class is responsible only for starting the program
    class Startup
    {
        // Main method: execution begins here
        private static void Main(string[] args)
        {
            // Create the Engine (core controller of the system)
            var engine = new Engine();

            // Start processing commands and running the application logic
            engine.Run();
        }
    }
}