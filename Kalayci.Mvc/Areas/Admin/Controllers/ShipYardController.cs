using Kalayci.Entities.Concrete;
using Kalayci.Entities.Dto;
using Kalayci.Mvc.Areas.Admin.Models.ViewModel;
using Kalayci.Mvc.Areas.Admin.Models.ViewModel.ShipYard;
using Kalayci.Services.Abstract.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace Kalayci.Mvc.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ShipYardController : Controller
    {
        private IShipYardService _shipYardService;
        private IProjectService _projectService;
        private IKalayciUserService _kalayciUserService;
        private IPersonelService _personelService;
        public ShipYardController(IShipYardService shipYardService, IProjectService projectService, IKalayciUserService kalayciUserService, IPersonelService personelService)
        {
            _kalayciUserService=kalayciUserService;
            _projectService=projectService;
            _shipYardService=shipYardService;
            _personelService=personelService;
        }


        //[HttpGet]
        //public async Task<IActionResult> ShipYardProject(int ShipYardID)
        //{

        //    ShipYard shipYardProject = await _shipYardService.GetAllShipYardInculudeProjectsThenInculedeUser(ShipYardID);
 

        //    TempData["ShipYardName"] = shipYardProject.ShipYardName;

        //    return View(shipYardProject);
        //}




        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ICollection<ShipYard> shipYards = await _shipYardService.GetAllAsync(x => x.IsDeleted==false);
            ShipYardViewModel shipYardDto = new ShipYardViewModel
            {
                ShipYards = shipYards,
                Users= await _kalayciUserService.GetAllIncludePersonelThenIncludeBranch(),

            };

            return View(shipYardDto);
        }

        [HttpGet]
        public async Task<IActionResult> ShipYardUpdates(int ShipYardId)
        {
            ShipYard shipYard = await _shipYardService.GetAsync(s => s.Id==ShipYardId);
            ICollection<KalayciUser> users = await _kalayciUserService.GetAllIncludePersonelThenIncludeBranch();
            ShipYardUpdateViewModel model = new ShipYardUpdateViewModel()
            {
                ShipYardID=shipYard.Id,
                ShipYardName=shipYard.ShipYardName,
                ShipYardManagerName=shipYard.ShipYardManagementName,
                PersonelID=shipYard.PersonelID,
                Users=users,
                User=await _personelService.GetAsync(x=>x.Id==shipYard.PersonelID),
            };

            return View(model);
        }





        [HttpPost]
        public async Task<IActionResult> ShipYardUpdates(ShipYardUpdateViewModel shipYard)
        {
           
            
            
            //idyi isme gizlediğim için bu şekilde içerden çıkarıyorum.
            string IdForPersonel = "";
            for (int i = 0; i < shipYard.ShipYardManagerName.Length; i++)
            {
                if (shipYard.ShipYardManagerName[i]=='-')
                {
                    break;
                }
                IdForPersonel+=shipYard.ShipYardManagerName[i];
            }

            Personel personel = await _personelService.GetAsync(x => x.Id==Convert.ToInt32(IdForPersonel ));
            shipYard.PersonelID=personel.Id;
            shipYard.User=personel;
            shipYard.ShipYardManagerName=personel.Name+" "+personel.LastName;

            ShipYard DatashipYard = await _shipYardService.GetAsync(s => s.Id==shipYard.ShipYardID);
            ICollection<ShipYard> shipYards = await _shipYardService.GetAllAsync();


            // ismi değiştirlmişse
            if (DatashipYard.ShipYardName!=shipYard.ShipYardName)
            {
                // aynı isimde başka tersane varmı diye bakıyorum
                foreach (var item in shipYards)
                {
                    if (item.ShipYardName.ToUpper().Trim()==shipYard.ShipYardName.ToUpper().Trim())
                    {
                        TempData["Message"]="Aynı isimde Tersane Kayıtlıdır. Pasif Listesine Bakınız";
                        TempData["MessageColor"] = "alert-danger";
                        return RedirectToAction("Index");
                    }
                }

            }
                      
                


            DatashipYard.ShipYardName = shipYard.ShipYardName;
            DatashipYard.ModifiedByName = User.Identity!.Name!;
            DatashipYard.ModifiedDate = DateTime.Now;
            DatashipYard.PersonelID=shipYard.PersonelID;
            DatashipYard.ShipYardManagementName=shipYard.ShipYardManagerName;

            await _shipYardService.UpdateAsync(DatashipYard);
            TempData["Message"]=$"Tersane Adı {shipYard.ShipYardName} olarak Değiştirilmiştir.";
            TempData["MessageColor"] = "alert-success";
            return RedirectToAction("Index");
        }




        [HttpPost]
        public async Task<IActionResult> AddShipYard(ShipYardViewModel model)
        {
            Personel personel = await _personelService.GetAsync(x => x.Id==Convert.ToInt32(model.ShipYardManagementName));
            model.PersonelID=personel.Id;
            model.Personel=personel;
            model.ShipYardManagementName=personel.Name+" "+personel.LastName;

            ICollection<ShipYard> shipYardss = await _shipYardService.GetAllAsync(x => x.IsDeleted == false);
            if (!ModelState.IsValid)
            {


                ShipYardViewModel shipYardDto = new ShipYardViewModel
                {
                    ShipYards = shipYardss,
                    Users= await _kalayciUserService.GetAllIncludePersonelThenIncludeBranch(),

                };

                TempData["Message"]="Tersane Adı en az 10 karakterli olmalıdır.";
                TempData["MessageColor"] = "alert-danger";
                return View("Index", shipYardDto);
            }


            foreach (var item in shipYardss)
            {
                if (item.ShipYardName.ToUpper() == model.ShipYardName.ToUpper())
                {
                    TempData["Message"]="Bu tersane zaten kayıtlı";
                    TempData["MessageColor"] = "alert-danger";
                    return View("Index", new ShipYardViewModel { ShipYards = shipYardss });
                }
            }

            ShipYard shipYard = new ShipYard
            {
                ShipYardName = model.ShipYardName,
                PersonelID= model.PersonelID,
                ShipYardManagementName = model.ShipYardManagementName,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                CreatedByName = User.Identity.Name,
                ModifiedByName = User.Identity.Name,

            };
            await _shipYardService.AddAsync(shipYard);


            TempData["Message"]=$"{model.ShipYardName} Başarıyla Eklenmiştir.";
            TempData["MessageColor"] = "alert-success";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> HardRemoveShipYard(string id)
        {
            var project = await _projectService.GetAllAsync(x => x.shipYard.Id== Convert.ToInt32(id));

            if (project.Count>0)
            {
                TempData["Message"] = "Tersaneye Bağlı Projeler Bulunmaktadır.";
                TempData["MessageColor"] = "alert-danger";
                return RedirectToAction("Index");
            }


            ShipYard shipYard = await _shipYardService.GetAsync(x => x.Id==Convert.ToInt32(id));

            if (shipYard == null)
            {
                TempData["Message"] = "Tersane bulunamadı.";
                TempData["MessageColor"] = "alert-danger";
                return RedirectToAction("Index");
            }

            TempData["Message"] = $"{shipYard.ShipYardName} Silinmiştir.";
            TempData["MessageColor"] = "alert-danger";
            await _shipYardService.DeleteAsync(shipYard);


            return RedirectToAction("Index");
        }


    }
}
