using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> vloggers = new Dictionary<string, List<string>>();
            Dictionary<string, int[]> userNumberOfFollows = new Dictionary<string, int[]>();
            string inputLines = Console.ReadLine();

            while (inputLines != "Statistics")
            {
                string[] tokens = inputLines.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string username = tokens[0];
                string command = tokens[1];

                if (command == "joined")
                {
                    if (!vloggers.ContainsKey(username))
                    {
                        vloggers[username] = new List<string>();
                        userNumberOfFollows[username] = new int[2];
                    }
                }
                else if (command == "followed")
                {
                    string userToFollow = tokens[2];
                    if (vloggers.ContainsKey(username) && vloggers.ContainsKey(userToFollow))
                    {
                        if (!vloggers[userToFollow].Contains(username) && username != userToFollow)
                        {
                            vloggers[userToFollow].Add(username);
                            userNumberOfFollows[userToFollow][0]++;
                            userNumberOfFollows[username][1]++;
                        }
                    }
                }

                inputLines = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var orderUsersAndFollowers = userNumberOfFollows.OrderByDescending(u => u.Value[0]).ThenBy(u => u.Value[1])
                .ToDictionary(x => x.Key, x => x.Value);
            string userToRemove = "";
            int count = 1;

            foreach (KeyValuePair<string, int[]> kvp in orderUsersAndFollowers)
            {
                userToRemove = kvp.Key;
                Console.WriteLine($"{count}. {kvp.Key} : {kvp.Value[0]} followers, {kvp.Value[1]} following");
                if (vloggers[kvp.Key].Count > 0)
                {
                    foreach (string follower in vloggers[kvp.Key].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                break;
            }

            count++;
            orderUsersAndFollowers.Remove(userToRemove);
            foreach (KeyValuePair<string, int[]> kvp in orderUsersAndFollowers)
            {
                Console.WriteLine($"{count}. {kvp.Key} : {kvp.Value[0]} followers, {kvp.Value[1]} following");
                count++;
            }

        }
    }
}
