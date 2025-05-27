using Kalayci.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kalayci.Mvc.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ShipYardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }




        [HttpGet]
        public IActionResult AddShipYard( )
        {
            return View();
        }



        [HttpPost]
        public IActionResult AddShipYard(ShipYard model)
        {
            return View();
        }



    }
}
