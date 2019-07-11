using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyVM
    {
        public Survey Survey { get; set; }
        public IList<Park> Parks { get; set; }
        public Park Park { get; set; }
        public int NumberOfSurveys { get; set; }
    }
}
