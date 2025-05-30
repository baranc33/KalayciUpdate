using Kalayci.Entities.Concrete;
using Kalayci.Mvc.Areas.Admin.Models.ViewModel;
using Kalayci.Services.Abstract.Entities;
using Kalayci.Services.Concrete.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kalayci.Mvc.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class PersonelController : Controller
    {
        private IPersonelService _personelService;
        private IBranchService _branchService;
        public PersonelController(IPersonelService personelService, IBranchService branchService)
        {
            _branchService =branchService;
            _personelService = personelService;
        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ICollection<Personel> personels = await GetĞersonelList();

            return View(personels);
        }

        [HttpGet]
        public async Task<IActionResult> AddPersonel()
        {
            PersonelAddViewModel model = new PersonelAddViewModel()
            {
                branches= await GetBranchList()
            };


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonel(PersonelAddViewModel request)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"]="Gerekli Alanları Doldurunuz";
                return View("Index", new PersonelAddViewModel { branches = await GetBranchList() });
            }
            ICollection<Personel> personels = await GetĞersonelList();

            // tc numarasını dönelim check etmek için
            foreach (var item in personels)
            {
                if(item.TcNumber ==request.TcNumber)
                {
                    TempData["Message"] = "Bu TC Numarası zaten kayıtlı";
                    return View("Index", new PersonelAddViewModel { branches = await GetBranchList() });
                }
            }

            //kayıt ilemi için model
            Personel personel = new Personel
            {
                CreatedDate = System.DateTime.Now,
                ModifiedDate = System.DateTime.Now,
                IsDeleted = false,
                CreatedByName=User.Identity.Name,
                ModifiedByName = User.Identity.Name,
                Name = request.Name,
                LastName = request.LastName,
                SgkRegistrationNumber = request.SgkRegistrationNumber,
                TcNumber = request.TcNumber,
                BirthDay = request.BirthDay,
                Gender = request.Gender,
                OverallScore=0,
                TechnicalPoint = 0,
                Phone = request.Phone,
                WorkStartDate = request.WorkStartDate,
                branchId = request.branchId,
            };

            await _personelService.AddAsync(personel);



            return RedirectToAction("Index");
        }



        private async Task<ICollection<Branch>> GetBranchList()
        {
            return await _branchService.GetBranchesAsyncOrderByName();
        }
        private async Task<ICollection<Personel>> GetĞersonelList()
        {
            return await _personelService.GettAllIncludeBranch();
        }
    }
}
