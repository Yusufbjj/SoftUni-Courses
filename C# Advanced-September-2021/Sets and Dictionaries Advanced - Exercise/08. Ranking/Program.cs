using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.input is lines of "{contest}:{password for contest}" until "end of contests"
            //2.create dictionary for these lines 
            //3.use while loop
            //4.fill in dictionary with the "{contest}:{password for contest}"
            // 5.after "end of contests" will receive  inputs in format "{contest}=>{password}=>{username}=>{points}" untill "end of submissions".
            //6. Make a second dictionary for the second lines of input
            //7.•	Check if the contest is valid (if you received it in the first type of input)
            //8.•	Check if the password is correct for the given contest
            //9.•	Save the user with the contest they take part in  and the points the user has in the given contest.
            //10.If you receive the same contest and the same user, update the points only if the new ones are more than the older ones.
            //11. Print user with the most points in the format "Best candidate is {user} with total {total points} points.". 
            //12.Print all students ordered by their names. For each user, print each contest with the points in descending order in the following format
            //"{user1 name}
            // #  {contest1} -> {points}
            // #  {contest2} -> {points}
            // {user2 name}
            // …"
            string line = Console.ReadLine();
            Dictionary<string, string> contestAndPassword = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> userContestPoints =
                new Dictionary<string, Dictionary<string, int>>();
            while (line != "end of submissions")
            {
                while (line != "end of contests" && !line.Contains("=>"))
                {
                    string[] tokens = line.Split(":", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string contest = tokens[0];
                    string password = tokens[1];
                    contestAndPassword.Add(contest, password);
                    line = Console.ReadLine();
                }
                line = Console.ReadLine();
                if (line == "end of submissions")
                {
                    break;
                }
                string[] tokens2 = line.Split("=>", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string contestSecondLine = tokens2[0];
                string passwordSecondLine = tokens2[1];
                string user = tokens2[2];
                int points = int.Parse(tokens2[3]);
                if (contestAndPassword.ContainsKey(contestSecondLine) && contestAndPassword[contestSecondLine] == passwordSecondLine)
                {
                    if (!userContestPoints.ContainsKey(user))
                    {
                        userContestPoints.Add(user, new Dictionary<string, int>());
                        if (!userContestPoints[user].ContainsKey(contestSecondLine))
                        {
                            userContestPoints[user][contestSecondLine] = 0;
                        }
                        userContestPoints[user][contestSecondLine] = points;
                    }
                    else
                    {
                        if (!userContestPoints[user].ContainsKey(contestSecondLine))
                        {
                            userContestPoints[user][contestSecondLine] = 0;
                        }
                        if (points > userContestPoints[user][contestSecondLine])
                        {
                            userContestPoints[user][contestSecondLine] = points;

                        }
                    }
                }
            }

            int maxPoints = 0;
            string bestCandidate = String.Empty;
            foreach (var kvp in userContestPoints)
            {
                int currentMaxPoints = 0;
                string currentBestCandidate = String.Empty;
                foreach (KeyValuePair<string, int> contestAndPointsKeyValuePair in kvp.Value)
                {
                    currentBestCandidate = kvp.Key;
                    currentMaxPoints += contestAndPointsKeyValuePair.Value;
                }

                if (maxPoints < currentMaxPoints)
                {
                    bestCandidate = currentBestCandidate;
                    maxPoints = currentMaxPoints;
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {maxPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var keyValuePair in userContestPoints.OrderBy(name => name.Key))
            {
                Console.WriteLine(keyValuePair.Key);
                foreach (KeyValuePair<string, int> contestAndPoints in keyValuePair.Value.OrderByDescending(kvp => kvp.Value))
                {
                    Console.WriteLine($"#  {contestAndPoints.Key} -> {contestAndPoints.Value}");
                }
            }

        }
    }
}
