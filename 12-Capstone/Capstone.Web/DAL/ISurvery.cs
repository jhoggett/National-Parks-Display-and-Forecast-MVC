﻿using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    interface ISurvery
    {
        void SaveSurvey(SurveyVM survey);

        int SurveyCount(string parkCode);

    }
}
