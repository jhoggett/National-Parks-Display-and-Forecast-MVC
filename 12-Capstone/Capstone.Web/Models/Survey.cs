using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Survey
    {
        public int SurveyId { get; set; }

        public string ParkCode { get; set; }

        public string EmailAddress { get; set; }

        public string State { get; set; }

        public string Activity { get; set; }

    }
}

