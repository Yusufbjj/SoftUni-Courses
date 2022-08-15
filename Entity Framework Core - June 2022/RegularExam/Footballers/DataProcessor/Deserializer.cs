using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Footballers.Data.Models;
using Footballers.Data.Models.Enums;
using Footballers.DataProcessor.ImportDto;
using System.Linq;
using Newtonsoft.Json;
using Team = Footballers.Data.Models.Team;

namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var coachDtos = XmlConverter
                .Deserializer<ImportCoachDto>(xmlString, "Coaches");

            var sb = new StringBuilder();

            var coaches = new HashSet<Coach>();

            foreach (var coachDto in coachDtos)
            {
                if (!IsValid(coachDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var coach = new Coach
                {
                    Name = coachDto.Name,
                    Nationality = coachDto.Nationality,
                };

                var footballers = new HashSet<Footballer>();

                foreach (var footballer in coachDto.Footballers)
                {
                    if (!IsValid(footballer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isContractStartDateValid = DateTime.TryParseExact(footballer.ContractStartDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime footballerStartDate);

                    if (!isContractStartDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isContractEndDateValid = DateTime.TryParseExact(footballer.ContractEndDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime footballerEndDate);

                    if (!isContractEndDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (footballerStartDate >= footballerEndDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var validFootbaler = new Footballer
                    {
                        Name = footballer.Name,
                        ContractStartDate = footballerStartDate,
                        ContractEndDate = footballerEndDate,
                        BestSkillType = (BestSkillType)footballer.BestSkillType,
                        PositionType = (PositionType)footballer.PositionType
                    };

                    footballers.Add(validFootbaler);
                }

                coach.Footballers = footballers;
                coaches.Add(coach);

                sb.AppendLine($"Successfully imported coach - {coach.Name} with {coach.Footballers.Count()} footballers.");
            }

            context.Coaches.AddRange(coaches);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportTeamDto[] teamsDto = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);

            List<Team> teams = new List<Team>();

            foreach (var teamDto in teamsDto)
            {
                if (!IsValid(teamDto) || teamDto.Trophies<=0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Team team = new Team()
                {
                    Name = teamDto.Name,
                    Nationality = teamDto.Nationality,
                    Trophies = teamDto.Trophies
                };

                var footballers = new List<TeamFootballer>();

                foreach (var footballerDto in teamDto.Footballers.Distinct())
                {
                    var footballer = context.Footballers
                        .FirstOrDefault(f => f.Id == footballerDto);

                    if (footballer==null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var teamFootballer = new TeamFootballer()
                    {
                        Team = team,
                        Footballer = footballer
                    };

                    footballers.Add(teamFootballer);

                }

                team.TeamsFootballers = footballers;
                teams.Add(team);

                sb.AppendLine(String.Format(SuccessfullyImportedTeam, team.Name,team.TeamsFootballers.Count));
            }
            
            context.Teams.AddRange(teams);
            context.SaveChanges();

            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
