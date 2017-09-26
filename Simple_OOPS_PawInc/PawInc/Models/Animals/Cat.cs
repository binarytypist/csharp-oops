namespace PawInc.Models.Animals
{
    // Cat is a concrete animal type that inherits from BaseAnimal.
    // It adds a specific property: Intelligence.
    public class Cat : BaseAnimal
    {
        // Specific characteristic for Cat
        private int intelligence;

        // Constructor initializes both base animal data and cat-specific data
        public Cat(string name, int age, int intelligence, string adoptionCenterName)
            : base(name, age, adoptionCenterName)
        {
            this.Intelligence = intelligence;
        }

        // Intelligence level of the cat
        public int Intelligence
        {
            get { return this.intelligence; }
            set { this.intelligence = value; }
        }
    }
}