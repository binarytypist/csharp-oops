using PawInc.Models.Animals;
using System.Collections.Generic;

namespace PawInc.Models.Centers
{
    // BaseCenter is an abstract class that represents a general center in the PawInc system.
    // It is inherited by specific center types like AdoptionCenter, CleansingCenter, etc.
    public abstract class BaseCenter
    {
        // Name of the center
        private string name;

        // Collection of animals currently stored in this center
        private List<BaseAnimal> animals;

        // Constructor initializes center name and animal collection
        public BaseCenter(string name)
        {
            this.Name = name;
            this.Animals = new List<BaseAnimal>();
        }

        // List of animals in the center (protected so only derived classes can modify it directly)
        public List<BaseAnimal> Animals
        {
            get { return this.animals; }
            protected set { this.animals = value; }
        }

        // Name of the center (readable publicly, but only settable by derived classes)
        public string Name
        {
            get { return this.name; }
            protected set { this.name = value; }
        }
    }
}