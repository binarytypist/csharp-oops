using PizzaCalories.Models;
using System;

namespace PizzaCalories
{
    class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                // Create dough (core base of the pizza)
                Dough dough = new Dough("White", "Chewy", 100);

                // Create pizza with name and dough (composition: Pizza HAS-A Dough)
                Pizza pizza = new Pizza("Margherita", dough);

                // Add toppings (Pizza HAS-MANY Toppings)
                pizza.AddTopping(new Topping("Meat", 30));
                pizza.AddTopping(new Topping("Cheese", 20));
                pizza.AddTopping(new Topping("Sauce", 10));

                // Output final result (ToString uses encapsulated logic)
                Console.WriteLine(pizza);
            }
            catch (Exception e)
            {
                // Catch validation/business rule errors
                Console.WriteLine(e.Message);
            }
        }
    }
}