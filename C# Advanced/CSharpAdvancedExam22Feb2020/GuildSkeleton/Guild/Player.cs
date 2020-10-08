
using System.Diagnostics;
using System.Text;

namespace Guild
{
    public class Player
    {
        public Player(string name, string @class)
        {
            this.Name = name;
            this.Class = @class;
            this.Rank = "Trial";
            this.Description = "n/a";
        }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; } //"Trial" by default
        public string Description { get; set; }  //"n/a" by default

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Player {this.Name}: {this.Class}");
            output.AppendLine($"Rank: {this.Rank}");
            output.AppendLine($"Description: {this.Description}");

            return output.ToString().Trim();
        }
    }
}
