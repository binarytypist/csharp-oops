using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Abstraction:
// Race defines a general blueprint for all race types.
// It cannot be instantiated directly.
public abstract class Race
{
    // Encapsulation:
    // Core race properties are hidden and protected from direct external modification
    private int length;
    private string route;
    private int prizePool;
    private IList<Car> participants;

    // Constructor initializes shared race state
    public Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;

        // Composition:
        // A Race "has many" Cars (participants)
        this.Participants = new List<Car>();
    }

    // Participants in the race
    public IList<Car> Participants
    {
        get { return this.participants; }
        protected set { this.participants = value; }
    }

    // Prize pool available for winners
    public int PrizePool
    {
        get { return this.prizePool; }
        protected set { this.prizePool = value; }
    }

    // Race route name
    public string Route
    {
        get { return this.route; }
        protected set { this.route = value; }
    }

    // Race length (distance)
    public int Length
    {
        get { return this.length; }
        protected set { this.length = value; }
    }

    // Polymorphism:
    // Each race type must implement its own performance scoring logic
    public abstract int GetPerformancePoints(Car car);

    // Template method:
    // Defines how a race result is formatted, while allowing custom scoring via GetPerformancePoints
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        // Validation:
        // Race cannot proceed without participants
        if (this.Participants.Count > 0)
        {
            sb.AppendLine($"{this.Route} - {this.Length}");

            // Ranking logic (shared across all race types)
            var winners = this.Participants
                .OrderByDescending(p => this.GetPerformancePoints(p))
                .Take(3)
                .ToList();

            int prize = 0;

            // Prize distribution:
            // 1st = 50%
            // 2nd = 30%
            // 3rd = 20%
            for (int i = 0; i < winners.Count; i++)
            {
                if (i == 0)
                {
                    prize = this.PrizePool * 50 / 100;
                }
                else if (i == 1)
                {
                    prize = this.PrizePool * 30 / 100;
                }
                else if (i == 2)
                {
                    prize = this.PrizePool * 20 / 100;
                }

                sb.AppendLine(
                    $"{i + 1}. " +
                    $"{winners[i].Brand} {winners[i].Model} " +
                    $"{this.GetPerformancePoints(winners[i])}PP - " +
                    $"${prize}");
            }
        }
        else
        {
            sb.AppendLine("Cannot start the race with zero participants.");
        }

        return sb.ToString().Trim();
    }
}