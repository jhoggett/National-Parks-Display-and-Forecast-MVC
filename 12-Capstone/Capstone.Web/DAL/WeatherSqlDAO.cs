using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAO : IWeatherDAO
    {

        private string connectionString;

        public WeatherSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IList<Weather> GetWeather(string parkCode)
        {
            List<Weather> forecast = new List<Weather>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();
                    string sql = "Select * from weather where fiveDayForecastValue between 1 and 5 and parkCode = @parkCode";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                       forecast.Add(MapRowToWeather(reader));
                    }
                }
            }
            catch (SqlException ex)
            {

                throw;
            }
            return forecast;
        }
        private Weather MapRowToWeather(SqlDataReader reader)
        {
            Weather weather = new Weather();
            weather.ParkCode = Convert.ToString(reader["parkCode"]);
            weather.Forecast = Convert.ToString(reader["forecast"]);
            weather.ForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
            weather.Low = Convert.ToInt32(reader["low"]);
            weather.High = Convert.ToInt32(reader["high"]);
            return weather; 
        }
    }
}
