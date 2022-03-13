using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SolarSystem_GRP5.DAL;
using SolarSystem_GRP5.Models;
using SolarSystem_GRP5.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSystem_GRP5.Controllers
{
    public class HomeController : BaseController
    {
       
        private readonly IConfiguration configuration;
        public HomeController(IConfiguration config)
        {
            this.configuration = config;
        }

        public IActionResult Index()
        {
            SetCulture();
            Logic logic = new Logic(configuration);
            ViewData["title"] = logic.GetResource("lang.cake");

            return View();
        }

        public IActionResult SelectPage(string submit)
        {
            if(submit == null)
            {
                if(HttpContext.Session.GetString("userType") != null)
                {
                    submit = HttpContext.Session.GetString("userType");
                }
                
            }
            else
            {
                HttpContext.Session.SetString("userType", submit);
            }

            SetCulture();
            Logic logic = new Logic(configuration);


            if (submit == "Controller")
            {
                SolarSystemView viewmodel = new SolarSystemView();
                // viewmodel.Planets = logic.GetPlanets();
                //   viewmodel.Resources = logic.GetPageResources("lang.planet");

                viewmodel.Planets = new List<Planet>() { new Planet { Name = "Mars", ImagePath = "/Graphics/mars.png" } };
                viewmodel.Resources = new PageResources
                {
                    StringValues = new Dictionary<string, string>() { { "lang.planet.mars", "Mars" },
                    { "lang.planet.earth", "Jorden" },
                { "lang.planet.venus", "Venus" },
                { "lang.planet.jupiter", "Jupiter" },
                { "lang.planet.neptune", "Neptun" },
                { "lang.planet.uranus", "Uranus" },
                { "lang.planet.sun", "Sol" },
                { "lang.planet.pluto", "Pluto" },
                { "lang.planet.mercury", "Merkur" },
                { "lang.planet.saturn", "Saturn" },
                { "lang.planet.title", "Solsystemet" },}
                };

                return View("SolarSystem", viewmodel);
            }
            else
            {
                PlanetInfoView viewmodel = new PlanetInfoView();
                //viewmodel.PlanetInfo1 = logic.GetPlanetInfo("Mars");
                //viewmodel.Resources = logic.GetPageResources("lang.planet");
                #region MyRegion
                viewmodel.PlanetInfo = new PlanetInfo
                {
                    Atmosphere = "cheese",
                    Description = "this is a planet",
                    Distance_from_sun = 1.0000f,
                    Diameter = 35.000,
                    Laterial_rotation_time = 15.5,
                    Materials = "cake",
                    Moons = 5,
                    Name = "mars",
                    Orbit_speed = 100.5,
                    Temperature = 9999.9
                };

                viewmodel.Resources = new PageResources { StringValues = new Dictionary<string, string>() { { "lang.planet.atmosphere", "atmosfære" }, 
                    { "lang.planet.description", "beskrivelse" },
                { "lang.planet.dist", "afstand fra solen" },
                { "lang.planet.diameter", "diameter" },
                { "lang.planet.lat", "lateral rotationshastighed" },
                { "lang.planet.materials", "materialer" },
                { "lang.planet.moons", "måner" },
                { "lang.planet.name", "navn" },
                { "lang.planet.orbit", "kredsløb" },
                { "lang.planet.temperature", "temperatur" },
                { "lang.planet.title", "information" },} };

                viewmodel.Planet = new Planet { Name = "Mars", ImagePath = "/Graphics/mars.png" };
                #endregion


                return View("PlanetInfo",viewmodel);
            }

           
        }

        [HttpPost]
        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                }
            );
            HttpContext.Session.SetString("language",culture);
            ViewData["lang.nav.title"] = "en test";
            return LocalRedirect(returnUrl);
        }

        [HttpPost]
        public IActionResult test(string id)
        {
            Console.WriteLine(id);

            //send a broadcast via websocket to server with name of planet

            return View();
        }
    }
}
