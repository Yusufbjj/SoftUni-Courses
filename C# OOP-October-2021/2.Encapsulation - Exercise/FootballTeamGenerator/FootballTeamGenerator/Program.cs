using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            Dictionary<string, Player> players = new Dictionary<string, Player>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                var commandInfo = command.Split(";");
                var action = commandInfo[0];

                try
                {
                    if (action == "Team")
                    {
                        string teamName = commandInfo[1];
                        Team team = new Team(teamName);
                        teams.Add(teamName, team);
                    }
                    else if (action == "Add")
                    {
                        string teamName = commandInfo[1];

                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            command = Console.ReadLine();
                            continue;
                        }


                        string playerName = commandInfo[2];
                        int endurance = int.Parse(commandInfo[3]);
                        int sprint = int.Parse(commandInfo[4]);
                        int dribble = int.Parse(commandInfo[5]);
                        int passing = int.Parse(commandInfo[6]);
                        int shooting = int.Parse(commandInfo[7]);

                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        players.Add(playerName, player);

                        teams[teamName].AddPlayer(player);



                    }
                    else if (action == "Remove")
                    {
                        string teamName = commandInfo[1];
                        string playerName = commandInfo[2];

                        if (teams.ContainsKey(teamName))
                        {

                            teams[teamName].RemovePlayer(playerName);

                        }

                    }
                    else if (action == "Rating")
                    {
                        string teamName = commandInfo[1];

                        if (teams.ContainsKey(teamName))
                        {
                            var rating = teams[teamName].Rating;
                            Console.WriteLine($"{teamName} - {rating}");
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }

                command = Console.ReadLine();
            }
        }
    }
}
