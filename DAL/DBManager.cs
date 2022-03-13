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
            //cmd.Parameters.AddWithValue("@culture", culture);
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
                try
                {
                    planetInfo = new PlanetInfo()
                    {
                        Name = (string)reader["planet_name"],
                        Diameter = (double)reader["diameter"],
                        Moons = (int)reader["moons"],
                        Materials = (string)reader["materials"],
                        Atmosphere = (string)reader["atmosphere"],
                        Distance_from_sun = (double)reader["distance_from_sun"],
                        Orbit_speed = (double)reader["orbit_speed"],
                        Laterial_rotation_time = (double)reader["lateral_rotation_time"],
                        Description = (string)reader["planet_description"]
                    };

                   
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine(e);
                    throw;
                }
               

            }

            return planetInfo;
        }

        //get list of languages
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
                Language language = new Language
                {
                    ID = (int)reader["language_id"],
                    Name = (string)reader["language_name"],
                    Culture = (string)reader["language_culture"]
                };
                languages.Add(language);
            }
            con.Close();
            cmd.Parameters.Clear();

            return languages;
        }

        internal StringResource GetStringValue(string cultureName, string stringName)
        {
            StringResource resource = new StringResource();

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("GetStringData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@culture", cultureName);
            cmd.Parameters.AddWithValue("@name", stringName);


            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                StringResource res = new StringResource
                {
                    Name = (string)reader["name"],
                    Value =(string)reader["value"],
                    ID = (int)reader["label_id"]
                };

                resource = res;
            }

            return resource;
        }

        internal List<StringResource> GetPageStringValues(string cultureName, string pageName)
        {
                List<StringResource> resources = new List<StringResource>();
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("GetPageStringData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@culture", cultureName);
                cmd.Parameters.AddWithValue("@name", pageName);


                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StringResource res = new StringResource
                    {
                        Name = (string)reader["name"],
                        Value = (string)reader["value"],
                        ID = (int)reader["label_id"]
                    };

                    resources.Add(res);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
           

            return resources;
        }
    }
}
