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

        public IActionResult Index()
        {
            IList<Park> parks = nationalParkDAO.GetAllParks();
            return View(parks);
        }

        public IActionResult Detail(string parkCode)
        {
            WeatherVM vm = new WeatherVM();
            vm.Park = nationalParkDAO.GetPark(parkCode);
            vm.Weathers = weatherDAO.GetWeather(parkCode);


            return View(vm);
        }



        [HttpGet]
        public IActionResult Survey()
        {
            SurveyVM vm = new SurveyVM();
            vm.Parks = nationalParkDAO.GetAllParks();


            return View(vm);
        }


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
