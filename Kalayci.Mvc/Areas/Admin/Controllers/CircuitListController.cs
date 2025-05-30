using Kalayci.Services.Abstract.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kalayci.Mvc.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class CircuitListController : Controller
    {

        private ICircuitListService _circuitListService;
        public CircuitListController(ICircuitListService circuitListService)
        {
            _circuitListService=circuitListService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
