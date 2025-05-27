using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kalayci.Mvc.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
