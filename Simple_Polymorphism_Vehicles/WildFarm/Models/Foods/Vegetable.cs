// =======================
// VEGETABLE CLASS
// =======================

namespace Problem3_WildFarm.Models.Foods
{
    // Vegetable is a type of Food
    // It inherits quantity behavior from Food without changes
    public class Vegetable : Food
    {
        // Passes quantity to base Food constructor
        public Vegetable(int quantity) : base(quantity)
        {
        }
    }
}