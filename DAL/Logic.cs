using Microsoft.Extensions.Configuration;
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

        //get list of planets
        public List<Planet> GetPlanets()
        {
            DBManager dbContext = new DBManager(configuration);
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            List<Planet> planets = dbContext.GetPlanets();
          
            return planets;
        }

        //get planet data
        public PlanetInfo GetPlanetInfo(string planetName)
        {

            DBManager dbContext = new DBManager(configuration);
            PlanetInfo planetInfo = dbContext.GetInfo(planetName);
         
            return planetInfo;
        }

        public List<Quiz> GetQuiz()
        {
            DBManager dbContext = new DBManager(configuration);
            List<Quiz> quiz_list = dbContext.GetQuiz();
            return quiz_list;
        }

        //get single string resource
        public string GetResource(string labelName)
        {
            DBManager dbContext = new DBManager(configuration);
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;

            StringResource resource = dbContext.GetStringValue(currentCulture, labelName);
          
            return resource.Value;
        }
      
        //get page resources
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
