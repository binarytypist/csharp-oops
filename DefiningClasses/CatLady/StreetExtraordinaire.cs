using CatLady;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace CatLady
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This class represents a specific type of Cat: "StreetExtraordinaire"
     *
     * It inherits from the base class "Cat"
     *
     * That means it already has:
     * - Name (from Cat class)
     *
     * And it adds its own special property:
     * - Decibels (how loud the cat meows)
     */

    public class StreetExtraordinaire : Cat
    {
        /*
         * PRIVATE FIELD:
         * --------------
         * Stores the actual decibel value internally.
         * It is hidden from outside (encapsulation).
         */
        private int decibels;

        /*
         * CONSTRUCTOR:
         * ------------
         * This runs when we create a StreetExtraordinaire object.
         *
         * We must provide:
         * - name (inherited from Cat)
         * - decibels (specific to this cat type)
         */
        public StreetExtraordinaire(string name, int decibels)
        {
            // inherited property from base class
            this.Name = name;

            // specific property for this cat type
            this.Decibels = decibels;
        }

        /*
         * PROPERTY:
         * ---------
         * Provides controlled access to the private decibels field.
         */
        public int Decibels
        {
            get { return decibels; }
            set { decibels = value; }
        }

        /*
         * ToString():
         * ----------
         * Controls how the object is printed.
         *
         * Instead of default output, we format it nicely.
         */
        public override string ToString()
        {
            return $"StreetExtraordinaire {this.Name} {this.Decibels}";
        }
    }
}

//Cat(base class)
//                   ↑
//    ┌──────────────┼────────────────┐
//    │              │                │
//Siamese Cymric     StreetExtraordinaire
//(EarSize)(FurLength)(Decibels)


    //1.It demonstrates inheritance(the core OOP idea)

    //You have:

    //Cat(base class)
    //↑
    //Siamese
    //Cymric
    //StreetExtraordinaire

    //This teaches:

    //Different objects can share common structure but extend behavior.

    //All cats share:

    //Name

    //But each breed adds its own feature:

    //Siamese → EarSize
    //Cymric → FurLength
    //StreetExtraordinaire → Decibels

    //This is a textbook example of inheritance and specialization.

    //2. It teaches polymorphism (very important)

    //You store everything in:

    //List<Cat>

    //But inside it you actually have different types:

    //Siamese objects
    //Cymric objects
    //StreetExtraordinaire objects

    //And then you call:

    //cat.ToString();

    //Each class prints differently.

    //Same method call, different behavior.

    //This is polymorphism.

    //This is one of the most commonly tested OOP concepts in interviews.

    //3. It teaches encapsulation

    //Each class uses :

    //private int earSize;
    //public int EarSize { get; set; }

    //This shows:

    //Data is hidden using private fields
    //Access is controlled using public properties

    //This is how real - world systems protect and manage data.

    //4. It models real-world thinking

    //This exercise forces you to think like this:

    //Real world → Cats with different traits
    //Code → Classes with shared base and unique properties

    //This is exactly what OOP is designed for: modeling real-world entities in code.

    //5. It teaches dynamic object creation

    //You don’t know the type in advance:

    //Siamese Tom 12
    //Cymric Garfield 5.5

    //So you must:

    //Read input
    //Decide which class to create
    //Construct objects dynamically

    //This is similar to real systems like APIs, databases, or JSON parsing.

    //6. It teaches data and behavior separation

    //Each class:

    //Stores data (properties)
    //Controls output (ToString method)

    //This reinforces an important idea:

    //Objects are not just data; they also control behavior.

    //7. It teaches design thinking (not just coding)

    //You must design:

    //A base class (Cat)
    //Multiple derived classes
    //Shared and unique properties
    //Output formatting

    //This is exactly what junior developers often struggle with.

    //8. It simulates real software structure

    //This pattern is very close to real-world systems:

    //Animal → Cat → Dog → Bird
    //Vehicle → Car → Truck → Bike
    //Employee → Manager → Developer

    //So this exercise is a small version of enterprise-level architecture.

    //9. It forces proper ToString overriding

    //Instead of printing raw objects:

    //Console.WriteLine(cat);

    //You control output using:

    //ToString()

    //This is commonly used in:

    //Logging systems
    //Debugging tools
    //UI display models