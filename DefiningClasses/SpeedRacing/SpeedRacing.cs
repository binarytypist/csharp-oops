using System;
using System.Collections.Generic;
using System.Linq;

class SpeedRacing
{
    public static void Main(string[] args)
    {
        /*
         * PURPOSE OF THIS PROGRAM:
         * ------------------------
         * This program simulates a simple car racing system.
         *
         * OOP CONCEPTS USED:
         * - Encapsulation (Car stores its own state)
         * - Object behavior (TryExecuteTrip method updates state)
         * - Collection of objects (List<Car>)
         * - State changes over time (fuel decreases, distance increases)
         */

        /*
         * DUMMY DATA (replacing Console.ReadLine)
         * ----------------------------------------
         * Instead of user input, we simulate input using hardcoded lists.
         */

        // STEP 1: CAR INITIAL DATA (model, fuel amount, fuel consumption per km)
        List<string> carData = new List<string>
        {
            "BMW 50 0.5",
            "Audi 60 0.4",
            "Toyota 40 0.3"
        };

        // STEP 2: COMMAND DATA (Drive commands)
        List<string> commands = new List<string>
        {
            "Drive BMW 100",
            "Drive Audi 50",
            "Drive Toyota 120",
            "End"
        };

        // MAIN COLLECTION OF CARS
        List<Car> cars = new List<Car>();

        /*
         * STEP 3: CREATE CAR OBJECTS (OBJECT INSTANTIATION)
         * --------------------------------------------------
         * Each line becomes a Car object (Encapsulation + Constructor usage)
         */
        foreach (var line in carData)
        {
           var tokens = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var model = tokens[0];                 // car identity
            var fuelAmount = double.Parse(tokens[1]); // current fuel
            var fuelConsumption = double.Parse(tokens[2]); // fuel per km

            // Creating Car object (OOP: object creation)
            cars.Add(new Car(model, fuelAmount, fuelConsumption));
        }

        /*
         * STEP 4: PROCESS DRIVING COMMANDS
         * ---------------------------------
         * This demonstrates:
         * - Object lookup
         * - Method calling on objects
         * - State modification
         */
        foreach (var input in commands)
        {
            if (input == "End")
                break;

            var arguments = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var model = arguments[1];  // which car to drive
            int km = int.Parse(arguments[2]); // distance to travel

            // FIND CAR OBJECT (LINQ search)
            var car = cars.First(x => x.Model == model);

            // CALL BEHAVIOR METHOD (Encapsulation in action)
            car.TryExecuteTrip(km);
        }

        /*
         * STEP 5: PRINT FINAL STATE
         * --------------------------
         * Shows how object state changed after operations
         */
        foreach (var c in cars)
        {
            Console.WriteLine($"{c.Model} {c.FuelAmount:F2} {c.DistanceTraveled}");
        }
    }
}