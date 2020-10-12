using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            data = new List<Hero>();
        }

        public int Count => data.Count;

        public void Add(Hero hero)
        {
            data.Add(hero);
        }
        public void Remove(string name)
        {
            if (data.Any(h => h.Name == name))
            {
                data.RemoveAll(h => h.Name == name);
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            Hero hero = data.OrderByDescending(h => h.Item.Strength).First();

            return hero;     
        }

        public Hero GetHeroWithHighestAbility()
        {
            Hero hero = data.OrderByDescending(h => h.Item.Ability).First();

            return hero;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            Hero hero = data.OrderByDescending(h => h.Item.Intelligence).First();

            return hero;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hero in data)
            {
                sb.AppendLine(hero.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
