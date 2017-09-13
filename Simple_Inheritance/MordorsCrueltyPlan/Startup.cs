using Problem5_MordorsCrueltyPlan.Models;
using Problem5_MordorsCrueltyPlan.Models.FoodModels;
using System;
using System.Collections.Generic;

namespace Problem5_MordorsCrueltyPlan
{
    class Startup
    {
        private static void Main(string[] args)
        {
            // Dummy input replaces Console.ReadLine()
            // Represents foods eaten by Gandalf
            string[] foodNames = new string[]
            {
                "cram",
                "lembas",
                "apple",
                "honeycake",
                "mushrooms",
                "unknown"
            };

            // List holds all created Food objects (domain model)
            List<Food> foods = new List<Food>();

            // Factory pattern: responsible for object creation
            FoodFactory ff = new FoodFactory();

            foreach (var name in foodNames)
            {
                // Encapsulation: object creation logic is hidden inside factory
                foods.Add(ff.CreateFood(name));
            }

            // Gandalf processes food list and determines mood
            Gandalf gandalf = new Gandalf(foods);

            // ToString() uses abstraction to hide internal calculations
            Console.WriteLine(gandalf.ToString());
        }
    }
}