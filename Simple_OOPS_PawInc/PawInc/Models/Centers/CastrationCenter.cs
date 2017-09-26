using PawInc.Models.Animals;
using System.Collections.Generic;

namespace PawInc.Models.Centers
{
    // CastrationCenter handles animals that undergo castration process.
    // It inherits common behavior from BaseCenter.
    public class CastrationCenter : BaseCenter
    {
        // Constructor passes the center name to the base class
        public CastrationCenter(string name) : base(name)
        {
        }

        // Castration process:
        // 1. Marks all animals in this center as castrated
        // 2. Moves them out of the center (returns them as a list)
        public List<BaseAnimal> Castrate()
        {
            // Mark all animals as castrated
            this.Animals.ForEach(a => a.CastrationStatus = true);

            // Create a copy of animals to return
            var animals = new List<BaseAnimal>(this.Animals);

            // Clear the center after processing
            this.Animals.Clear();

            return animals;
        }
    }
}