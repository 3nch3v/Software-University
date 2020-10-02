using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string input;

            while ((input = Console.ReadLine()) != "Tournament")
            {  
                string[] currArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = currArgs[0];
                string pokemonName = currArgs[1];
                string pokemonElement = currArgs[2];
                int pokemonHealth = int.Parse(currArgs[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                Trainer trainer = trainers.FirstOrDefault(x => x.Name == trainerName);

                if (trainer != null)
                {
                    trainer.AddPokemon(pokemon);
                }

                else
                {
                    Trainer newTrainer = new Trainer(trainerName);
                    newTrainer.AddPokemon(pokemon);
                    trainers.Add(newTrainer);
                }
            }

            string comand;

            while ((comand = Console.ReadLine()) != "End")
            {
                var trainersWithElement = trainers
                    .Where(t => t.PokemonsCollection.Any(x => x.Element == comand))
                    .ToList();

                foreach (var trainer in trainersWithElement)
                {
                    trainer.ReceiveBadge();
                }

                foreach (var trainer in trainers)
                {
                    if (!trainer.PokemonsCollection.Any(x => x.Element == comand))
                    {
                        var pokemons = trainer.PokemonsCollection;

                        for (int i = 0; i < pokemons.Count; i++)
                        {
                            pokemons[i].LoseHealth();

                            if (pokemons[i].Health <= 0)
                            {
                                trainer.PokemonsCollection.Remove(pokemons[i]);
                                i--;
                            }
                        }
                    }
                }
            }


            trainers = trainers.OrderByDescending(b => b.NumberOfBadges).ToList();

            foreach (var trainer in trainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.PokemonsCollection.Count}");
            }

        }
    }
}
