using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int numberOfHeroes = int.Parse(Console.ReadLine());

            while (true)
            {
                if (heroes.Count == numberOfHeroes)
                {
                    break;
                }

                BaseHero newHero = null;

                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    switch (heroType)
                    {
                        case "Druid": newHero = new Druid(heroName); break;
                        case "Paladin": newHero = new Paladin(heroName); break;
                        case "Rogue": newHero = new Rogue(heroName); break;
                        case "Warrior": newHero = new Warrior(heroName); break;

                        default:
                            throw new ArgumentException("Invalid hero!");
                    }

                    heroes.Add(newHero);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);

                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            int powerSum = 0;


            foreach (var hero in heroes)
            {
                powerSum += hero.Power;
                Console.WriteLine(hero.CastAbility());
            }


            if (powerSum >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
