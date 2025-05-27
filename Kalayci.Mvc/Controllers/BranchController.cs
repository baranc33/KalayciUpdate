using Kalayci.Entities.Concrete;
using Kalayci.Services.Abstract.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Kalayci.Mvc.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;
        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;

        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            ICollection<Branch> branches = await _branchService.GetAllAsync(x=> x.IsDeleted==false);


            return View(branches);
        }

        [HttpPost]
        public IActionResult List(string filtre)
        {
            return View();
        }


        [HttpGet]
        public IActionResult BranchAdd()
        {
            return View();
        }


    }
}
