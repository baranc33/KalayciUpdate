using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kalayci.Mvc.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class CircuitListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
