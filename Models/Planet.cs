using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSystem_GRP5.Models
{
    public class Planet
    {
        private string name;
        private string imagePath;

        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
