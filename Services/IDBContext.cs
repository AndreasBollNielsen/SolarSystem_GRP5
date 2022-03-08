using SolarSystem_GRP5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSystem_GRP5.Services
{
    interface IDBContext
    {
        List<Language> Languages();
    }
}
