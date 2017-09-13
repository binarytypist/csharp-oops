using Problem5_MordorsCrueltyPlan.Models.FoodModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem5_MordorsCrueltyPlan.Models
{
    public class Gandalf
    {
        // Encapsulation: internal list of foods is hidden from external modification
        private List<Food> foods;

        // Represents derived state based on foods consumed
        private Mood mood;

        // Exposes current mood (read-only from outside)
        public Mood Mood
        {
            get { return this.mood; }
            private set { this.mood = value; }
        }

        // Constructor initializes Gandalf state using provided food list
        public Gandalf(List<Food> foodsEaten)
        {
            this.Foods = foodsEaten;

            // Delegation: Mood is calculated via external factory/service
            // This keeps responsibility separated (Single Responsibility Principle)
            this.Mood = MoodFacctory.GetMood(this.Foods);
        }

        // Encapsulated food collection
        public List<Food> Foods
        {
            get { return this.foods; }
            private set { this.foods = value; }
        }

        // Object representation of Gandalf state
        public override string ToString()
        {
            var sb = new StringBuilder();

            // Aggregation: sum of all food happiness points
            sb.AppendLine($"{this.Foods.Sum(f => f.HappinessPoints)}");

            // Abstraction: mood logic is hidden inside Mood object
            sb.Append(this.Mood.Description);

            return sb.ToString();
        }
    }
}