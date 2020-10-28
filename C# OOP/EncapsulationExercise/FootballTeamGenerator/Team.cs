
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }

        public int Rating => CalculateRating();

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            if (players.All(p => p.Name != playerName))
            {
                throw new ArgumentException($"Player {playerName} is not in {Name} team.");
            }

            players.RemoveAll((p => p.Name == playerName));
        }

        private int CalculateRating()
        {
            if (players.Any())
            {
                return (int)Math.Round(players.Average(p => p.Stats));
            }

            return 0;
        }

        public override string ToString()
        {
            return $"{Name} - {Rating}";
        }
    }
}
