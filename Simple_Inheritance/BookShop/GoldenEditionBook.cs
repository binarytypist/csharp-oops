namespace BookShop
{
    public class GoldenEditionBook : Book
    {
        // Constructor passes base initialization to Book class
        public GoldenEditionBook(string author, string title, decimal price)
            : base(author, title, price)
        {
            // No extra fields needed; behavior is extended via override
        }

        // Polymorphism: overrides base Price calculation
        // GoldenEditionBook applies a 30% price increase
        public override decimal Price
        {
            get
            {
                // base.Price already includes validation logic from Book
                return base.Price * 1.3M;
            }
        }
    }
}