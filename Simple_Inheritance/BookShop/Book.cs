using System;
using System.Text;

namespace BookShop
{
    public class Book
    {
        // Encapsulation: fields are hidden from external access
        private string title;
        private string author;
        private decimal price;

        // Constructor ensures object is always created in valid state
        public Book(string author, string title, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        // Virtual allows extension in derived classes (e.g., GoldenEditionBook)
        public virtual decimal Price
        {
            get { return this.price; }
            protected set
            {
                // Business rule: price must be positive
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }

                this.price = value;
            }
        }

        // Validates author name format
        public string Author
        {
            get { return this.author; }
            protected set
            {
                // Split author name to validate second name part
                var tokens = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // If second name exists, it must not start with a digit
                if (tokens.Length > 1 && char.IsDigit(tokens[1][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }

                this.author = value;
            }
        }

        // Validates book title rules
        public string Title
        {
            get { return this.title; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                this.title = value;
            }
        }

        // Provides formatted output representation of the book
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Type: ").AppendLine(this.GetType().Name);
            sb.Append("Title: ").AppendLine(this.Title);
            sb.Append("Author: ").AppendLine(this.Author);
            sb.Append("Price: ").Append($"{this.Price:F1}");

            return sb.ToString();
        }
    }
}