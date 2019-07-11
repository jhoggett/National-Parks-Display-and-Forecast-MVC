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
        public IActionResult Survey()
        {
            SurveyVM vm = new SurveyVM();
            vm.Parks = nationalParkDAO.GetAllParks();
            vm.Survey = surveyDAO.GetSurvey();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Survey(SurveyVM completedSurvey)
        {
            surveyDAO.SaveSurvey(completedSurvey);
            return RedirectToAction("FavoriteParks");
        }

        public IActionResult FavoriteParks()
        {
            //List<Park> parks = parks.G
            //Dictionary<ParkModel, int> parksWithSurveys = new Dictionary<ParkModel, int>();

            //foreach (Park p in parks)
            //{
            //    int count = surveyDal.SurveyCount(p.ParkCode);
            //    if (count > 0)
            //    {
            //        parksWithSurveys[p] = count;
            //    }
            //}
            return View(/*"FavoriteParks", parksWithSurveys*/);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
