﻿using Microsoft.Extensions.Configuration;
using SolarSystem_GRP5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SolarSystem_GRP5.DAL
{
    public class Logic
    {
        private readonly IConfiguration configuration;


        public Logic(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public List<Planet> GetPlanets()
        {
            DBManager dbContext = new DBManager(configuration);
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            List<Planet> planets = dbContext.GetPlanets();
           // List<Planet> planets = new List<Planet>();
            return planets;
        }

        public PlanetInfo GetPlanetInfo(string planetName)
        {

            DBManager dbContext = new DBManager(configuration);
            PlanetInfo planetInfo = dbContext.GetInfo(planetName);
          //// PlanetInfo planetInfo = new PlanetInfo();
            return planetInfo;
        }
        public string GetResource(string labelName)
        {
            DBManager dbContext = new DBManager(configuration);
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;

            StringResource resource = dbContext.GetStringValue(currentCulture, labelName);
           // StringResource resource = new StringResource();
            return resource.Value;
        }

        public PageResources GetPageResources(string pageLabels)
        {
            PageResources resources = new PageResources();

            DBManager dbContext = new DBManager(configuration);
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;

            List<StringResource> resourceList = dbContext.GetPageStringValues(currentCulture, pageLabels);
            foreach (var stringVal in resourceList)
            {
                resources.StringValues.Add(stringVal.Name, stringVal.Value);
            }
            return resources;
        }
    }
}
