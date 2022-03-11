using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSystem_GRP5.Models.ViewModels
{
    public class PlanetInfoView
    {
        private PlanetInfo PlanetInfo;
        private PageResources resources;

        public PlanetInfo PlanetInfo1 { get => PlanetInfo; set => PlanetInfo = value; }
        public PageResources Resources { get => resources; set => resources = value; }
    }
}
