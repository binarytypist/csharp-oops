using PawInc.Models; // Imports core domain models (animals, centers, manager)
using System; // Provides basic system functions like Console
using System.Collections.Generic; // Allows use of List<T>

namespace PawInc.Core
{
    // Engine is the main controller of the application flow
    public class Engine
    {
        // Central manager that handles all business logic
        private CenterManager manager;

        // Constructor: initializes the CenterManager
        public Engine()
        {
            this.manager = new CenterManager();
        }

        // Main execution method of the program
        public void Run()
        {
            // Dummy input data simulating console commands
            var input = new List<string>
            {
                "RegisterAdoptionCenter | SofiaCenter",
                "RegisterCleansingCenter | CleanCenter",
                "RegisterDog | Rex | 5 | 10 | SofiaCenter",
                "RegisterCat | Mishi | 3 | 8 | SofiaCenter",
                "SendForCleansing | SofiaCenter | CleanCenter",
                "Cleanse | CleanCenter",
                "Adopt | SofiaCenter",
                "CastrationStatistics",
                "Paw Paw Pawah"
            };

            // Loop through each command line
            foreach (var line in input)
            {
                // Stop execution if termination command is reached
                if (line == "Paw Paw Pawah")
                    break;

                // Split command into parts using " | " separator
                var tokens = line.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

                // First token is the command name
                var command = tokens[0];

                // Execute logic based on command type
                switch (command)
                {
                    // register cleansing center
                    case "RegisterCleansingCenter":
                        manager.RegisterCleansingCenter(tokens[1]);
                        break;

                    // register adoption center
                    case "RegisterAdoptionCenter":
                        manager.RegisterAdoptionCenter(tokens[1]); 
                        break;

                    // register castration center
                    case "RegisterCastrationCenter":
                        manager.RegisterCastrationCenter(tokens[1]);
                        break;

                    // register dog
                    case "RegisterDog":
                        manager.RegisterDog(tokens[1], int.Parse(tokens[2]), int.Parse(tokens[3]), tokens[4]); 
                        break;

                    // register cat
                    case "RegisterCat":
                        manager.RegisterCat(tokens[1], int.Parse(tokens[2]), int.Parse(tokens[3]), tokens[4]); 
                        break;

                    // move animals for cleansing
                    case "SendForCleansing":
                        manager.SendForCleansing(tokens[1], tokens[2]); 
                        break;

                    // move animals for castration
                    case "SendForCastration":
                        manager.SendForCastration(tokens[1], tokens[2]); 
                        break;

                    // execute cleansing process
                    case "Cleanse":
                        manager.Cleanse(tokens[1]); 
                        break;

                    // execute castration process
                    case "Castrate":
                        manager.Castrate(tokens[1]);
                        break;

                    // print castration stats
                    case "CastrationStatistics":
                        manager.CastrationStatistics(); 
                        break;

                    // adopt animals from center
                    case "Adopt":
                        manager.Adopt(tokens[1]); 
                        break;
                }
            }

            // Print final system statistics
            Console.WriteLine(manager.ToString());
        }
    }
}