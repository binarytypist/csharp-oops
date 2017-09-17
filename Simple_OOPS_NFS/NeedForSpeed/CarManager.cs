using System;
using System.Collections.Generic;
using System.Linq;

// Service class:
// Acts as the central coordinator for cars, races, and garage operations.
public class CarManager
{
    // Stores all registered cars using unique ID as key
    private Dictionary<int, Car> cars = new Dictionary<int, Car>();

    // Stores all opened races using unique ID as key
    private Dictionary<int, Race> races = new Dictionary<int, Race>();

    // Composition:
    // CarManager owns a Garage instance and delegates parking operations to it
    private Garage garage = new Garage();

    // Factory-like method:
    // Creates specific car types based on provided type
    public void Register(
        int id,
        string type,
        string brand,
        string model,
        int yearOfProduction,
        int horsepower,
        int acceleration,
        int suspension,
        int durability)
    {
        Car car = null;

        // Polymorphism:
        // Car reference points to different derived implementations
        switch (type)
        {
            case "Performance":
                car = new PerformanceCar(
                    brand,
                    model,
                    yearOfProduction,
                    horsepower,
                    acceleration,
                    suspension,
                    durability);
                break;

            case "Show":
                car = new ShowCar(
                    brand,
                    model,
                    yearOfProduction,
                    horsepower,
                    acceleration,
                    suspension,
                    durability);
                break;
        }

        // Prevent duplicate registrations
        if (!cars.ContainsKey(id))
        {
            cars.Add(id, car);
        }
    }

    // Retrieves information about a car
    public string Check(int id)
    {
        Car car = cars[id];

        return car.ToString();
    }

    // Opens standard races
    public void Open(
        int id,
        string type,
        int length,
        string route,
        int prizePool)
    {
        if (!races.ContainsKey(id))
        {
            switch (type)
            {
                case "Casual":
                    races[id] = new CasualRace(length, route, prizePool);
                    break;

                case "Drag":
                    races[id] = new DragRace(length, route, prizePool);
                    break;

                case "Drift":
                    races[id] = new DriftRace(length, route, prizePool);
                    break;
            }
        }
    }

    // Method overloading:
    // Opens race types requiring an additional parameter
    public void Open(
        int id,
        string type,
        int length,
        string route,
        int prizePool,
        int lapGold)
    {
        if (!races.ContainsKey(id))
        {
            switch (type)
            {
                case "TimeLimit":
                    races[id] = new TimeLimitRace(
                        length,
                        route,
                        prizePool,
                        lapGold);
                    break;

                case "Circuit":
                    races[id] = new CircuitRace(
                        length,
                        route,
                        prizePool,
                        lapGold);
                    break;
            }
        }
    }

    // Registers a car for a race
    public void Participate(int carId, int raceId)
    {
        Car car = cars[carId];
        Race race = races[raceId];

        // Parked cars cannot participate
        if (!garage.ParkedCars.Contains(car))
        {
            // TimeLimit race allows only one participant
            if ((race.GetType().Name == "TimeLimitRace" &&
                 race.Participants.Count == 0)
                || race.GetType().Name != "TimeLimitRace")
            {
                race.Participants.Add(car);
            }
        }
    }

    // Starts a race and returns results
    public string Start(int raceId)
    {
        Race race = races[raceId];

        // Polymorphism:
        // Each race type has its own ToString implementation
        string result = race.ToString();

        // Remove completed race
        if (race.Participants.Count > 0)
        {
            races.Remove(raceId);
        }

        return result;
    }

    // Parks a car
    public void Park(int carId)
    {
        Car car = cars[carId];

        // Cannot park a car currently participating in a race
        if (!races.Values.Any(r => r.Participants.Contains(car)))
        {
            if (!garage.ParkedCars.Contains(car))
            {
                garage.ParkedCars.Add(car);
            }
        }
    }

    // Removes a car from garage
    public void Unpark(int carId)
    {
        Car car = cars[carId];

        if (garage.ParkedCars.Contains(car))
        {
            garage.ParkedCars.Remove(car);
        }
    }

    // Applies tuning to all parked cars
    public void Tune(int tuneIndex, string addOn)
    {
        foreach (Car car in garage.ParkedCars)
        {
            // Polymorphism:
            // Different car types may override Tune()
            car.Tune(tuneIndex, addOn);
        }
    }
}