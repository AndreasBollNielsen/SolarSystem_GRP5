using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SolarSystem_GRP5.DAL;
using SolarSystem_GRP5.Models;
using SolarSystem_GRP5.Models.ViewModels;
using SolarSystem_GRP5.Websocket;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SolarSystem_GRP5.Controllers
{
    public class HomeController : BaseController
    {

        private readonly IConfiguration configuration;
        public IwebsocketHandler WebsocketHandler { get; }
        public HomeController(IConfiguration config, IwebsocketHandler websockethandler)
        {
            this.configuration = config;
            WebsocketHandler = websockethandler;
        }

        public IActionResult Index()
        {
            SetCulture();
            Logic logic = new Logic(configuration);
            // ViewData["title"] = logic.GetResource("lang.cake");

            return View();
        }


        public IActionResult PlanetInfo(string id)
        {
            string[] data = id.Split('/');
            id = data[1];
            var culture = new CultureInfo(data[0]);
            Thread.CurrentThread.CurrentUICulture = culture;

            SetCulture();
            Logic logic = new Logic(configuration);

            PlanetInfoView viewmodel = new PlanetInfoView();
            if (id == null)
            {
                id = "mars";

            }
            ModelState.Clear();
            viewmodel.PlanetInfo = logic.GetPlanetInfo(id);
            viewmodel.Resources = logic.GetPageResources("lang.planet");
            var temp = logic.GetPageResources("lang.solar");
            viewmodel.PlanetInfo.Atmosphere = viewmodel.Resources.StringValues[$"lang.planet.{viewmodel.PlanetInfo.Name}.atmosphere"];
            viewmodel.PlanetInfo.Description = viewmodel.Resources.StringValues[$"lang.planet.{viewmodel.PlanetInfo.Name}.description"];
            viewmodel.PlanetInfo.Materials = viewmodel.Resources.StringValues[$"lang.planet.{viewmodel.PlanetInfo.Name}.materials"];
            viewmodel.PlanetInfo.Name = temp.StringValues[$"lang.solar.{id}"];

            viewmodel.Planet = new Planet { Name = viewmodel.PlanetInfo.Name, ImagePath = $"/Graphics/{id}.png" };

            return View(viewmodel);
            //  return View(viewmodel);
        }

        public IActionResult SelectPage(string submit)
        {
            if (submit == null)
            {
                if (HttpContext.Session.GetString("userType") != null)
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
                viewmodel.PlanetInfo = logic.GetPlanetInfo("earth");
                viewmodel.Resources = logic.GetPageResources("lang.planet");
                viewmodel.PlanetInfo.Atmosphere = viewmodel.Resources.StringValues[$"lang.planet.{viewmodel.PlanetInfo.Name}.atmosphere"];
                viewmodel.PlanetInfo.Description = viewmodel.Resources.StringValues[$"lang.planet.{viewmodel.PlanetInfo.Name}.description"];
                viewmodel.PlanetInfo.Materials = viewmodel.Resources.StringValues[$"lang.planet.{viewmodel.PlanetInfo.Name}.materials"];
                viewmodel.PlanetInfo.Name = "Jorden";
                viewmodel.Planet = new Planet { Name = viewmodel.PlanetInfo.Name, ImagePath = $"/Graphics/earth.png" };



                return View("PlanetInfo", viewmodel);
            }


        }

        public IActionResult Quiz()
        {
            SetCulture();
            Logic logic = new Logic(configuration);
            QuizView viewModel = new QuizView();

            viewModel.Quiz_list = logic.GetQuiz();
            viewModel.Resources = logic.GetPageResources("lang.quiz");

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                }
            );
            HttpContext.Session.SetString("language", culture);
            ViewData["lang.nav.title"] = "en test";
            return LocalRedirect(returnUrl);
        }

        [HttpPost]
        public IActionResult test(string id)
        {


            //send a broadcast via websocket to server with name of planet
            return RedirectToPage("test");
            //return RedirectToAction("PlanetInfo", new { id = id });
        }

        //websocket
        [HttpGet("/ws")]
        public async Task Get()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();

                // _logger.Log(LogLevel.Information, "WebSocket connection established");
                //  await Echo(webSocket);
                string culture = "";
                if (HttpContext.Session.GetString("Language") != null)
                {
                    culture = HttpContext.Session.GetString("Language");

                }
                else
                {
                    culture = Thread.CurrentThread.CurrentCulture.Name;
                }
                await WebsocketHandler.Handle(culture, webSocket);

            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        private async Task Echo(WebSocket webSocket)
        {
            var buffer = new byte[20];
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            //  _logger.Log(LogLevel.Information, "Message received from Client");
            Debug.WriteLine("echo!");
            while (!result.CloseStatus.HasValue)
            {
                //  var serverMsg = Encoding.UTF8.GetBytes($"Server: Hello. You said: {Encoding.UTF8.GetString(buffer)}");
                var serverMsg = Encoding.UTF8.GetBytes($"{Encoding.UTF8.GetString(buffer)}");
                await webSocket.SendAsync(new ArraySegment<byte>(serverMsg, 0, serverMsg.Length), result.MessageType, result.EndOfMessage, CancellationToken.None);
                //   _logger.Log(LogLevel.Information, "Message sent to Client");

                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                //  _logger.Log(LogLevel.Information, "Message received from Client");

            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
            //_logger.Log(LogLevel.Information, "WebSocket connection closed");
        }
    }
}
