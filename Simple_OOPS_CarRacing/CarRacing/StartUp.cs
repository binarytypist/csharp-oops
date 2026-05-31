// This project simulates a clean architecture racing system using OOP principles (inheritance, abstraction, polymorphism, and composition).
// this project is a Car Racing simulation system built using OOP principles in C#.
// At a high level, it models a simplified racing game where you:

// create cars
// assign them to racers
// run a race between two racers
// calculate a winner based on car performance + racer behavior

namespace CarRacing
{
    using Core;
    using Core.Contracts;

    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * StartUp is the ENTRY POINT of the application.
     *
     * OOP CONCEPTS USED:
     * 1. Abstraction:
     *    - Uses IEngine interface instead of concrete Engine logic
     *
     * 2. Dependency Inversion Principle:
     *    - High-level module depends on abstraction (IEngine)
     *    - Not on concrete implementation (Engine)
     *
     * 3. Loose Coupling:
     *    - Engine can be replaced without changing StartUp
     *
     * 4. Separation of Concerns:
     *    - StartUp only starts the system, nothing else
     */

    public class StartUp
    {
        /*
         * MAIN METHOD:
         * ------------
         * Application entry point
         * Creates engine and starts execution
         */
        public static void Main(string[] args)
        {
            // Creating engine using abstraction (best practice in OOP)
            IEngine engine = new Engine();

            // Start application flow
            engine.Run();
        }
    }
}


//+----------------------+

//| ICar |  <<interface>>
//+----------------------+

//| +Make: string       |
//                    | +Model: string      |
//                    | +VIN: string        |
//                    | +HorsePower: int    |
//                    | +FuelAvailable: dbl |
//                    | +FuelConsumption |
//                    +----------------------+
//                    | +Drive() |
//                    +----------^----------+
//                               |
//        ------------------------------------------------
//        |                                              |
//+---------------------+ +----------------------+
//| SuperCar |                    | TunedCar |
//+---------------------+ +----------------------+
//| (inherits Car) |                    | (inherits Car) |
//+---------------------+ +----------------------+
//| +Drive() |                    | +Drive() override    |
//+---------------------+                    | -reduces HP |
//                                            +----------------------+

//                    +----------------------+
//                    | Car | <<abstract>>
//                    +----------------------+
//                    | Make, Model, VIN     |
//                    | HorsePower           |
//                    | FuelAvailable        |
//                    | FuelConsumption      |
//                    +----------------------+
//                    | +Drive()             |
//                    +----------^-----------+
//                               |
//                               |

//+-------------------------------------------------------------+
//|                        IRacer                               | <<interface>>
//+-------------------------------------------------------------+
//| Username |
//| RacingBehavior |
//| DrivingExperience |
//| Car(ICar) |
//+-------------------------------------------------------------+
//| +Race() |
//| +IsAvailable() |
//+--------------------------^----------------------------------+
//                           |
//        -----------------------------------------
//        |                                       |
//+---------------------------+ +--------------------------+
//| ProfessionalRacer |      | StreetRacer |
//+---------------------------+ +--------------------------+
//| Behavior = strict |      | Behavior = aggressive |
//| Experience = 30 |      | Experience = 10 |
//+---------------------------+ +--------------------------+
//| +Race() + 10 XP |      | +Race() + 5 XP |
//+---------------------------+ +--------------------------+

//                    +----------------------+
//                    | Map |
//                    +----------------------+
//                    | +StartRace() |
//                    +----------------------+
//                    | uses IRacer |
//                    | calculates winner |
//                    +----------------------+

//                    +----------------------+
//                    | IRepository<T> |
//                    +----------------------+
//                    | Models(read - only) |
//                    | +Add() |
//                    | +Remove() |
//                    | +FindBy() |
//                    +----------^-----------+
//                               |
//              -----------------------------------
//              |                                 |
//+------------------------+ +--------------------------+
//| CarRepository |        | RacerRepository |
//+------------------------+ +--------------------------+
//| List<ICar> |        | List<IRacer> |
//+------------------------+ +--------------------------+
//| FindBy(VIN) |        | FindBy(Username) |
//+------------------------+ +--------------------------+

//                    +----------------------+
//                    | Engine |
//                    +----------------------+
//                    | Uses Controller |
//                    | Run() |
//                    +----------^-----------+
//                               |
//                    +----------------------+
//                    | Controller |
//                    +----------------------+
//                    | AddCar |
//                    | AddRacer |
//                    | BeginRace |
//                    | Report |
//                    +----------------------+

//                    +----------------------+
//                    | StartUp |
//                    +----------------------+
//                    | Main() |
//                    +----------------------+
//                    | starts Engine |
//                    +----------------------+