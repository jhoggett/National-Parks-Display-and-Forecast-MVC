﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private INationalParkDAO nationalParkDAO;
        public HomeController(INationalParkDAO nationalParkDAO)
        {
            this.nationalParkDAO = nationalParkDAO;

        }

        public IActionResult Index()
        {
            IList<Park> parks = nationalParkDAO.GetAllParks(); 
            return View(parks);
        }

        public IActionResult Detail(string parkCode)
        {
            Park park = nationalParkDAO.GetPark(parkCode);

            return View(park);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
