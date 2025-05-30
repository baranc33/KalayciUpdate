using Kalayci.Entities.Concrete;
using Kalayci.Entities.Dto;
using Kalayci.Mvc.Areas.Admin.Models.ViewModel;
using Kalayci.Services.Abstract.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kalayci.Mvc.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ShipYardController : Controller
    {
        private IShipYardService _shipYardService;
        private IProjectService _projectService;
        public ShipYardController(IShipYardService shipYardService, IProjectService projectService)
        {
            _projectService=projectService;
            _shipYardService=shipYardService;

        }




        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ICollection<ShipYard> shipYards = await _shipYardService.GetAllAsync(x => x.IsDeleted==false);
            ShipYardViewModel shipYardDto = new ShipYardViewModel
            {
                ShipYards = shipYards,

            };

            return View(shipYardDto);
        }



        [HttpPost]
        public async Task<IActionResult> AddShipYard(ShipYardViewModel model)
        {
            ICollection<ShipYard> shipYardss = await _shipYardService.GetAllAsync(x => x.IsDeleted == false);
            if (!ModelState.IsValid)
            {
                TempData["Message"]="Tersane Adı en az 10 karakterli olmalıdır.";
                return View("Index", new ShipYardViewModel { ShipYards = shipYardss });
            }


            foreach (var item in shipYardss)
            {
                if (item.ShipYardName.ToUpper() == model.ShipYardName.ToUpper())
                {
                    TempData["Message"]="Bu tersane zaten kayıtlı";
                    return View("Index", new ShipYardViewModel { ShipYards = shipYardss });
                }
            }

            ShipYard shipYard = new ShipYard
            {
                ShipYardName = model.ShipYardName,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                CreatedByName = User.Identity.Name,
                ModifiedByName = User.Identity.Name,

            };
            await _shipYardService.AddAsync(shipYard);



            return RedirectToAction("Index");
        }

        public async Task<IActionResult> HardRemoveShipYard(string id)
        {
            var project = await _projectService.GetAllAsync(x => x.shipYard.Id== Convert.ToInt32(id));

            if (project.Count>0)
            {
                TempData["Message"] = "Tersaneye Bağlı Projeler Bulunmaktadır.";
                return RedirectToAction("Index");
            }


            ShipYard shipYard = await _shipYardService.GetAsync(x => x.Id==Convert.ToInt32(id));

            if (shipYard == null)
            {
                TempData["Message"] = "Tersane bulunamadı.";
                return RedirectToAction("Index");
            }

            TempData["Message"] = $"{shipYard.ShipYardName} Silinmiştir.";
            await _shipYardService.DeleteAsync(shipYard);


            return RedirectToAction("Index");
        }


    }
}
