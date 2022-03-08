using SolarSystem_GRP5.DAL;
using SolarSystem_GRP5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSystem_GRP5.Services
{
    public class LanguageService: ILanguageService
    {
        private readonly DBManager _context;
        

        public LanguageService(DBManager context)
        {
            _context = context;
        }

        public IEnumerable<Language> GetLanguages()
        {
            return _context.GetLanguages().ToList();
        }

        public Language GetLanguageByCulture(string culture)
        {
            return _context.GetLanguages().FirstOrDefault(x =>
                x.Culture.Trim().ToLower() == culture.Trim().ToLower());
        }
    }
}
