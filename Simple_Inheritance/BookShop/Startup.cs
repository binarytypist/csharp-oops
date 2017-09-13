using System;

namespace BookShop
{
    class Startup
    {
        private static void Main(string[] args)
        {
            try
            {
                // Dummy data replaces user input (useful for testing and debugging)
                string author = "John Smith";
                string title = "CSharp Basics";
                decimal price = 20m;

                // Encapsulation + validation happens inside Book constructor
                // Object is created in a valid state using domain rules
                Book book = new Book(author, title, price);

                // Inheritance: GoldenEditionBook extends Book
                // Polymorphism: overrides Price behavior (adds 30% increase)
                GoldenEditionBook goldenEditionBook = new GoldenEditionBook(author, title, price);

                // ToString() demonstrates abstraction:
                // internal structure is hidden, only formatted output is exposed
                Console.WriteLine(book);
                Console.WriteLine(goldenEditionBook);
            }
            catch (ArgumentException ae)
            {
                // Centralized error handling for invalid domain rules
                Console.WriteLine(ae.Message);
            }
        }
    }
}