using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSystem_GRP5.Models
{
    public class PageResources
    {
        private Dictionary<string, string> stringValues;

        public Dictionary<string, string> StringValues { get => stringValues; set => stringValues = value; }

        public PageResources()
        {
            StringValues = new Dictionary<string, string>();
        }
    }
}
