using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] currArgs = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string command = currArgs[0];
                string teamName = currArgs[1];

                try
                {
                    switch (command)
                    {
                        case "Team":
                            teams.Add(new Team(teamName));
                            break;

                        case "Add":
                            if (teams.All(t => t.Name != teamName))
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }
                            else
                            {
                                string name = currArgs[2];
                                int endurance = int.Parse(currArgs[3]);
                                int sprint = int.Parse(currArgs[4]);
                                int dribble = int.Parse(currArgs[5]);
                                int passing = int.Parse(currArgs[6]);
                                int shooting = int.Parse(currArgs[7]);

                                Team currentTeam = teams.FirstOrDefault(t => t.Name == teamName);
                                currentTeam.AddPlayer(new Player(name, endurance, sprint, dribble, passing, shooting));
                            }
                            break;

                        case "Remove":
                            string playerName = currArgs[2];
                            Team teamToRemove = teams.FirstOrDefault(t => t.Name == teamName);
                            teamToRemove.RemovePlayer(playerName);
                            break;

                        case "Rating":
                            if (teams.All(t => t.Name != teamName))
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }
                            else
                            {
                                Console.WriteLine(teams.FirstOrDefault(t => t.Name == teamName).ToString());
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
    }
}
