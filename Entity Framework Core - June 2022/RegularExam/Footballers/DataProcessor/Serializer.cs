﻿using System.Globalization;
using System.Linq;
using Footballers.DataProcessor.ExportDto;
using Newtonsoft.Json;

namespace Footballers.DataProcessor
{
    using System;

    using Data;

    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var coaches = context.Coaches
                .ToList()
                .Where(c => c.Footballers.Any())
                .Select(c => new ExportCoachDto()
                {
                    FootballersCount = c.Footballers.Count(),
                    CoachName = c.Name,
                    Footballers = c.Footballers
                        .Select(f => new ExportCoachFootballersDto()
                        {
                            Name = f.Name,
                            Position = f.PositionType.ToString()
                        })
                        .OrderBy(f => f.Name)
                        .ToArray()
                })
                .OrderByDescending(c => c.FootballersCount)
                .ThenBy(c => c.CoachName)
                .ToArray();

            var result = XmlConverter.Serialize(coaches, "Coaches");

            return result;
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                .ToList()
                .Where(t => t.TeamsFootballers.Any()
                            && t.TeamsFootballers.Any(tf => tf.Footballer.ContractStartDate >= date))
                .Select(t => new
                {
                    Name = t.Name,
                    Footballers = t.TeamsFootballers
                        .Where(tf => tf.Footballer.ContractStartDate >= date)
                        .OrderByDescending(tf => tf.Footballer.ContractEndDate)
                        .ThenBy(tf => tf.Footballer.Name)
                        .Select(tf => new
                        {
                            FootballerName = tf.Footballer.Name,
                            ContractStartDate = tf.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                            ContractEndDate = tf.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                            BestSkillType = tf.Footballer.BestSkillType.ToString(),
                            PositionType = tf.Footballer.PositionType.ToString()
                        })
                        .ToList()
                })
                .OrderByDescending(t => t.Footballers.Count())
                .ThenBy(t => t.Name)
                .Take(5)
                .ToList();

            string result = JsonConvert.SerializeObject(teams, Formatting.Indented);

            return result;
        }
    }
}
