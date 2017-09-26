namespace PawInc.Models.Animals
{
    // BaseAnimal is the abstract parent class for all animals in the system (Dog, Cat, etc.)
    // It contains shared properties and state used across all animal types.
    public abstract class BaseAnimal
    {
        // The name of the adoption center where the animal belongs
        private string adoptionCenterName;

        // Animal age
        private int age;

        // Indicates whether the animal has been castrated
        private bool castrationStatus;

        // Indicates whether the animal has been cleansed
        private bool cleansingStatus;

        // Animal name
        private string name;

        // Constructor initializes common animal data
        public BaseAnimal(string name, int age, string adoptionCenterName)
        {
            this.Name = name;
            this.Age = age;

            // New animals start as not cleansed
            this.CleansingStatus = false;

            // Assigned adoption center
            this.AdoptionCenterName = adoptionCenterName;

            // New animals start as not castrated
            this.CastrationStatus = false;
        }

        // The adoption center the animal is assigned to
        public string AdoptionCenterName
        {
            get { return this.adoptionCenterName; }
            protected set { this.adoptionCenterName = value; }
        }

        // Age of the animal
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        // Whether the animal is castrated or not
        public bool CastrationStatus
        {
            get { return this.castrationStatus; }
            set { this.castrationStatus = value; }
        }

        // Whether the animal has been cleansed (ready for adoption)
        public bool CleansingStatus
        {
            get { return this.cleansingStatus; }
            set { this.cleansingStatus = value; }
        }

        // Animal name
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}