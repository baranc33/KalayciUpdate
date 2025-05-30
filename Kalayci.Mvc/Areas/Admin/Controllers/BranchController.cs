using Kalayci.Entities.Concrete;
using Kalayci.Mvc.Areas.Admin.Models.ViewModel;
using Kalayci.Services.Abstract.Entities;
using Kalayci.Services.Concrete.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kalayci.Mvc.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class BranchController : Controller
    {
        private IBranchService _branchService;
        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ICollection<Branch> branches=  await GetBranchesAsync();

            BranchViewModel model = new BranchViewModel
            {
                Branches = branches
            };


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddBranch(BranchViewModel model)
        {
            ICollection<Branch> branches= await GetBranchesAsync();
            if (!ModelState.IsValid)
            {
                TempData["Message"]="Gerekli Alanları Doldurunuz";
                return View("Index", new BranchViewModel { Branches = branches });
            }


            foreach (var item in branches)
            {
                if (item.BranchName.ToUpper() == model.BranchName.ToUpper())
                {
                    TempData["Message"]="Bu Branş zaten kayıtlı";
                    return View("Index", new BranchViewModel { Branches = branches });
                }
            }


            Branch branch = new Branch
            {
                BranchName = model.BranchName,
                BranchDetay = model.BranchDetay,
                CreatedDate = DateTime.Now,
                ModifiedByName = User!.Identity!.Name!,
                ModifiedDate = DateTime.Now,
                CreatedByName = User.Identity.Name!,
                IsDeleted = false
            };
            await _branchService.AddAsync(branch);



            return RedirectToAction("Index");
        }






        private async Task<ICollection<Branch>> GetBranchesAsync()
        {
            return await _branchService.GetAllAsync(x => x.IsDeleted == false);

        }
}
}
