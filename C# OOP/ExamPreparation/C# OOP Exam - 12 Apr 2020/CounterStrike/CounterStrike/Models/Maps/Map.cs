using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = players.Where(p => p.GetType() == typeof(Terrorist));
            var counterTerrorists = players.Where(p => p.GetType() == typeof(CounterTerrorist));

            while (true)
            {
                if (terrorists.All(t => t.IsAlive == false) || counterTerrorists.All(ct => ct.IsAlive == false))
                {
                    break;
                }


                foreach (var terrorist in terrorists)
                {
                    if (terrorist.IsAlive)
                    {
                        foreach (var counterTerrorist in counterTerrorists)
                        {
                            if (counterTerrorist.IsAlive)
                            {
                                counterTerrorist.TakeDamage(terrorist.Gun.Fire());
                            }
                        }
                    }
                }

                foreach (var counterTerrorist in counterTerrorists)
                {
                    if (counterTerrorist.IsAlive)
                    {
                        foreach (var terrorist in terrorists)
                        {
                            if (terrorist.IsAlive)
                            {
                                terrorist.TakeDamage(counterTerrorist.Gun.Fire());
                            }
                        }
                    }
                }
            }

            if (counterTerrorists.Any(ct => ct.IsAlive))
            {
               return "Counter Terrorist wins!";
            }

            return "Terrorist wins!";
        }
    }
}
