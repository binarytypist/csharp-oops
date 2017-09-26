using PawInc.Models.Animals;
using System.Collections.Generic;

namespace PawInc.Models.Centers
{
    // CleansingCenter is responsible for cleansing animals before adoption.
    // It inherits common center behavior from BaseCenter.
    public class CleansingCenter : BaseCenter
    {
        // Constructor initializes center name via base class
        public CleansingCenter(string name) : base(name)
        {
        }

        // Cleansing process:
        // 1. Marks all animals as cleansed
        // 2. Moves them out of the center (returns them as a list)
        public List<BaseAnimal> Cleanse()
        {
            // Mark all animals as cleansed
            this.Animals.ForEach(a => a.CleansingStatus = true);

            // Copy animals before removing them from the center
            var animals = new List<BaseAnimal>(this.Animals);

            // Clear center after processing
            this.Animals.Clear();

            return animals;
        }
    }
}