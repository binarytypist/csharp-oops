using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem6_FootballTeamGenerator
{
    class Startup
    {
        private static void Main(string[] args)
        {
            // Stores all created teams in memory
            List<Team> teams = new List<Team>();

            // Dummy input data replaces Console.ReadLine()
            Queue<string> commands = new Queue<string>(new[]
            {
                "Team;Barcelona",
                "Team;RealMadrid",
                "Add;Barcelona;Messi;95;90;96;92;98",
                "Add;Barcelona;Xavi;88;85;87;90;80",
                "Add;RealMadrid;Ronaldo;93;92;94;90;97",
                "Rating;Barcelona",
                "Rating;RealMadrid",
                "Remove;Barcelona;Xavi",
                "Rating;Barcelona",
                "END"
            });

            // Process commands until END
            while (commands.Count > 0)
            {
                var input = commands.Dequeue();

                if (input == "END")
                {
                    break;
                }

                var tokens = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];

                try
                {
                    switch (command)
                    {
                        case "Team":
                            // Create new team
                            teams.Add(new Team(tokens[1]));
                            break;

                        case "Add":
                            // Ensure team exists before adding player
                            if (!teams.Any(t => t.Name == tokens[1]))
                            {
                                throw new ArgumentException($"Team {tokens[1]} does not exist.");
                            }

                            var team = teams.First(t => t.Name == tokens[1]);

                            // Create and add player
                            team.AddPlayer(new Player(
                                tokens[2],
                                int.Parse(tokens[3]),
                                int.Parse(tokens[4]),
                                int.Parse(tokens[5]),
                                int.Parse(tokens[6]),
                                int.Parse(tokens[7])
                            ));

                            break;

                        case "Remove":
                            // Remove player from team
                            var teamToRemove = teams.First(t => t.Name == tokens[1]);
                            teamToRemove.RemovePlayer(tokens[2]);
                            break;

                        case "Rating":
                            // Validate team existence
                            if (!teams.Any(t => t.Name == tokens[1]))
                            {
                                throw new ArgumentException($"Team {tokens[1]} does not exist.");
                            }

                            // Print team rating (ToString handles formatting)
                            Console.WriteLine(teams.First(t => t.Name == tokens[1]));
                            break;
                    }
                }
                catch (Exception e)
                {
                    // Centralized error handling
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}