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

        private const string sqlSaveSurvey = "INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) " +
            "VALUES (@parkCode, @emailAddress, @state, @activity)";
        private const string sqlGetCount = "SELECT COUNT(*) FROM survey_result WHERE parkCode = @parkCode";

        public void SaveSurvey(SurveyVM survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();


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

        public Survey GetSurvey()
        {
            throw new NotImplementedException();
        }
    }
}
