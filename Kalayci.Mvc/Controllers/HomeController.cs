using System.Diagnostics;
using Kalayci.Entities.Dto;
using Kalayci.Mvc.Models;
using Kalayci.Mvc.Models.ViewModel;
using Kalayci.Services.Abstract.Entities;
using Kalayci.Services.Concrete.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Kalayci.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IKalayciUserService _kalayciUserService;
        public HomeController(ILogger<HomeController> logger, IKalayciUserService kalayciUserService)
        {
            _kalayciUserService =kalayciUserService;
            _logger = logger;
        }



        public IActionResult SpoolList()
        {
            return View();
        }
        public IActionResult Referance()
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








        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {

            if (ModelState.IsValid)
            {
                string result = await _kalayciUserService.Login(model);
                if (result!="Success")
                    ModelState.AddModelError("", result);
                else
                {
                    if (TempData["ReturnUrl"] != null)
                        return Redirect(TempData["ReturnUrl"].ToString());

                    return RedirectToAction("AdminIndex", "Home",new {area ="Admin"});
                }
            }
            else
                ModelState.AddModelError("", "Geçersiz kullanýcý adý veya  þifresi");

            return View(model);
        }


    }
}
