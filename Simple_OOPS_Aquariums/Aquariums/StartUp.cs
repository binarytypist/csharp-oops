namespace Aquariums
{

    // Purpose of the Project
    // The system simulates an aquarium where:
    // Fish can be added to the aquarium.
    // Fish can be removed.
    // Fish can be sold.
    // Sold fish become unavailable (Available = false).
    // A report can be generated showing all fish in the aquarium.


    using System;

    public class StartUp
    {
        public static void Main()
        {
            // Create an aquarium with capacity for 3 fish
            Aquarium aquarium = new Aquarium("Ocean World", 3);

            // Create fish
            Fish fish1 = new Fish("Nemo");
            Fish fish2 = new Fish("Dory");
            Fish fish3 = new Fish("Goldie");

            // Add fish to aquarium
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            Console.WriteLine($"Fish count: {aquarium.Count}");

            // Sell a fish
            Fish soldFish = aquarium.SellFish("Dory");

            Console.WriteLine($"Sold fish: {soldFish.Name}");
            Console.WriteLine($"Available: {soldFish.Available}");

            // Remove a fish
            aquarium.RemoveFish("Goldie");

            Console.WriteLine($"Fish count after removal: {aquarium.Count}");

            // Generate report
            Console.WriteLine(aquarium.Report());
        }
    }
    }