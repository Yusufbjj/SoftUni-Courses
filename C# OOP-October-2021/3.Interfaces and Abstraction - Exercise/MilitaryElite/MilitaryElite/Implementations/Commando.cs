using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Implementations
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<IMission>();
        }

        public List<IMission> Missions { get; set; }
        public void CompleteMission(string codeName)
        {
            var mission = this.Missions.FirstOrDefault(m => m.CodeName == codeName);

            mission.Status = Status.Finished;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();


            string baseInfo = base.ToString();

            sb.AppendLine(baseInfo);
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Missions:");

            foreach (var mission in Missions)
            {
                sb.AppendLine($"  {mission}");
            }

            return sb.ToString().TrimEnd();

        }
    }
}
