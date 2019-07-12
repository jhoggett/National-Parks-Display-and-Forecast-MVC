using System;
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
        private IWeatherDAO weatherDAO;
        private ISurveyDAO surveyDAO;
        public HomeController(INationalParkDAO nationalParkDAO, IWeatherDAO weatherDAO, ISurveyDAO surveyDAO)
        {
            this.nationalParkDAO = nationalParkDAO;
            this.weatherDAO = weatherDAO;
            this.surveyDAO = surveyDAO;
        }

        // Home Page
        public IActionResult Index()
        {
            IList<Park> parks = nationalParkDAO.GetAllParks();
            return View(parks);
        }

        // Detail Page for selected park 
        public IActionResult Detail(string parkCode)
        {
            WeatherVM vm = new WeatherVM();
            vm.Park = nationalParkDAO.GetPark(parkCode);
            vm.Weathers = weatherDAO.GetWeather(parkCode);
            return View(vm);
        }

        // return the view for creating a survey with a vm passed in populated with parks 
        [HttpGet]
        public IActionResult Survey()
        {
            SurveyVM vm = new SurveyVM();
            vm.Parks = nationalParkDAO.GetAllParks();
            return View(vm);
        }

        // Save the created survey and take us to the favorite parks page 
        [HttpPost]
        public IActionResult Survey(SurveyVM completedSurvey)
        {
            surveyDAO.SaveSurvey(completedSurvey.Survey);
            return RedirectToAction("FavoriteParks");
        }
  
        public IActionResult FavoriteParks()
        {
            IList<SurveyVM> surveys = surveyDAO.GetAllSurveys();
            return View(surveys);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
