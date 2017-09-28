// =======================
// MEAT CLASS
// =======================

namespace Problem3_WildFarm.Models.Foods
{
    // Meat is a specific type of Food
    // It does not add new behavior, only identifies food type
    public class Meat : Food
    {
        // Constructor passes quantity to base Food class
        public Meat(int quantity) : base(quantity)
        {
        }
    }
}