using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    
    public class NationalParkSqlDAO : INationParkDAO
    {
        private string connectionString; 

        public NationalParkSqlDAO(string connectionString)
        {
            this.connectionString = connectionString; 
        }

        public NationalParks GetByPark()
        {
            throw new NotImplementedException();
        }

        public IList<NationalParks> GetParks()
        {
            List<NationalParks> parks = new List<NationalParks>();
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from park", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        NationalParks park = new NationalParks();
                        park.Name = Convert.ToString(reader["parkName"]);
                        park.State = Convert.ToString(reader["state"]);
                        park.Description = Convert.ToString(reader["parkDescription"]);
                        parks.Add(park); 
                    }
                }

            }
            catch
            {
                throw; 
            }
            return parks; 
        }
    }
}
