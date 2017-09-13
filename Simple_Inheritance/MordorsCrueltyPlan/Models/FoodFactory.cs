using Problem5_MordorsCrueltyPlan.Models.FoodModels;

namespace Problem5_MordorsCrueltyPlan.Models
{
    public class FoodFactory
    {
        // Factory Method Pattern:
        // Responsible for creating Food objects based on input string
        public virtual Food CreateFood(string name)
        {
            Food food = null;

            // Decision-making logic determines which concrete Food object to create
            // This hides object creation complexity from the caller
            switch (name.ToLower())
            {
                case "cram":
                    food = new Cram(2);
                    break;

                case "lembas":
                    food = new Lembas(3);
                    break;

                case "apple":
                    food = new Apple(1);
                    break;

                case "melon":
                    food = new Melon(1);
                    break;

                case "honeycake":
                    food = new HoneyCake(5);
                    break;

                case "mushrooms":
                    food = new Mushrooms(-10);
                    break;

                default:
                    // Unknown food type mapped to default behavior
                    food = new Misc(-1);
                    break;
            }

            return food;
        }
    }
}