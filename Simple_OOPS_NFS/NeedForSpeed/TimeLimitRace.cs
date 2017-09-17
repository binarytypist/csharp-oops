using System;
using System.Linq;
using System.Text;

// Inheritance:
// TimeLimitRace is a specialized Race type where performance is measured against a target time.
public class TimeLimitRace : Race
{
    // Encapsulation:
    // GoldTime defines the threshold for best performance
    private int goldTime;

    // Internal calculated prize based on result tier
    private int prizeMoney;

    // GoldTime property (benchmark time for best result)
    public int GoldTime
    {
        get { return this.goldTime; }
        set { this.goldTime = value; }
    }

    // Constructor initializes base Race and sets gold time threshold
    public TimeLimitRace(int length, string route, int prizePool, int goldTime)
        : base(length, route, prizePool)
    {
        this.GoldTime = goldTime;
    }

    // Polymorphism:
    // Each race type defines its own performance calculation logic
    public override int GetPerformancePoints(Car car)
    {
        // Time-based performance formula
        return this.Length * ((car.HorsePower / 100) * car.Acceleration);
    }

    // Polymorphism:
    // Custom race result formatting for time-based race
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        if (this.Participants.Count > 0)
        {
            sb.AppendLine($"{this.Route} - {this.Length}");

            // Only first participant is considered (time trial logic)
            var winner = this.Participants.FirstOrDefault();

            sb.AppendLine($"{winner.Brand} {winner.Model} - {GetPerformancePoints(winner)} s.");

            // Determine medal type and prize based on performance
            sb.AppendLine($"{GetTimeType(GetPerformancePoints(winner))} Time, ${this.prizeMoney}.");
        }
        else
        {
            sb.AppendLine("Cannot start the race with zero participants.");
        }

        return sb.ToString().Trim();
    }

    // Encapsulated business logic:
    // Determines medal tier and assigns prize money
    private string GetTimeType(int timePoints)
    {
        if (timePoints <= this.GoldTime)
        {
            this.prizeMoney = this.PrizePool;
            return "Gold";
        }
        else if (timePoints <= this.GoldTime + 15)
        {
            this.prizeMoney = (this.PrizePool * 50) / 100;
            return "Silver";
        }
        else
        {
            this.prizeMoney = (this.PrizePool * 30) / 100;
            return "Bronze";
        }
    }
}