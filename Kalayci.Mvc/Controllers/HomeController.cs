using System.Diagnostics;
using Kalayci.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kalayci.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
     
        public IActionResult Contact()
        {
            return View();
        }


        public IActionResult Team()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult ServiceTrading()
        {
            return View();
        }
        public IActionResult ServiceMilitary()
        {
            return View();
        }
        public IActionResult ServiceYacht()
        {
            return View();
        }


    }
}
