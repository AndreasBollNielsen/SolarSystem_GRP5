using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSystem_GRP5.Models
{
    public class PlanetInfo
    {
        string name;
        double diameter;
        int moons;
        double temperature;
        string materials;
        string atmosphere;
        double distance_from_sun;
        double orbit_speed;
        double laterial_rotation_time;
        string description;
        public string Name { get => name; set => name = value; }
        public double Diameter { get => diameter; set => diameter = value; }
        public int Moons { get => moons; set => moons = value; }
        public double Temperature { get => temperature; set => temperature = value; }
        public string Materials { get => materials; set => materials = value; }
        public string Atmosphere { get => atmosphere; set => atmosphere = value; }
        public double Distance_from_sun { get => distance_from_sun; set => distance_from_sun = value; }
        public double Orbit_speed { get => orbit_speed; set => orbit_speed = value; }
        public double Laterial_rotation_time { get => laterial_rotation_time; set => laterial_rotation_time = value; }
        public string Description { get => description; set => description = value; }

        public PlanetInfo()
        {
            
        }
    }
}
