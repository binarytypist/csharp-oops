using Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Xml.Linq;

namespace Google
{
    class Google
    {
        private static void Main(string[] args)
        {
            // MAIN DATA STORE (all people)
            List<Person> people = new List<Person>();

            // DUMMY INPUT DATA (NO Console.ReadLine)
            List<string> inputData = new List<string>
            {
                "John company Google Dev 10000",
                "John pokemon Pikachu Electric",
                "John parents Michael 01/01/1970",
                "John children Anna 01/01/2010",
                "John car BMW 200",
                "Alice company Microsoft HR 8000",
                "End"
            };

            // PROCESS INPUT
            foreach (var input in inputData)
            {
                if (input == "End") break;

                // FIXED SPLIT (IMPORTANT FIX)
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var name = tokens[0];
                var command = tokens[1];

                // CREATE PERSON IF NOT EXISTS
                if (!people.Any(p => p.Name == name))
                {
                    people.Add(new Person(name));
                }

                var person = people.First(p => p.Name == name);

                // ADD DATA TO PERSON
                switch (command)
                {
                    case "company":
                        person.Company = new Company(tokens[2], tokens[3], decimal.Parse(tokens[4]));
                        break;

                    case "pokemon":
                        person.Pokemons.Add(new Pokemon(tokens[2], tokens[3]));
                        break;

                    case "parents":
                        person.Parents.Add(new Parent(tokens[2], tokens[3]));
                        break;

                    case "children":
                        person.Children.Add(new Child(tokens[2], tokens[3]));
                        break;

                    case "car":
                        person.Car = new Car(tokens[2], int.Parse(tokens[3]));
                        break;
                }
            }

            // OUTPUT RESULT
            var result = people.First(p => p.Name == "John");

            Console.WriteLine(result.ToString());
        }
    }
}

// This is a clean OOP composition system where a Person object dynamically stores multiple related
// entities using parsed input data with safe string splitting and collection management.


//+----------------------+

//| Person |
//+----------------------+

//| Name |

//| Company(HAS - A) |

//| Car(HAS - A) |

//| Pokemons(HAS - MANY) |

//| Parents(HAS - MANY) |

//| Children(HAS - MANY) |
//+----------+-----------+

//           |
//------------------------------------------------

//|                 |              |              |
//v                 v v              v

//+-------------+   +--------------+  +--------------+  +--------------+
//|  Company    |   |     Car      |  |   Pokemon    |  |    Parent    |
//+-------------+   +--------------+  +--------------+  +--------------+
//| Name        |   | Model        |  | Name         |  | Name         |
//| Department  |   | Speed        |  | Type         |  | Birthday     |
//| Salary      |   +--------------+  +--------------+  +--------------+
//+-------------+                                           |
//                                                          v
//                                                 +----------------+
//                                                 |    Child       |
//                                                 +----------------+
//                                                 | Name           |
//                                                 | Birthday       |
//                                                 +----------------+


//  RELATIONSHIP EXPLANATION

//  Person (CENTER OBJECT)

//  This is the main class

//  It acts like a database record

//  Person = Google profile
//  HAS-A RELATIONSHIP (1 to 1)

//  Person → Company
//  One person has ONE company

//  Person → Car
//  One person has ONE car

//  HAS-MANY RELATIONSHIP (1 to MANY)

//  Person → Pokemons
//  One person can have MANY pokemons

//  Person → Parents
//  One person can have MANY parents

//  Person → Children
//  One person can have MANY children

//  OOP CONCEPTS USED

//  Composition
//  Person is composed of multiple objects

//  Aggregation
//  Parent / Child / Pokemon exist independently
//  but are linked to Person
//  Encapsulation
//  Each class hides its own data
//  (Company, Car, Pokemon, etc.)
//  Real-world modeling
//  This mimics real human profile systems
//  like Facebook / Google / LinkedIn

//  ONE-LINE MEMORY TRICK
//  Person is the MAIN NODE, everything else is connected like a tree of relationships (1-to-1 and 1-to-many).