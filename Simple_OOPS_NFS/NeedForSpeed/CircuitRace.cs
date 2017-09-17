using System;
using System.Linq;
using System.Text;

// Inheritance:
// CircuitRace extends the base Race class and adds lap-based racing behavior.
public class CircuitRace : Race
{
    // Encapsulation: stores number of laps for the circuit race
    private int laps;

    // Constructor initializes common Race properties and circuit-specific laps
    public CircuitRace(int length, string route, int prizePool, int laps)
        : base(length, route, prizePool)
    {
        this.Laps = laps;
    }

    // Property exposes lap count
    public int Laps
    {
        get { return this.laps; }
        set { this.laps = value; }
    }

    // Polymorphism:
    // Circuit race defines its own performance point calculation.
    public override int GetPerformancePoints(Car car)
    {
        // Performance is based on:
        // - Power-to-acceleration ratio
        // - Suspension
        // - Durability
        return (car.HorsePower / car.Acceleration)
               + car.Suspension
               + car.Durability;
    }

    // Polymorphism:
    // Overrides Race.ToString() to provide circuit-specific race results.
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        // Business rule:
        // Race cannot start without participants.
        if (this.Participants.Count > 0)
        {
            // Total race distance = track length × laps
            sb.AppendLine($"{this.Route} - {this.Length * this.Laps}");

            // Race wear and tear:
            // Every participant loses durability after completing the circuit.
            this.Participants
                .ToList()
                .ForEach(p => p.Durability -= (this.Laps * (this.Length * this.Length)));

            // Ranking:
            // Top 4 cars ordered by performance points.
            var winners = this.Participants
                .OrderByDescending(p => this.GetPerformancePoints(p))
                .Take(4)
                .ToList();

            int prize = 0;

            // Prize distribution:
            // 1st = 40%
            // 2nd = 30%
            // 3rd = 20%
            // 4th = 10%
            for (int i = 0; i < winners.Count; i++)
            {
                if (i == 0)
                {
                    prize = this.PrizePool * 40 / 100;
                }
                else if (i == 1)
                {
                    prize = this.PrizePool * 30 / 100;
                }
                else if (i == 2)
                {
                    prize = this.PrizePool * 20 / 100;
                }
                else if (i == 3)
                {
                    prize = this.PrizePool * 10 / 100;
                }

                // Race standings output
                sb.AppendLine(
                    $"{i + 1}. " +
                    $"{winners[i].Brand} " +
                    $"{winners[i].Model} " +
                    $"{this.GetPerformancePoints(winners[i])}PP - " +
                    $"${prize}");
            }
        }
        else
        {
            // Validation:
            // Circuit race requires at least one participant.
            sb.AppendLine("Cannot start the race with zero participants.");
        }

        return sb.ToString().Trim();
    }
}