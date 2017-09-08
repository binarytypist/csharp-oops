namespace CarSalesman
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This class represents an ENGINE in a car system.
     * 
     * An engine is NOT just a number — it has multiple properties like:
     * - model (e.g. V8, V6)
     * - power (horsepower)
     * - optional: displacement (engine size)
     * - optional: efficiency (fuel efficiency rating)
     */

    public class Engine
    {
        /*
         * CONSTRUCTOR:
         * ------------
         * This runs when you create a new Engine object.
         * It forces you to always provide:
         * - model
         * - power
         *
         * Because every engine MUST have these two values.
         */
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }

        /*
         * BASIC REQUIRED PROPERTIES
         * -------------------------
         * These are the core attributes of an engine.
         */

        // Example: "V8", "V6", "EcoBoost"
        public string Model { get; set; }

        // Example: 600, 400, 250 horsepower
        public int Power { get; set; }

        /*
         * OPTIONAL PROPERTIES
         * -------------------
         * Not every engine has these values in input,
         * so they can be left empty (null).
         */

        // Example: 5000cc, 3000cc
        // "int?" means it can be NULL (no value provided)
        public int? Displacement { get; set; }

        /*
         * Example: "A+", "B", "C"
         * This describes fuel efficiency or performance rating
         */
        public string Efficiency { get; set; }
    }
}

//                ┌──────────────────────┐
//                │      PROGRAM         │
//                │   (Main Method)      │
//                │----------------------│
//                │ - Creates Engines    │
//                │ - Creates Cars       │
//                │ - Links them         │
//                │ - Prints output      │
//                └─────────┬────────────┘
//                          │
//          ┌───────────────┴────────────────┐
//          │                                │
//          ▼                                ▼

//┌──────────────────────┐        ┌──────────────────────┐
//│       ENGINE         │        │        CAR           │
//│----------------------│        │----------------------│
//│ Model                │        │ Model                │
//│ Power                │        │ Engine (reference)   │◄──────┐
//│ Displacement (opt)   │        │ Weight (optional)    │       │
//│ Efficiency (opt)     │        │ Color (optional)     │       │
//└──────────────────────┘        └──────────────────────┘       │
//                                                              │
//                                                              │
//                                                ┌─────────────┘
//                                                │
//                                        (Car "HAS AN" Engine)