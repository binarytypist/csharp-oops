namespace PokemonTrainer
{
    public class Pokemon
    {
        /*
         * PURPOSE OF THIS CLASS:
         * ----------------------
         * This class represents a Pokemon entity.
         *
         * It is a simple OOP MODEL that shows:
         * - Encapsulation (data wrapped inside a class)
         * - Object creation using constructors
         * - Representation of a real-world object in code
         */

        /*
         * CONSTRUCTOR:
         * ------------
         * Used to initialize a Pokemon object with values.
         * Ensures object is always created in a valid state.
         */
        public Pokemon(string name, string element, int hp)
        {
            this.Name = name;       // property assignment (encapsulation)
            this.Element = element; // type of Pokemon (Fire, Water, etc.)
            this.Hp = hp;           // health points (game logic data)
        }

        /*
         * PROPERTIES:
         * -----------
         * These represent the state of the object.
         * This is ENCAPSULATION → data is stored inside object safely.
         */

        public string Name { get; set; }     // Pokemon name (e.g., Pikachu)
        public string Element { get; set; }  // Element type (Fire, Electric, etc.)
        public int Hp { get; set; }          // Health points (strength value)
    }
}