using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAO : ISurveyDAO
    {

        private string connectionString;

        public SurveySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //private const string sqlSaveSurvey = "INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) " +
        //    "VALUES (@parkCode, @emailAddress, @state, @activity)";
        //private const string sqlGetCount = "SELECT COUNT(*) FROM survey_result WHERE parkCode = @parkCode";

        public void SaveSurvey(Survey survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = $"INSERT INTO survey_result VALUES (@parkCode, @emailAddress, @state, @activityLevel)";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.Activity);

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public string SurveyCount(string parkCode)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return parkCode;
        }

        public IList<SurveyVM> GetAllSurveys()
        {
            IList<SurveyVM> output = new List<SurveyVM>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT park.parkName, park.parkCode, COUNT(*) AS surveyCount
                                                    FROM park JOIN survey_result ON park.parkCode = survey_result.parkCode 
                                                    GROUP BY park.parkName, park.parkCode 
                                                    ORDER BY surveyCount DESC, park.parkName", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SurveyVM model = ToPark(reader);
                        output.Add(model);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return output;
        }

        private SurveyVM ToPark(SqlDataReader reader)
        {
            SurveyVM model = new SurveyVM();
            model.Park = new Park();

            model.Park.ParkCode = Convert.ToString(reader["parkCode"]);
            model.Park.Name = Convert.ToString(reader["parkName"]);
            model.NumberOfSurveys = Convert.ToInt32(reader["surveyCount"]);

            return model;
        }
    }
}
