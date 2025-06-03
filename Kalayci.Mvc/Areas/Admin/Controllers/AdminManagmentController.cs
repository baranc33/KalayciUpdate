using Kalayci.Entities.Concrete;
using Kalayci.Services.Abstract.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kalayci.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminManagmentController : Controller
    {

        private IPersonelService _personelService;
        private IBranchService _branchService;
        private IKalayciUserService _kalayciUserService;
        private IProjectService _projectService;
        private IPersonelProjectService _personelProjectService;
        private IPointService _pointService;
        public AdminManagmentController(IPersonelService personelService, IBranchService branchService,
            IKalayciUserService kalayciUserService,
            IPersonelProjectService personelProjectService,
            IProjectService projectService,
            IPointService pointService)
        {
            _pointService = pointService;
            _personelProjectService=personelProjectService;
            _projectService =projectService;
            _kalayciUserService = kalayciUserService;
            _branchService =branchService;
            _personelService = personelService;
        }



        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> EmptyProjectPersonelFill()
        {

            bool result = await _personelProjectService.AutomaticPersonFiilProject();
            TempData["Message"] = "Personel Proje Atama işlemi Başarılı";
            TempData["MessageColor"]="alert-success";
            return RedirectToAction("Index");
        }
    }
}
