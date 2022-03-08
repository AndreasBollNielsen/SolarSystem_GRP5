using SolarSystem_GRP5.DAL;
using SolarSystem_GRP5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSystem_GRP5.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly DBManager _context;

        public LocalizationService(DBManager context)
        {
            _context = context;
        }

        public StringResource GetStringResource(string resourceKey, int languageID)
        {
            return _context.GetStringValue(resourceKey,languageID);
        }
    }
}
