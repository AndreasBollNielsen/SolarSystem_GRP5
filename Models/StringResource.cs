using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSystem_GRP5.Models
{
    public class StringResource
    {
        private int id;
        private int languageID;
        private string name;
        private string _value;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public int LanguageID
        {
            get { return languageID; }
            set { languageID = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

    }
}
