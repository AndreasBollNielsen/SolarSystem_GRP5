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
           // ViewData["title"] = logic.GetResource("lang.cake");

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
                viewmodel.Planets = logic.GetPlanets();
                viewmodel.Resources = logic.GetPageResources("lang.solar");

                

                return View("SolarSystem", viewmodel);
            }
            else
            {
                PlanetInfoView viewmodel = new PlanetInfoView();
                viewmodel.PlanetInfo = logic.GetPlanetInfo("neptune");
                viewmodel.Resources = logic.GetPageResources("lang.planet");
                viewmodel.PlanetInfo.Atmosphere = viewmodel.Resources.StringValues[$"lang.planet.{viewmodel.PlanetInfo.Name}.atmosphere"];
                viewmodel.PlanetInfo.Description = viewmodel.Resources.StringValues[$"lang.planet.{viewmodel.PlanetInfo.Name}.description"];
                viewmodel.PlanetInfo.Materials = viewmodel.Resources.StringValues[$"lang.planet.{viewmodel.PlanetInfo.Name}.materials"];

                viewmodel.Planet = new Planet { Name = viewmodel.PlanetInfo.Name, ImagePath = $"/Graphics/{viewmodel.PlanetInfo.Name}.png" };
               


                return View("PlanetInfo",viewmodel);
            }

           
        }

        public IActionResult Quiz()
        {
            Logic logic = new Logic(configuration);
            QuizView viewModel = new QuizView();

            viewModel.Quiz_list = logic.GetQuiz();
            viewModel.Resources = logic.GetPageResources("lang.quiz");

            return View(viewModel);
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

            return RedirectToAction("SelectPage","Home", "Controller");
        }
    }
}
