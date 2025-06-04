using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kalayci.Mvc.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class SpoolController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public IActionResult ProjectSpoolList(int ProjectId)
        {

            return View();
        }






    }




}
