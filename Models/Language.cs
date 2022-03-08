using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSystem_GRP5.Models
{
    public class Language
    {
        private int id;
        private string culture;
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public string Culture
        {
            get { return culture; }
            set { culture = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

    }
}
