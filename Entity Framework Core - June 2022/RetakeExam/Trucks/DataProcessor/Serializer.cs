using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Trucks.DataProcessor.ExportDto;

namespace Trucks.DataProcessor
{
    using System;

    using Data;

    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            var despatchers = context.Despatchers
                .ToList()
                .Where(d => d.Trucks.Any())
                .Select(d => new ExportDespatcherDto()
                {
                    TrucksCount= d.Trucks.Count(),
                    DespatcherName = d.Name,
                    Trucks = d.Trucks
                        .Select(t => new ExportDespatcherTruckDto()
                        {
                            RegistrationNumber = t.RegistrationNumber.ToString(),
                            Make = t.MakeType.ToString()
                        })
                        .OrderBy(t => t.RegistrationNumber)
                        .ToArray()
                })
                .OrderByDescending(d => d.TrucksCount)
                .ThenBy(d => d.DespatcherName)
                .ToArray();

            var result = XmlConverter.Serialize(despatchers, "Despatchers");

            return result;
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var teams = context.Clients
                .ToList()
                .Where(c => c.ClientsTrucks.Any()
                            && c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
                .Select(c => new
                {
                    Name = c.Name,
                    Trucks = c.ClientsTrucks
                        .Where(ct => ct.Truck.TankCapacity >= capacity)
                        .OrderBy(ct => ct.Truck.MakeType)
                        .ThenByDescending(ct => ct.Truck.CargoCapacity)
                        .Select(ct => new
                        {
                            TruckRegistrationNumber = ct.Truck.RegistrationNumber,
                            VinNumber = ct.Truck.VinNumber.ToString(),
                            TankCapacity = (int)ct.Truck.TankCapacity,
                            CargoCapacity = (int)ct.Truck.CargoCapacity,
                            CategoryType = ct.Truck.CategoryType.ToString(),
                            MakeType=ct.Truck.MakeType.ToString(),
                        })
                        .ToList()
                })
                .OrderByDescending(c => c.Trucks.Count())
                .ThenBy(c => c.Name)
                .Take(10)
                .ToList();

            string result = JsonConvert.SerializeObject(teams, Formatting.Indented);

            return result;
        }
    }
}
