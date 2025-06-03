using Kalayci.Entities.Concrete;
using Kalayci.Mvc.Areas.Admin.Models.ViewModel.PersonelProject;
using Kalayci.Mvc.Areas.Admin.Models.ViewModel.Project;
using Kalayci.Mvc.Models.ViewModel;
using Kalayci.Services.Abstract.Entities;
using Kalayci.Services.Concrete.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using NuGet.Versioning;
using System.Threading.Tasks;
using Project = Kalayci.Entities.Concrete.Project;

namespace Kalayci.Mvc.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IKalayciUserService _kalayciUserService;
        private readonly IShipYardService _shipYardService;
        private readonly IPersonelProjectService _personelProjectService;

        public ProjectController(IProjectService projectService, IKalayciUserService kalayciUserService,
            IShipYardService shipYardService,
            IPersonelProjectService personelProjectService
            )
        {
            _personelProjectService= personelProjectService;
            _kalayciUserService = kalayciUserService;
            _shipYardService = shipYardService;
            _projectService = projectService;
        }









        [HttpGet]
        public async Task<IActionResult> UpdateProject(int projectId)
        {
            Project project = await _projectService.GetAsync(x => x.Id==projectId, u => u.User, s => s.shipYard);
            ProjectUpdateViewModel model = new ProjectUpdateViewModel
            {
                ProjectId = project.Id,
                ProjectName = project.ProjectName,
                shipYardId = project.shipYardId,
                shipYard = project.shipYard,
                UserId = project.UserId,
                User = project.User,
                ProjectStartTime = project.ProjectStartTime,
                Users = await _kalayciUserService.GetEngineerList(),
                shipYards = await GetAllShipYard()
            };


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProject(ProjectUpdateViewModel model)
        {

            
            var shipyard = await _shipYardService.GetAsync(x => x.Id == model.shipYardId, p => p.Projects);
    

            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Gerekli Alanları Doldurunuz";
                return RedirectToAction("Index");
            }

            Project project = await _projectService.GetAsync(x => x.Id==model.ProjectId);

            project.ProjectName = model.ProjectName;
            project.shipYardId=model.shipYardId;
            project.UserId=model.UserId;
            project.ProjectStartTime=model.ProjectStartTime;
            project.ModifiedByName = User.Identity.Name;
            project.ModifiedDate = System.DateTime.Now;

            await _projectService.UpdateAsync(project);

            TempData["Message"] = $"{model.ProjectName} Projesinin Bilgileri Güncellenmiştir.";
            return RedirectToAction("Index");
        }






        [HttpGet]
        public async Task<IActionResult> ProjectPersonelList(int ProjectId)
        {
            ICollection<PersonelProject> model = await _personelProjectService.GetAllAsync(x => x.ProjectId==ProjectId &&x.IsActiveWork==true, p => p.Personel, pr => pr.Project, b => b.Branch);
            var project = await _projectService.GetAsync(x => x.Id == ProjectId,s=>s.shipYard);

            TempData["ProjectName"]=$"{project.shipYard.ShipYardName} / {project.ProjectName} Projesine Ait Personel Listesi";
            return View(model);
        }


        public async Task<IActionResult> Index(int ShipYardID=0)
        {
          

                ProjectListViewModel model = new ProjectListViewModel
                {
                    Projects =await _projectService.projectsWithUser(ShipYardID)

                };
            return View(model);
         


        }



        [HttpGet]
        public async Task<IActionResult> AddProject()
        {
            var enginierList = await _kalayciUserService.GetEngineerList();
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
