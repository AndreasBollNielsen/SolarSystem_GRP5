using Microsoft.Extensions.Configuration;
using SolarSystem_GRP5.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSystem_GRP5.DAL
{
    public class DBManager
    {
        //private fields containting connectionstrings for databases
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        //constructor setting connectionstrings to databases
        public DBManager(IConfiguration _configuration)
        {
            this.configuration = _configuration;
            connectionString = configuration.GetConnectionString("DBContext");
        }

        //returns a list of planets
        internal List<Planet> GetPlanets()
        {
            List<Planet> planets = new List<Planet>();

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("GetPlanets", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Planet planet = new Planet
                {
                    ImagePath = (string)reader["planet_image"],
                    Name = (string)reader["planet_name"]
                };
                planets.Add(planet);
            }

            return planets;
        }

        //get info from planet
        internal PlanetInfo GetInfo(string planetName)
        {


            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("GetPlanetData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PlanetName", planetName);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();



            PlanetInfo planetInfo = new PlanetInfo();

            while (reader.Read())
            {
                planetInfo = new PlanetInfo()
                {
                    Name = (string)reader["plane_name"],
                    Diameter = (float)reader["diameter"],
                    Moons = (int)reader["moons"],
                    Temperature = (float)reader["temperature"],
                    Materials = (string)reader["materials"],
                    Atmosphere = (string)reader["atmosphere"],
                    Distance_from_sun = (string)reader["distance_from_sun"],
                    Orbit_speed = (int)reader["orbit_speed"],
                    Laterial_rotation_time = (int)reader["lateral_rotation_time"],
                    Description = (string)reader["description"]
                };

            }

            return planetInfo;
        }

        internal List<Language> GetLanguages()
        {
            List<Language> languages = new List<Language>();

            SqlConnection con = new SqlConnection(connectionString);


            SqlCommand cmd = new SqlCommand("GetLanguages", con);
            cmd.CommandType = CommandType.StoredProcedure;


            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //itemLines.Add(
                //    new ItemLineModel(
                //        (int)reader["Quantity"],
                //        new ModelModel(
                //            (string)reader["modelName"],
                //            "N/A - Irrelevant to the context",
                //            new CategoryModel((string)reader["categoryName"])
                //            )
                //        )
                //    );
            }
            con.Close();
            cmd.Parameters.Clear();

            return languages;
        }

        internal StringResource GetStringValue(string resourceKey, int languageID)
        {
            StringResource resource = new StringResource();

            return resource;
        }
    }
}
