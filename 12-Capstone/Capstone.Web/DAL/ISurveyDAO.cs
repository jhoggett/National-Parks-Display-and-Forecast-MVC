using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface ISurveyDAO
    {
        void SaveSurvey(Survey survey);

        string SurveyCount(string pakrCode);

        IList<SurveyVM> GetAllSurveys();

    }
}
