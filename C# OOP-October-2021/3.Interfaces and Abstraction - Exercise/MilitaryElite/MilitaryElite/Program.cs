using System;
using System.Collections.Generic;
using MilitaryElite.Implementations;
using MilitaryElite.Interfaces;

namespace MilitaryElite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<int, ISoldier> soldiers = new Dictionary<int, ISoldier>();

            string input = Console.ReadLine();

            while (input != "End")
            {

                var inputInfo = input.Split();
                string action = inputInfo[0];
                int id = int.Parse(inputInfo[1]);
                string firstName = inputInfo[2];
                string lastName = inputInfo[3];

                if (action == "Private")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);

                    IPrivate @private = new Private(id, firstName, lastName, salary);

                    soldiers.Add(id, @private);
                }
                else if (action == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);

                    ILieutenantGeneral leitanantgeGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < inputInfo.Length; i++)
                    {
                        int inputId = int.Parse(inputInfo[i]);

                        IPrivate @private = soldiers[inputId] as IPrivate;

                        leitanantgeGeneral.Privates.Add(@private);

                    }

                    soldiers.Add(id, leitanantgeGeneral);

                }
                else if (action == "Engineer")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);
                    string corpAsString = inputInfo[5];

                    bool isValidEnum = Enum.TryParse(corpAsString, out Corps result);

                    if (!isValidEnum)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, result);

                    for (int i = 6; i < inputInfo.Length; i += 2)
                    {
                        string partName = inputInfo[i];
                        int hours = int.Parse(inputInfo[i + 1]);

                        Repair repair = new Repair(partName, hours);

                        engineer.Repairs.Add(repair);

                    }

                    soldiers.Add(id, engineer);
                }
                else if (action == "Commando")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);
                    string corpAsString = inputInfo[5];

                    bool isValidEnum = Enum.TryParse(corpAsString, out Corps result);

                    if (!isValidEnum)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    ICommando commando = new Commando(id, firstName, lastName, salary, result);

                    for (int i = 6; i < inputInfo.Length; i += 2)
                    {
                        string missionCode = inputInfo[i];
                        string missionStateAsString = inputInfo[i + 1];

                        bool isValidMission = Enum.TryParse(missionStateAsString, out Status status);

                        if (!isValidMission)
                        {
                            continue;
                        }

                        IMission mission = new Mission(missionCode, status);

                        commando.Missions.Add(mission);
                    }

                    soldiers.Add(id, commando);
                }
                else if (action == "Spy")
                {
                    int codeNumber = int.Parse(inputInfo[4]);

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                    soldiers.Add(id, spy);
                }


                input = Console.ReadLine();
            }

            foreach (KeyValuePair<int, ISoldier> soldier in soldiers)
            {
                Console.WriteLine(soldier.Value.ToString());
            }
        }
    }
}
