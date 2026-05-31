using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    // The Controller class implements the IController interface and serves as the main coordinator for the Car Racing application.
    // It manages the creation and storage of cars and racers, as well as the logic
    // for managing the racing events.
    // The Controller interacts with the CarRepository and RacerRepository to store and retrieve data, and it uses the Map class to 
    // handle the racing logic.
     
    public class Controller : IController
    {
        // Repositories for managing cars and racers
        // The CarRepository is responsible for storing and managing car instances, while the RacerRepository handles racer instances.
        // The Map instance is used to manage the racing logic, including determining the winner of races
        // and checking the availability of racers.
        // The Controller class provides methods for adding cars and racers, starting     

        private CarRepository cars = new CarRepository();
        private RacerRepository racers = new RacerRepository();
        private IMap map = new Map();


        // The AddCar method creates a new car instance based on the provided type and attributes, and adds it to the CarRepository.
        // It checks the type of car (SuperCar or TunedCar) and initializes the appropriate class. If the type is invalid, it throws an exception.
        // The AddRacer method creates a new racer instance based on the provided type and attributes, and adds it to the RacerRepository.

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car;

            if (type == nameof(SuperCar))
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == nameof(TunedCar))
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }

            cars.Add(car);
            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            IRacer racer;
            var targetCar = cars.FindBy(carVIN);
            if (targetCar is null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            if (type == nameof(ProfessionalRacer))
            {
                racer = new ProfessionalRacer(username, targetCar);
            }
            else if (type == nameof(StreetRacer))
            {
                racer = new StreetRacer(username, targetCar);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            racers.Add(racer);
            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            var firstRacer = racers.FindBy(racerOneUsername);
            var secondRacer = racers.FindBy(racerTwoUsername);

            if (firstRacer is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            if (secondRacer is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return map.StartRace(firstRacer, secondRacer);
        }

        public string Report()
        {
            var ordered = racers.Models
                .OrderByDescending(x => x.DrivingExperience)
                .ThenBy(x => x.Username)
                .ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var player in ordered)
            {
                sb.AppendLine($"{player.GetType().Name}: {player.Username}");
                sb.AppendLine($"--Driving behavior: {player.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {player.DrivingExperience}");
                sb.AppendLine($"--Car: {player.Car.Make} {player.Car.Model} ({player.Car.VIN})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}