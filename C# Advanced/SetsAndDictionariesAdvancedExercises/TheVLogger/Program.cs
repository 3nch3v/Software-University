using System;
using System.Collections.Generic;
using System.Linq;

namespace TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> following = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> followers = new Dictionary<string, List<string>>();

            string cmd;

            while ((cmd = Console.ReadLine()) != "Statistics")
            {
                if (cmd.Contains("joined"))
                {
                    string[] currAgrs = cmd.Split(" joined ", StringSplitOptions.RemoveEmptyEntries);
                    string vloggerName = currAgrs[0];

                    if (!following.ContainsKey(vloggerName))
                    {
                        following.Add(vloggerName, new List<string>());
                    }

                    if (!followers.ContainsKey(vloggerName))
                    {
                        followers.Add(vloggerName, new List<string>());
                    }
                }

                else if (cmd.Contains("followed"))
                {
                    string[] currAgrs = cmd.Split(" followed ", StringSplitOptions.RemoveEmptyEntries);

                    string followerName = currAgrs[0];
                    string followedName = currAgrs[1];

                    if (following.ContainsKey(followerName)
                        && following.ContainsKey(followedName)
                        && followerName != followedName
                        && !following[followerName].Contains(followedName))
                    {
                        following[followerName].Add(followedName);
                        followers[followedName].Add(followerName);
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {following.Count} vloggers in its logs.");

            followers = followers
                .OrderByDescending(n => n.Value.Count)
                .ThenBy(kvp => following[kvp.Key].Count)
                .ToDictionary(v => v.Key, n => n.Value);

            int counter = 1;

            foreach (var vlogger in followers)
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value.Count} followers, {following[vlogger.Key].Count} following");

                if (counter == 1)
                {
                    foreach (var vloggerFollowers in vlogger.Value.OrderBy(n => n))
                    {
                        Console.WriteLine($"*  {vloggerFollowers}");
                    }
                }

                counter++;
            }
        }
    }
}
