
namespace CarRacing.Core.Contracts
{
    /// <summary>
    /// Defines the core operations for the Car Racing system.
    /// Acts as a contract between the Engine and the business logic layer (Controller).
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// Adds a new car to the system.
        /// </summary>
        /// <param name="type">Type of car (e.g., MuscleCar, SportsCar)</param>
        /// <param name="make">Car manufacturer</param>
        /// <param name="model">Car model</param>
        /// <param name="VIN">Unique Vehicle Identification Number</param>
        /// <param name="horsePower">Engine power of the car</param>
        /// <returns>Status message about the operation</returns>
        string AddCar(string type, string make, string model, string VIN, int horsePower);

        /// <summary>
        /// Adds a new racer and assigns a car to them using VIN.
        /// </summary>
        /// <param name="type">Type of racer (e.g., Professional, Amateur)</param>
        /// <param name="username">Unique racer username</param>
        /// <param name="carVIN">VIN of the car assigned to the racer</param>
        /// <returns>Status message about the operation</returns>
        string AddRacer(string type, string username, string carVIN);

        /// <summary>
        /// Starts a race between two racers.
        /// The winner is determined based on race logic (implemented in Controller).
        /// </summary>
        /// <param name="racerOneUsername">First racer username</param>
        /// <param name="racerTwoUsername">Second racer username</param>
        /// <returns>Result message of the race</returns>
        string BeginRace(string racerOneUsername, string racerTwoUsername);

        /// <summary>
        /// Generates a report of all racers, cars, and system status.
        /// </summary>
        /// <returns>Formatted report string</returns>
        string Report();
    }
}