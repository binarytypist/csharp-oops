// =======================
// BASE FOOD CLASS
// =======================
namespace Problem3_WildFarm.Models.Foods
{
    // Abstract class representing any type of food in the system
    public abstract class Food
    {
        // Quantity of food units
        private int quantity;

        // Constructor sets food quantity
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        // Encapsulated property for food quantity
        public int Quantity
        {
            get { return this.quantity; }
            protected set { this.quantity = value; }
        }
    }
}