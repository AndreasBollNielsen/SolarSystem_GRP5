using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SolarSystem_GRP5.Controllers
{
    public class BaseController : Controller
    {

     
        public  void SetCulture()
        {
            if(HttpContext.Session.GetString("language") != null)
            {
                var currentCulture = new CultureInfo(HttpContext.Session.GetString("language"));
                Thread.CurrentThread.CurrentCulture = currentCulture;
                Thread.CurrentThread.CurrentUICulture = currentCulture;
            }
            else
            {
                var currentculture = Thread.CurrentThread.CurrentUICulture;
                HttpContext.Session.SetString("language", currentculture.Name);
            }
           
          
        }
    }
}
