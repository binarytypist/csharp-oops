using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    class CarSalesman
    {
        private static void Main(string[] args)
        {
            /*
             * PURPOSE OF THIS PROGRAM:
             * -------------------------
             * This program simulates a simple "Car Salesman System".
             * 
             * It does 3 main things:
             * 1. Reads Engine data (model, power, optional displacement, efficiency)
             * 2. Reads Car data (model, engine reference, optional weight, color)
             * 3. Combines them and prints full car information
             *
             * KEY IDEA:
             * A Car "has an Engine" (composition relationship)
             */

            // --------------------------------------------------------
            // STEP 1: SIMULATE INPUT DATA FOR ENGINES (instead of ReadLine)
            // --------------------------------------------------------
            var engineInput = new List<string>
            {
                "V8 600 5000 A+",
                "V6 400 3000",
                "EcoBoost 250 B"
            };

            // Store all engines here
            List<Engine> engines = new List<Engine>();

            // --------------------------------------------------------
            // STEP 2: PROCESS ENGINE DATA
            // --------------------------------------------------------
            foreach (var line in engineInput)
            {
                var tokens = line.Split(' ');

                // Engine basic required data
                var model = tokens[0];
                var power = int.Parse(tokens[1]);

                // Create engine object with required values
                var engine = new Engine(model, power);

                /*
                 * OPTIONAL VALUES:
                 * tokens[2] → could be displacement OR efficiency
                 * We must check type to decide
                 */

                if (tokens.Length > 2)
                {
                    int disp;

                    // If it's a number → it's displacement
                    if (int.TryParse(tokens[2], out disp))
                    {
                        engine.Displacement = disp;

                        // If there is a 4th value → efficiency
                        if (tokens.Length > 3)
                        {
                            engine.Efficiency = tokens[3];
                        }
                    }
                    else
                    {
                        // If not number → it's efficiency
                        engine.Efficiency = tokens[2];
                    }
                }

                engines.Add(engine);
            }

            // --------------------------------------------------------
            // STEP 3: SIMULATE INPUT DATA FOR CARS
            // --------------------------------------------------------
            var carInput = new List<string>
            {
                "BMW V8 1500 Black",
                "Audi V6 1300",
                "Ford EcoBoost Red"
            };

            List<Car> cars = new List<Car>();

            // --------------------------------------------------------
            // STEP 4: PROCESS CAR DATA
            // --------------------------------------------------------
            foreach (var line in carInput)
            {
                var tokens = line.Split(' ');

                // Car model (first value)
                var carModel = tokens[0];

                // Engine model reference (second value)
                var engineModel = tokens[1];

                // Find matching engine from list
                var engine = engines.FirstOrDefault(e => e.Model == engineModel);

                // Create car using engine (IMPORTANT RELATIONSHIP)
                var car = new Car(carModel, engine);

                /*
                 * OPTIONAL CAR DATA:
                 * tokens[2] → could be weight OR color
                 */

                if (tokens.Length > 2)
                {
                    int weight;

                    if (int.TryParse(tokens[2], out weight))
                    {
                        // numeric → weight
                        car.Weight = weight;

                        // optional color
                        if (tokens.Length > 3)
                        {
                            car.Color = tokens[3];
                        }
                    }
                    else
                    {
                        // string → color
                        car.Color = tokens[2];
                    }
                }

                cars.Add(car);
            }

            // --------------------------------------------------------
            // STEP 5: OUTPUT RESULT
            // --------------------------------------------------------
            foreach (var car in cars)
            {
                // Calls Car.ToString() to print full structured info
                Console.WriteLine(car.ToString());
            }
        }
    }
}