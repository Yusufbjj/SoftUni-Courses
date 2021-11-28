using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private PlanetRepository exploredPlanets;
        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
            this.exploredPlanets = new PlanetRepository();
        }


        public string AddAstronaut(string type, string astronautName)
        {
            if (type != "Biologist" && type != "Geodesist" && type != "Meteorologist")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            IAstronaut astronaut = default;

            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }

            this.astronauts.Add(astronaut);

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (string item in items)
            {
                planet.Items.Add(item);
            }
            this.planets.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = this.astronauts.Models.FirstOrDefault(a => a.Name == astronautName);
            if (astronaut is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }
            else
            {
                this.astronauts.Remove(astronaut);
            }

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);
            ICollection<IAstronaut> astronautsReadyForMission = new List<IAstronaut>();
            foreach (IAstronaut astronautsModel in this.astronauts.Models)
            {
                if (astronautsModel.Oxygen > 60)
                {
                    astronautsReadyForMission.Add((Astronaut)astronautsModel);
                }
            }
            int astrounautsBefore = astronautsReadyForMission.Count;

            if (astronautsReadyForMission.Any())
            {
                exploredPlanets.Add(planet);
                Mission mission = new Mission();
                mission.Explore(planet, astronautsReadyForMission);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            int astrounautsAfter = astronautsReadyForMission.Count;

            return string.Format(OutputMessages.PlanetExplored, planetName, astrounautsBefore - astrounautsAfter);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.exploredPlanets.Models.Count} planets were explored!");
            sb.Append("Astronauts info:" + Environment.NewLine);
            foreach (IAstronaut astronaut in this.astronauts.Models)
            {
                sb.Append($"Name: {astronaut.Name}" + Environment.NewLine);
                sb.Append($"Oxygen: {astronaut.Oxygen}" + Environment.NewLine);
                if (astronaut.Bag.Items.Any())
                {
                    sb.Append($"Bag items: {string.Join(", ", astronaut.Bag.Items)}" + Environment.NewLine);
                }
                else
                {
                    sb.Append("Bag items: none" + Environment.NewLine);
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
