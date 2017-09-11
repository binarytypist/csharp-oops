using System;

namespace Problem6_FootballTeamGenerator
{
    public class Player
    {
        // Encapsulation: all attributes are hidden from outside access
        private int dribble;
        private int endurance;
        private string name;
        private int passing;
        private int shooting;
        private int sprint;

        // Constructor ensures player is always created in a valid state
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        // Name validation: ensures meaningful player identity
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

        // Computed property: average player rating
        public int Stats
        {
            get { return CalculateAverageStats(); }
        }

        // Skill validation: ensures dribble is within valid range
        private int Dribble
        {
            get { return this.dribble; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Dribble should be between 0 and 100.");
                }

                this.dribble = value;
            }
        }

        // Skill validation: endurance
        private int Endurance
        {
            get { return this.endurance; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Endurance should be between 0 and 100.");
                }

                this.endurance = value;
            }
        }

        // Skill validation: passing
        private int Passing
        {
            get { return this.passing; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Passing should be between 0 and 100.");
                }

                this.passing = value;
            }
        }

        // Skill validation: shooting
        private int Shooting
        {
            get { return this.shooting; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Shooting should be between 0 and 100.");
                }

                this.shooting = value;
            }
        }

        // Skill validation: sprint
        private int Sprint
        {
            get { return this.sprint; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Sprint should be between 0 and 100.");
                }

                this.sprint = value;
            }
        }

        // Business logic: calculates overall player rating
        // Encapsulated inside the class (not exposed externally)
        private int CalculateAverageStats()
        {
            double average =
                (this.Dribble +
                 this.Endurance +
                 this.Passing +
                 this.Shooting +
                 this.Sprint) / 5.0;

            return (int)Math.Round(average);
        }
    }
}