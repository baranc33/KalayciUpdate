using Kalayci.Entities.Concrete;
using Kalayci.Mvc.Areas.Admin.Models.ViewModel;
using Kalayci.Mvc.Models.ViewModel;
using Kalayci.Services.Abstract.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kalayci.Mvc.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IKalayciUserService _kalayciUserService;
        private readonly IShipYardService _shipYardService;

        public ProjectController(IProjectService projectService, IKalayciUserService kalayciUserService, IShipYardService shipYardService)
        {
            _kalayciUserService= kalayciUserService;
            _shipYardService = shipYardService;
            _projectService = projectService;
        }


        public async Task<IActionResult> Index()
        {
            ProjectListViewModel model = new ProjectListViewModel
            {
                Projects =await _projectService.projectsWithUser()

            };
            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> AddProject()
        {
            var enginierList=  await _kalayciUserService.GetEngineerList();
            if (enginierList.Count()==0)
                TempData["Message"]="Eklenecek Mühendis Bulunamadı Lütfen önce Aktif Mühendis Giriniz. ve Kullanıcısını oluşturunuz";
            var shipyardList = await GetAllShipYard();
            if (shipyardList.Count()==0)
                TempData["Message"]="Projeyi eklicek Tersane bulunamadı Lütfen önce Tersane ekleyiniz";



            ProjectAddViewModel model = new ProjectAddViewModel
            {
                Users= enginierList,
                ShipYards= shipyardList
            };

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> AddProject(ProjectAddViewModel model)
        {
            var enginierList = await _kalayciUserService.GetEngineerList();
            if (!ModelState.IsValid || model.UsersId=="0"||model.ShipYardNameDto=="0")
            {
                TempData["Message"]="Gerekli Alanları Doldurunuz";
                return View("AddProject", new ProjectAddViewModel { Users = enginierList, ShipYards=await GetAllShipYard() });
            }

            var projects = await _projectService.GetAllAsync();

            foreach (var item in projects)
            {
                if (item.ProjectName.ToUpper() == model.ProjectNameDto.ToUpper())
                {
                    TempData["Message"]="Bu Proje zaten Adı kayıtlı";
                    return View("AddProject", new ProjectAddViewModel { Users = enginierList, ShipYards = await GetAllShipYard() });
                }
            }


            Project Newproject = new Project()
            {
                CreatedByName = User.Identity.Name,
                CreatedDate = System.DateTime.Now,
                ModifiedByName = User.Identity.Name,
                ModifiedDate = System.DateTime.Now,
                IsDeleted = false,

                shipYardId= Convert.ToInt32(model.ShipYardNameDto),
                ProjectName = model.ProjectNameDto,
                UserId = model.UsersId

            };
            var result = await _projectService.AddAsync(Newproject);

            return RedirectToAction("Index");
        }






        public async Task<IActionResult> RemoveProject(string ProjectId)
        {
            TempData["Message"] = await _projectService.RemoveProject(ProjectId);

          

            return RedirectToAction("Index");
        }





















        /// <summary>
        ///  metotlar
        /// </summary>
        /// <returns></returns>


        private async Task<ICollection<ShipYard>> GetAllShipYard()
        {
            return await _shipYardService.GetAllAsync(x => x.IsDeleted==false);
        }
    }
}
