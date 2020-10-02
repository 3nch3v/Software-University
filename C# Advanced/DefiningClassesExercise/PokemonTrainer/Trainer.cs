
using System.Collections.Generic;

namespace PokemonTrainer
{
    public class Trainer
    {
        private  string name;
        private int numberOfBadges;
        private List<Pokemon> pokemonsCollection;

        public Trainer(string name)
        {
            this.Name = name;
            this.NumberOfBadges = 0;
            this.PokemonsCollection = new List<Pokemon>();
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int NumberOfBadges
        {
            get { return this.numberOfBadges; }
            set { this.numberOfBadges = value; }
        }
        public List<Pokemon> PokemonsCollection
        {
            get { return this.pokemonsCollection; }
            set { this.pokemonsCollection = value; }
        }

        public void AddPokemon(Pokemon pokemon)
        {
            this.PokemonsCollection.Add(pokemon);
        }

        public void ReceiveBadge()
        {
            this.NumberOfBadges += 1;
        }
    }
}
