using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSystem_GRP5.Models.ViewModels
{
    public class PlanetInfoView
    {
        private PlanetInfo planetInfo;
        private PageResources resources;
        private Planet planet;

        public PlanetInfo PlanetInfo { get => planetInfo; set => planetInfo = value; }
        public PageResources Resources { get => resources; set => resources = value; }
        public Planet Planet { get => planet; set => planet = value; }
    }
}
