using DocumentFormat.OpenXml.InkML;
using Kalayci.Entities.Concrete;
using Kalayci.Mvc.Areas.Admin.Models.ViewModel.Spool;
using Kalayci.Services.Abstract.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kalayci.Mvc.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class SpoolController : Controller
    {

        private IPersonelService _personelService;
        private IBranchService _branchService;
        private IKalayciUserService _kalayciUserService;
        private IProjectService _projectService;
        private IPersonelProjectService _personelProjectService;
        private IPointService _pointService;
        private ISpoolService _spoolService;


        private IWorkPlaceService _workPlaceService;
        private IWeldingService _weldingService;
        private ICircuitDeliveryService _circuitDeliveryService;
        private ISendingService _sendingService;
        private IShipYardAssemblyService _shipyardAssemblyService;
        public SpoolController(IPersonelService personelService, IBranchService branchService,
            IKalayciUserService kalayciUserService,
            IPersonelProjectService personelProjectService,
            IProjectService projectService,
            IPointService pointService,
            ISpoolService spoolService,
            IWorkPlaceService workPlaceService,
            IWeldingService weldingService,
            ICircuitDeliveryService circuitDeliveryService,
            ISendingService sendingService,
            IShipYardAssemblyService shipyardAssemblyService


            )
        {

            _workPlaceService = workPlaceService;
            _weldingService = weldingService;
            _circuitDeliveryService = circuitDeliveryService;
            _sendingService = sendingService;
            _shipyardAssemblyService = shipyardAssemblyService;
            _spoolService = spoolService;
            _pointService = pointService;
            _personelProjectService=personelProjectService;
            _projectService =projectService;
            _kalayciUserService = kalayciUserService;
            _branchService =branchService;
            _personelService = personelService;
        }


        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> ProjectSpoolList(int ProjectId)
        {


            //9 saniye sürüyor.
            //ICollection<Kalayci.Entities.Concrete.PersonelProject> PersonelProjects = await _spoolService.GetProjectAllPersonelAndAllSpoolsAsync(ProjectId);
            //persone , project,    Pojeden shipyard,
            //projeden user projeden spoollist
            //IEnumerable<Kalayci.Entities.Concrete.Spool> PersonelProjects = await _spoolService.GetAllAsyncAmount(1, 100, x => x.Project.Id==6&&x.Block=="101");
            // projeye Personel Atanmadıysa hata alıyor.
            //if (PersonelProjects.Count()==0)
            //{
            //    TempData["Message"]="Proje Ait Personel Girilmediği için Bağlantı Hatası Oluştu. Lütfen Bilgi işleme Başvurunuz.";
            //    TempData["MessageColor"]="alert-danger";
            //    return View();
            //}

            Project project = await _projectService.GetAsync(x => x.Id==ProjectId, s => s.shipYard, s => s.spoolLists);

            ProjectSpoolListViewModel model = new ProjectSpoolListViewModel()
            {
                ProjectId = ProjectId,
                ProjectName =  project.ProjectName,
                shipYardName = project.shipYard.ShipYardName ?? "Tersane Adı Bulunamadı",
                ProjectStartTime = project.ProjectStartTime,
                ProjectFinishTime =project.ProjectFinishTime,
                UserId = project.UserId,
                User =await _kalayciUserService.GetAsync(x => x.Id ==project.UserId, x => x.personel),
                //WorkPersonelCount=PersonelProjects.Where(x=>x.IsActiveWork==true).Count(),
                //PersonelProjects = PersonelProjects,
                Spools=project.spoolLists,
                projectPercentageCalculate = await _spoolService.ProjectPercentageCalculate(ProjectId)
                //WorkPlaceCount= 
            };
            model.User.personel= await _personelService.GetAsync(x => x.Id==model.User.personel.Id, s => s.branch);
            //model.Spools = await _spoolService.GetAllAsync(x => x.ProjectId == ProjectId);
            //model.Spools = await _spoolService.GetAllAsync(x => x.ProjectId == ProjectId, i => i.WorkPlace, i => i.Welding, i => i.CircuitDelivery, i => i.Sending, i => i.ShipyardAssembly);

            return View(model);
        }






    }




}
