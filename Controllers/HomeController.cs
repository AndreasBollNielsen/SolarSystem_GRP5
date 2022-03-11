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
                viewmodel.Planets = logic.GetPlanets();
                viewmodel.Resources = logic.GetPageResources("lang.planet");
              
                //ViewData["lang.solar.title"] = logic.GetResource("lang.cake");
                return View("SolarSystem", viewmodel);
            }
            else
            {
                PlanetInfoView viewmodel = new PlanetInfoView();
                viewmodel.PlanetInfo1 = logic.GetPlanetInfo("Mars");
                viewmodel.Resources = logic.GetPageResources("lang.planet");
               
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
    }
}
