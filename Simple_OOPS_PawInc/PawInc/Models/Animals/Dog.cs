namespace PawInc.Models.Animals
{
    // Dog is a concrete animal type that inherits from BaseAnimal.
    // It adds a specific property: Commands (training level).
    public class Dog : BaseAnimal
    {
        // Represents how many commands the dog knows
        private int commands;

        // Constructor initializes base animal data and dog-specific data
        public Dog(string name, int age, int commands, string adoptionCenterName)
            : base(name, age, adoptionCenterName)
        {
            this.Commands = commands;
        }

        // Number of commands the dog can perform (read-only from outside)
        public int Commands
        {
            get { return this.commands; }
            private set { this.commands = value; }
        }
    }
}