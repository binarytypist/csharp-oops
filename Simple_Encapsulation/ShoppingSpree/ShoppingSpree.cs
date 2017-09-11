using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class ShoppingSpree
    {
        private static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            List<Person> people = new List<Person>();

            try
            {
                // Dummy data instead of Console.ReadLine()

                // Format: Name=Money;Name=Money
                var peopleInfo = "John=100;Anna=50;Peter=30"
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var token in peopleInfo)
                {
                    var nameAndMoney = token.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    people.Add(new Person(nameAndMoney[0], decimal.Parse(nameAndMoney[1])));
                }

                // Format: Product=Cost;Product=Cost
                var productInfo = "Bread=10;Milk=5;Laptop=80;Book=15"
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var token in productInfo)
                {
                    var nameAndCost = token.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    products.Add(new Product(nameAndCost[0], decimal.Parse(nameAndCost[1])));
                }

                // Dummy purchase commands
                var commands = new List<string>
                {
                    "John Bread",
                    "Anna Laptop",
                    "Peter Milk",
                    "John Laptop",
                    "END"
                };

                foreach (var input in commands)
                {
                    if (input == "END")
                        break;

                    var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var personName = tokens[0];
                    var productName = tokens[1];

                    var person = people.First(p => p.Name == personName);
                    var product = products.First(p => p.Name == productName);

                    if (person.Money - product.Cost >= 0)
                    {
                        person.Products.Add(product);
                        person.Money -= product.Cost;
                        Console.WriteLine($"{person.Name} bought {product.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");
                    }
                }

                foreach (var p in people)
                {
                    string productMsg =
                        p.Products.Count > 0
                            ? string.Join(", ", p.Products.Select(pr => pr.Name))
                            : "Nothing bought";

                    Console.WriteLine($"{p.Name} - {productMsg}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}