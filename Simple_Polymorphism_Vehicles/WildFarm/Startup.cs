using System;
using System.Collections.Generic;
using Problem3_WildFarm.Models.Animals;
using Problem3_WildFarm.Models.Foods;

namespace Problem3_WildFarm
{
    class Startup
    {
        private static void Main(string[] args)
        {
            FeedAnimals();
        }

        private static void FeedAnimals()
        {
            // DUMMY INPUT DATA (replaces Console.ReadLine)
            var inputs = new List<(string animalLine, string foodLine)>
            {
                ("Cat Whiskers 4.5 Home Persian", "Vegetable 2"),
                ("Tiger ShereKhan 200 Jungle", "Meat 5"),
                ("Zebra Marty 120 Savannah", "Vegetable 10"),
                ("Mouse Jerry 0.5 House", "Vegetable 3"),
                ("Tiger Bagheera 180 Jungle", "Vegetable 2") // invalid food case
            };

            foreach (var pair in inputs)
            {
                var animalInformation = pair.animalLine
                     .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var foodInformation = pair.foodLine
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Animal currentAnimal = null;
                Food currentFood = null;

                var animalType = animalInformation[0];
                var animalName = animalInformation[1];
                var animalWeight = double.Parse(animalInformation[2]);
                var animalRegion = animalInformation[3];

                if (animalType == "Cat")
                {
                    var breed = animalInformation[4];
                    currentAnimal = new Cat(animalName, animalType, animalWeight, animalRegion, breed);
                }
                else
                {
                    switch (animalType)
                    {
                        case "Tiger":
                            currentAnimal = new Tiger(animalName, animalType, animalWeight, animalRegion);
                            break;

                        case "Zebra":
                            currentAnimal = new Zebra(animalName, animalType, animalWeight, animalRegion);
                            break;

                        case "Mouse":
                            currentAnimal = new Mouse(animalName, animalType, animalWeight, animalRegion);
                            break;
                    }
                }

                var foodType = foodInformation[0];
                var foodAmount = int.Parse(foodInformation[1]);

                if (foodType == "Vegetable")
                    currentFood = new Vegetable(foodAmount);
                else if (foodType == "Meat")
                    currentFood = new Meat(foodAmount);

                currentAnimal.MakeSound();
                currentAnimal.Eat(currentFood);

                Console.WriteLine(currentAnimal);
            }
        }
    }
}