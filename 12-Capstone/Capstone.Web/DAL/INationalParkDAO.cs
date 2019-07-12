﻿using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
     public interface INationalParkDAO
    {
        IList<Park> GetAllParks();
        Park GetPark(string code);      
    }
}
