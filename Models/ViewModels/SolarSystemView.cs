using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSystem_GRP5.Models.ViewModels
{
    public class SolarSystemView
    {
        private List<Planet> planets;
        private PageResources resources;
        public List<Planet> Planets { get => planets; set => planets = value; }
        public PageResources Resources { get => resources; set => resources = value; }

        public SolarSystemView()
        {
            planets = new List<Planet>();
        }
    }
}
