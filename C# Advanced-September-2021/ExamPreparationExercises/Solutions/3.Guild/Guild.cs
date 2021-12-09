using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.roster = new List<Player>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get => this.roster.Count;
        }

        public void AddPlayer(Player player)
        {
            if (Capacity > roster.Count)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            var player = this.roster.FirstOrDefault(p => p.Name == name);

            return this.roster.Remove(player);
        }

        public void PromotePlayer(string name)
        {
            var player = this.roster.FirstOrDefault(p => p.Name == name);

            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            var player = this.roster.FirstOrDefault(p => p.Name == name);

            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {

            List<Player> removedPlayers = new List<Player>();

            foreach (Player player in roster.ToList())
            {
                if (player.Class == @class)
                {
                    roster.Remove(player);
                    removedPlayers.Add(player);
                }
            }

            return removedPlayers.ToArray();

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {Name}");

            foreach (Player player in roster)
            {
                sb.AppendLine(player.ToString());
            }


            return sb.ToString().TrimEnd();
        }
    }
}
