using System;
using System.Collections.Generic;
using System.Linq;

class RawData
{
    public static void Main(string[] args)
    {
        /*
         * PURPOSE OF THIS PROGRAM:
         * ------------------------
         * This program demonstrates OOP modeling using a Car system.
         *
         * OOP CONCEPTS USED:
         * - Composition (Car HAS Engine, Cargo, Tires)
         * - Encapsulation (data stored inside objects)
         * - Object aggregation (objects created and passed together)
         * - Filtering logic using LINQ (business rules simulation)
         */

        /*
         * DUMMY INPUT DATA (replacing Console.ReadLine)
         * ---------------------------------------------
         * Format:
         * Model EngineSpeed EnginePower CargoWeight CargoType Tire1Pressure Tire1Age ... Tire4Age
         */
        List<string> inputData = new List<string>
        {
            "BMW 200 300 1000 fragile 0.5 2 0.8 3 1.2 1 0.9 4",
            "Audi 250 260 1200 flamable 1.5 2 1.6 3 1.7 4 1.8 5",
            "Toyota 180 200 900 fragile 0.4 2 0.3 3 0.5 2 0.6 1"
        };

        List<Car> cars = new List<Car>();

        /*
         * STEP 1: BUILD CAR OBJECTS (COMPOSITION)
         * ----------------------------------------
         * Each car contains Engine, Cargo, and Tires
         */
        foreach (var line in inputData)
        {
            var tokens = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var model = tokens[0];

            int eSpeed = int.Parse(tokens[1]);
            int ePower = int.Parse(tokens[2]);

            int cWeight = int.Parse(tokens[3]);
            string cType = tokens[4];

            // Creating 4 tires (real-world car structure)
            List<Tire> tires = new List<Tire>
            {
                new Tire(int.Parse(tokens[6]), double.Parse(tokens[5])),
                new Tire(int.Parse(tokens[8]), double.Parse(tokens[7])),
                new Tire(int.Parse(tokens[10]), double.Parse(tokens[9])),
                new Tire(int.Parse(tokens[12]), double.Parse(tokens[11]))
            };

            /*
             * OBJECT CREATION (COMPOSITION)
             * Car is built using Engine + Cargo + Tires
             */
            Car car = new Car(
                model,
                new Engine(eSpeed, ePower),
                new Cargo(cWeight, cType),
                tires
            );

            cars.Add(car);
        }

        /*
         * STEP 2: COMMAND SELECTION (NO INPUT)
         */
        string command = "fragile"; // change to "flamable" if needed

        /*
         * STEP 3: FILTERING LOGIC (BUSINESS RULES)
         * ----------------------------------------
         * This demonstrates LINQ + condition-based filtering
         */
        if (command == "fragile")
        {
            var results = cars
                .Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1));

            foreach (var res in results)
            {
                Console.WriteLine(res.Model);
            }
        }
        else if (command == "flamable")
        {
            var results = cars
                .Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250);

            foreach (var res in results)
            {
                Console.WriteLine(res.Model);
            }
        }
    }
}