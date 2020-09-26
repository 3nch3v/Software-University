using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            string examInfo;

            while ((examInfo = Console.ReadLine()) != "end of contests")
            {
                string[] currContest = examInfo.Split(":", StringSplitOptions.RemoveEmptyEntries);

                string contestName = currContest[0];
                string contestPassword = currContest[1];

                if (!contests.ContainsKey(contestName))
                {
                    contests.Add(contestName, null);
                }

                contests[contestName] = contestPassword;
            }

            Dictionary<string, Dictionary<string, int>> submissions = new Dictionary<string, Dictionary<string, int>>();

            string input;

            while ((input = Console.ReadLine()) != "end of submissions")
            { 
                string[] currArgs = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = currArgs[0];
                string password = currArgs[1];
                string username = currArgs[2];
                int points = int.Parse(currArgs[3]);

                if (contests.ContainsKey(contest)
                    && contests[contest] == password
                    && !submissions.ContainsKey(username))
                {
                    submissions.Add(username, new Dictionary<string, int>());
                    submissions[username].Add(contest, 0);
                }

                else if (contests.ContainsKey(contest)
                         && contests[contest] == password
                         && submissions.ContainsKey(username)
                         && !submissions[username].ContainsKey(contest))
                {
                    submissions[username].Add(contest, 0);
                }

                if (submissions.ContainsKey(username) && submissions[username].ContainsKey(contest))
                {
                    if (submissions[username][contest] < points)
                    {
                        submissions[username][contest] = points;
                    }
                }
            }

            string bestCandidate = string.Empty;
            int totalPoints = 0;

            foreach (var (candidate, candidateContests) in submissions)
            {
                var candidatePoints = candidateContests.Values.Sum();

                if (totalPoints < candidatePoints)
                {
                    totalPoints = candidatePoints;
                    bestCandidate = candidate;
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {totalPoints} points.");

            Console.WriteLine("Ranking:");

            submissions = submissions.OrderBy(kvp => kvp.Key).ToDictionary(n => n.Key, r => r.Value);

            foreach (var kvp in submissions)
            {
                Console.WriteLine(kvp.Key);

                Dictionary<string, int> currResults = kvp.Value
                    .OrderByDescending(r => r.Value)
                    .ToDictionary(c => c.Key, r => r.Value);

                foreach (var (contest, result) in currResults)
                {
                    Console.WriteLine($"#  {contest} -> {result}");
                }
            }
        }
    }
}
