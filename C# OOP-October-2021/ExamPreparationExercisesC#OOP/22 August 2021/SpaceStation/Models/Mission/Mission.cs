using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (IAstronaut astronaut in astronauts.ToArray())
            {
                if (astronaut.Oxygen > 0)
                {
                    foreach (var planetItem in planet.Items.ToArray())
                    {
                        astronaut.Breath();
                        astronaut.Bag.Items.Add(planetItem);
                        planet.Items.Remove(planetItem);
                        if (astronaut.Oxygen <= 0)
                        {
                            astronauts.Remove(astronaut);
                            break;
                        }
                    }
                }
            }
        }
    }
}
