namespace CarRacing.Core
{
    using CarRacing.Core.Contracts;
    using System;

    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * Engine is the ENTRY POINT of the application logic.
     *
     * It controls the flow of the program:
     * - creates data (Cars, Racers) through Controller
     * - starts a race
     * - prints results
     *
     * OOP CONCEPT:
     * This class follows the "Controller + Engine" separation pattern
     * where Engine = flow controller, Controller = business logic handler.
     */

    public class Engine : IEngine
    {
        /*
         * DEPENDENCY INJECTION (HERE MANUAL):
         * ------------------------------------
         * Engine depends on IController to perform all operations.
         *
         * Instead of Engine doing logic itself,
         * it delegates responsibilities to Controller.
         *
         * This is a key OOP principle: LOW COUPLING.
         */
        private readonly IController controller;

        public Engine()
        {
            // Creating concrete implementation of controller
            this.controller = new Controller();
        }

        /*
         * RUN METHOD:
         * -----------
         * This method acts like the MAIN DRIVER of the program.
         *
         * It simulates application execution using DUMMY DATA
         * instead of reading from Console input.
         *
         * FLOW:
         * 1. Add Cars
         * 2. Add Racers
         * 3. Start Race
         * 4. Print Report
         */
        public void Run()
        {
            // ===============================
            // DUMMY DATA TESTING (NO INPUT)
            // ===============================

            // Creating cars in system (Controller handles business logic)
            Console.WriteLine(controller.AddCar("SuperCar", "Ferrari", "F8", "1HGCM82633A004352", 600));
            Console.WriteLine(controller.AddCar("TunedCar", "BMW", "M3", "WAUZZZ4G7JN123456", 450));

            // Registering racers and assigning cars via VIN
            Console.WriteLine(controller.AddRacer("ProfessionalRacer", "John", "1HGCM82633A004352"));
            Console.WriteLine(controller.AddRacer("StreetRacer", "Mike", "WAUZZZ4G7JN123456"));

            // Starting race between two racers (business logic inside Controller)
            Console.WriteLine(controller.BeginRace("John", "Mike"));

            // Printing final system report (state of all objects)
            Console.WriteLine(controller.Report());
        }
    }
}