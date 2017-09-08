using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class PokemonTrainer
    {
        private static void Main(string[] args)
        {
            /*
             * PURPOSE OF THIS PROGRAM:
             * ------------------------
             * This program simulates a Pokemon Tournament system.
             *
             * OOP CONCEPTS USED:
             * - Encapsulation (Trainer, Pokemon classes hold data)
             * - Composition (Trainer HAS MANY Pokemons)
             * - Aggregation (objects exist independently but are linked)
             * - Collections (List usage for dynamic data storage)
             * - Business logic simulation (game-like rules)
             */

            /*
             * DUMMY INPUT DATA (replaces Console.ReadLine)
             * ---------------------------------------------
             * Format:
             * TrainerName PokemonName Element HP
             */
            List<string> inputData = new List<string>
            {
                "Ash Pikachu Electric 100",
                "Ash Charizard Fire 120",
                "Misty Staryu Water 90",
                "Brock Onix Rock 110"
            };

            List<string> tournamentData = new List<string>
            {
                "Fire",
                "Electric",
                "Water",
                "End"
            };

            List<Trainer> trainers = new List<Trainer>();

            /*
             * STEP 1: BUILD TRAINERS + POKEMONS
             * ---------------------------------
             * This demonstrates OBJECT CREATION + ASSOCIATION
             */
            foreach (var input in inputData)
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var tName = tokens[0];   // Trainer name (identity)
                var pName = tokens[1];   // Pokemon name (object)
                var pEle = tokens[2];    // Pokemon element type
                var pHp = int.Parse(tokens[3]); // Pokemon health (state)

                /*
                 * CHECK IF TRAINER EXISTS (SEARCH OPERATION)
                 * ------------------------------------------
                 * This is object reuse (avoiding duplicates)
                 */
                if (trainers.Any(t => t.Name == tName))
                {
                    var trainer = trainers.First(t => t.Name == tName);

                    // ADD NEW POKEMON TO EXISTING TRAINER
                    trainer.Pokemons.Add(new Pokemon(pName, pEle, pHp));
                }
                else
                {
                    // CREATE NEW TRAINER OBJECT (COMPOSITION STARTS HERE)
                    trainers.Add(new Trainer(
                        tName,
                        0,
                        new List<Pokemon>() { new Pokemon(pName, pEle, pHp) }
                    ));
                }
            }

            /*
             * STEP 2: TOURNAMENT LOGIC
             * ------------------------
             * This demonstrates POLYMORPHIC BEHAVIOR (state changes)
             */
            foreach (var input in tournamentData)
            {
                if (input == "End")
                    break;

                var element = input;

                /*
                 * LOOP THROUGH ALL TRAINERS
                 * -------------------------
                 * This is ITERATION over object collection
                 */
                foreach (var tr in trainers)
                {
                    /*
                     * CONDITION CHECK:
                     * If trainer has Pokemon matching element → reward
                     */
                    if (tr.Pokemons.Any(p => p.Element == element))
                    {
                        tr.BadgesCount++; // INCREMENT STATE (encapsulation behavior)
                    }
                    else
                    {
                        /*
                         * PENALTY LOGIC:
                         * Reduce HP of all Pokemons
                         * Remove dead Pokemons (HP <= 0)
                         *
                         * This shows:
                         * - State mutation
                         * - Collection modification
                         */
                        for (int i = 0; i < tr.Pokemons.Count; i++)
                        {
                            tr.Pokemons[i].Hp -= 10;

                            if (tr.Pokemons[i].Hp <= 0)
                            {
                                tr.Pokemons.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }
            }

            /*
             * STEP 3: OUTPUT RESULT
             * ---------------------
             * Sorting trainers by performance (Badges)
             * This demonstrates LINQ + ordering logic
             */
            foreach (var trainer in trainers.OrderByDescending(t => t.BadgesCount))
            {
                Console.WriteLine($"{trainer.Name} {trainer.BadgesCount} {trainer.Pokemons.Count}");
            }
        }
    }
}