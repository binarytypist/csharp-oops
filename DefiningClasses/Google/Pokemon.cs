namespace Google
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This class represents a POKEMON entity in a Person profile system.
     *
     * Each Person can have multiple Pokemons.
     *
     * This demonstrates:
     * - Encapsulation (data grouped in a class)
     * - Object modeling (real-world relationship)
     * - Part of a HAS-MANY relationship in OOP
     */

    public class Pokemon
    {
        /*
         * CONSTRUCTOR:
         * ------------
         * Initializes a Pokemon object with required data.
         *
         * This ensures the object is always created in a valid state.
         */
        public Pokemon(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }

        /*
         * PROPERTIES (ENCAPSULATION):
         * ---------------------------
         * These store the state of the Pokemon object.
         *
         * Name → Pokemon name (e.g., Pikachu)
         * Type → Pokemon type (e.g., Electric)
         *
         * They are public so they can be accessed from Person class.
         */
        public string Name { get; set; }
        public string Type { get; set; }
    }
}