namespace Problem5_MordorsCrueltyPlan.Models
{
    public class Mood
    {
        // Encapsulation: internal state is hidden
        private string description;

        // Constructor ensures Mood is always initialized with valid data
        public Mood(string desc)
        {
            this.Description = desc;
        }

        // Property represents mood state (can be extended or validated later)
        public string Description
        {
            get { return this.description; }
            set
            {
                // In real-world systems, validation could be added here
                // Example: ensure description is not null or empty

                this.description = value;
            }
        }
    }
}