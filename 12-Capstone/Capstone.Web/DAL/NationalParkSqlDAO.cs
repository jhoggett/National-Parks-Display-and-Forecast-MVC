using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{

    public class NationalParkSqlDAO : INationalParkDAO
    {

        private string connectionString;

        public NationalParkSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Park> GetAllParks()
        {
            List<Park> parks = new List<Park>();
           
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    
                    conn.Open();
                    string sql = "Select * from park";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        parks.Add(MapRowToPark(reader));
                    }
                }
            }
            catch (SqlException ex)
            {

                throw;
            }
            return parks;
        }

        public Park GetPark(string parkCode)
        {
            Park park = new Park();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "Select * From park Where parkCode = @parkCode";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if(reader.Read())
                    {
                        park = MapRowToPark(reader);
                    }

                    return park;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        
        private Park MapRowToPark(SqlDataReader reader)
        {
            Park park = new Park();
            park.Name = Convert.ToString(reader["parkName"]);
            park.ParkCode = Convert.ToString(reader["parkCode"]);
            park.State = Convert.ToString(reader["state"]);
            park.Acreage = Convert.ToInt32(reader["acreage"]);
            park.Elevation = Convert.ToInt32(reader["elevationInFeet"]);
            park.TrailMileage = Convert.ToDecimal(reader["milesOfTrail"]);
            park.Campsites = Convert.ToInt32(reader["numberOfCampsites"]);
            park.Climate = Convert.ToString(reader["climate"]);
            park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
            park.Visitors = Convert.ToInt32(reader["annualVisitorCount"]);
            park.Quote = Convert.ToString(reader["inspirationalQuote"]);
            park.QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
            park.Description = Convert.ToString(reader["parkDescription"]);
            park.EntryFee = Convert.ToInt32(reader["entryFee"]);
            park.AnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

            return park;
        }

   
    }
}
