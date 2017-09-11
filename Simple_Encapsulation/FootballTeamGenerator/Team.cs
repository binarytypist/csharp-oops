using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem6_FootballTeamGenerator
{
    public class Team
    {
        // Encapsulation: internal state is hidden from external modification
        private string name;
        private IList<Player> players;

        // Constructor ensures team is always initialized properly
        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        // Team name validation (business rule: cannot be empty)
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        // Encapsulated player collection
        // Prevents external replacement of the list
        private IList<Player> Players
        {
            get { return this.players; }
            set { this.players = value; }
        }

        // Computed property: team rating based on players' stats
        public int Rating
        {
            get { return CalculateTeamRating(); }
        }

        // Business logic: calculates average team rating
        private int CalculateTeamRating()
        {
            if (!this.players.Any())
            {
                return 0;
            }

            // Aggregates player stats and computes average
            return (int)Math.Round(this.players.Average(p => p.Stats));
        }

        // Adds player to team (encapsulated collection modification)
        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        // Removes player by name with validation
        public void RemovePlayer(string playerName)
        {
            // Ensure player exists before removal
            if (!this.players.Any(p => p.Name == playerName))
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            // Find and remove player safely
            Player playerToRemove = this.players.First(p => p.Name == playerName);
            this.players.Remove(playerToRemove);
        }

        // String representation for output
        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}