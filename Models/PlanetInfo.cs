using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSystem_GRP5.Models
{
    public class PlanetInfo
    {
        string name;
        float diameter;
        int moons;
        float temperature;
        string materials;
        string atmosphere;
        string distance_from_sun;
        float orbit_speed;
        float laterial_rotation_time;
        string description;
        public string Name { get => name; set => name = value; }
        public float Diameter { get => diameter; set => diameter = value; }
        public int Moons { get => moons; set => moons = value; }
        public float Temperature { get => temperature; set => temperature = value; }
        public string Materials { get => materials; set => materials = value; }
        public string Atmosphere { get => atmosphere; set => atmosphere = value; }
        public string Distance_from_sun { get => distance_from_sun; set => distance_from_sun = value; }
        public float Orbit_speed { get => orbit_speed; set => orbit_speed = value; }
        public float Laterial_rotation_time { get => laterial_rotation_time; set => laterial_rotation_time = value; }
        public string Description { get => description; set => description = value; }

        public PlanetInfo()
        {
            
        }
    }
}
