namespace AquaShop.IO
{
    using System.Collections.Generic;
    using AquaShop.IO.Contracts;

    /// <summary>
    /// Provides predefined test commands for the application.
    /// 
    /// Purpose:
    /// - Used for debugging and testing without console input
    /// - Simulates user interaction with the system
    /// </summary>
    public class DummyInputProvider : IInputProvider
    {
        public IEnumerable<string> GetInput()
        {
            return new List<string>
            {
                "AddAquarium FreshwaterAquarium AquaOne",
                "AddDecoration Ornament",
                "AddDecoration Plant",
                "AddFish AquaOne FreshwaterFish Nemo Clownfish 10",
                "AddFish AquaOne SaltwaterFish Shark GreatWhite 20",
                "InsertDecoration AquaOne Ornament",
                "InsertDecoration AquaOne Plant",
                "FeedFish AquaOne",
                "CalculateValue AquaOne",
                "Report",
                "Exit"
            };
        }
    }
}