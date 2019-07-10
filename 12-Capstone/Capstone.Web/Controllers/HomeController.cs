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
        public HomeController(INationalParkDAO nationalParkDAO, IWeatherDAO weatherDAO)
        {
            this.nationalParkDAO = nationalParkDAO;
            this.weatherDAO = weatherDAO; 

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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
