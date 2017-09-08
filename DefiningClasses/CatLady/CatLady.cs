using System;
using System.Collections.Generic;
using System.Linq;

namespace CatLady
{
    class CatLady
    {
        private static void Main(string[] args)
        {
            /*
             * PURPOSE OF THIS PROGRAM:
             * ------------------------
             * This program simulates a "Cat Registry System".
             *
             * It:
             * 1. Reads different types of cats
             * 2. Stores them in a list
             * 3. Finds a cat by name
             * 4. Prints its information
             *
             * KEY IDEA:
             * All cats inherit from a base class "Cat"
             */

            // ----------------------------------------------------
            // STEP 1: DUMMY INPUT DATA (instead of Console.ReadLine)
            // ----------------------------------------------------
            var inputData = new List<string>
            {
                "Siamese Tom 12",
                "Cymric Garfield 5.5",
                "StreetExtraordinaire Bob 100",
                "Siamese Jerry 8",
                "End"
            };

            // Store all cats here (polymorphism)
            List<Cat> cats = new List<Cat>();

            // ----------------------------------------------------
            // STEP 2: PROCESS CAT CREATION DATA
            // ----------------------------------------------------
            foreach (var input in inputData)
            {
                // Stop condition (like pressing Enter "End")
                if (input == "End")
                {
                    break;
                }

                var tokens = input.Split(' ');

                /*
                 * tokens[0] → Cat type
                 * tokens[1] → Cat name
                 * tokens[2] → Cat-specific value
                 */

                switch (tokens[0])
                {
                    // Siamese cat → has integer ear size
                    case "Siamese":
                        cats.Add(new Siamese(
                            tokens[1],               // name
                            int.Parse(tokens[2])     // ear size
                        ));
                        break;

                    // Cymric cat → has double fur length
                    case "Cymric":
                        cats.Add(new Cymric(
                            tokens[1],               // name
                            double.Parse(tokens[2])  // fur length
                        ));
                        break;

                    // StreetExtraordinaire → has integer decibels (meow power)
                    case "StreetExtraordinaire":
                        cats.Add(new StreetExtraordinaire(
                            tokens[1],               // name
                            int.Parse(tokens[2])     // decibels
                        ));
                        break;
                }
            }

            // ----------------------------------------------------
            // STEP 3: DUMMY SEARCH INPUT (cat name to find)
            // ----------------------------------------------------
            var catNameToFind = "Garfield";

            // Find cat by name
            var cat = cats.FirstOrDefault(c => c.Name == catNameToFind);

            // ----------------------------------------------------
            // STEP 4: OUTPUT RESULT
            // ----------------------------------------------------
            Console.WriteLine(cat?.ToString());
        }
    }
}