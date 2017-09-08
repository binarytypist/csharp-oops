using System.Collections.Generic;

namespace PokemonTrainer
{
    public class Trainer
    {
        /*
         * PURPOSE OF THIS CLASS:
         * ----------------------
         * This class represents a Trainer in a Pokemon system.
         *
         * OOP CONCEPTS USED:
         * - Encapsulation (data + properties inside one class)
         * - Composition (Trainer HAS MANY Pokemons)
         * - Object modeling (real-world entity representation)
         */

        /*
         * CONSTRUCTOR:
         * ------------
         * Initializes Trainer object with:
         * - Name
         * - Badges count
         * - List of Pokemons
         *
         * We copy the collection into a new List to avoid external modification.
         */
        public Trainer(string name, int badges, ICollection<Pokemon> pokemons)
        {
            this.Name = name;                       // trainer name (identity)
            this.BadgesCount = badges;             // number of tournament wins
            this.Pokemons = new List<Pokemon>(pokemons); // composition (HAS-MANY relationship)
        }

        /*
         * PROPERTIES:
         * -----------
         * These define the state of the Trainer object.
         * This is ENCAPSULATION → data is wrapped inside class.
         */

        public string Name { get; set; }            // trainer name
        public int BadgesCount { get; set; }        // number of badges earned

        /*
         * COLLECTION PROPERTY:
         * --------------------
         * Trainer HAS MANY Pokemons (one-to-many relationship)
         * This is called COMPOSITION in OOP.
         */
        public List<Pokemon> Pokemons { get; set; }
    }
}