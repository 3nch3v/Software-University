
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> players;

        public Guild(string name, int capacity)
        {
            this.players = new List<Player>();
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.players.Count;

        public void AddPlayer(Player player)
        {
            if (this.players.Count < this.Capacity)
            {
                this.players.Add(player);
            }   
        }

        public bool RemovePlayer(string name)
        {
            bool isExisting = false;

            if (this.players.Any(p => p.Name == name))
            {
                isExisting = true;
                this.players.RemoveAll(p => p.Name == name);
            }

            return isExisting;
        }

        public void PromotePlayer(string name)
        {
            Player currPlayer = this.players.FirstOrDefault(p => p.Name == name);

            if (currPlayer != null && currPlayer.Rank == "Trial")
            {
                currPlayer.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player currPlayer = this.players.FirstOrDefault(p => p.Name == name);

            if (currPlayer != null && currPlayer.Rank == "Member")
            {
                currPlayer.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] kickedPlayers = this.players.Where(p => p.Class == @class).ToArray();

            this.players.RemoveAll(p => p.Class == @class);

            return kickedPlayers;
        }

        public string Report()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in this.players)
            {
                output.AppendLine($"Player {player.Name}: {player.Class}");
                output.AppendLine($"Rank: {player.Rank}");
                output.AppendLine($"Description: {player.Description}");
            }

            return output.ToString().Trim(); ;
        }
    }
}
