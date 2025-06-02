using Kalayci.Entities.Concrete;
using Kalayci.Mvc.Areas.Admin.Models.ViewModel.Personel;
using Kalayci.Mvc.Extentions.Identity;
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
        private IKalayciUserService _kalayciUserService;
        public PersonelController(IPersonelService personelService, IBranchService branchService, IKalayciUserService kalayciUserService)
        {
            _kalayciUserService = kalayciUserService;
            _branchService =branchService;
            _personelService = personelService;
        }




        [HttpGet]
        public async Task<IActionResult> PersonelUpdate(int PersonelId)
        {
            Personel personel = await _personelService.GetAsync(x => x.Id==PersonelId, m => m.ManagerUser, b => b.branch, p => p.points, e => e.employeeExits, pr => pr.PersonelProjects);


            PersonelUpdateViewModel model = new PersonelUpdateViewModel()
            {
                PersonelId=personel.Id,
                Name = personel.Name,
                LastName = personel.LastName,
                SgkRegistrationNumber = personel.SgkRegistrationNumber,
                TcNumber = personel.TcNumber,
                BirthDay = personel.BirthDay,
                Gender = personel.Gender,
                Phone = personel.Phone,
                WorkStartDate = personel.WorkStartDate,
                Picture = personel.Picture,
                branchId = personel.branchId,
                branches =await _branchService.GetAllAsync(),
                ManagerId=personel.ManagerUserId,
                Manager=await _kalayciUserService.GetAllIncludePersonelThenIncludeBranch(),

                // personelin aktif olduğu projeyi getir

                // personele yönetici Ata
            };

            return View(model);
        }






        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ICollection<Personel> personels = await GetPersonelList();

            return View(personels);
        }

        [HttpGet]
        public async Task<IActionResult> AddPersonel()
        {
            PersonelAddViewModels model = new PersonelAddViewModels()
            {
                branches= await GetBranchList()
            };


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonel(PersonelAddViewModels request)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"]="Gerekli Alanları Doldurunuz Hatalı Giriş Yapıyorsunuz";
                return RedirectToAction("Index", new PersonelAddViewModels { branches = await GetBranchList() });
            }
            ICollection<Personel> personels = await GetPersonelList();

            // tc numarasını dönelim check etmek için
            foreach (var item in personels)
            {
                if (item.TcNumber ==request.TcNumber)
                {
                    TempData["Message"] = "Bu TC Numarası zaten kayıtlı Pasif Personel Listesine Göz Atınız.";
                    TempData["MessageColor"]="alert-danger";
                    return RedirectToAction("Index");
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
                Name = request.Name.ToUpper().Trim(),
                LastName = request.LastName.ToUpper().Trim(),
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

            TempData["Message"] = $"{personel.Name} {personel.LastName} Personel Listesine Eklenmiştir.";
            TempData["MessageColor"]="alert-success";
            return RedirectToAction("Index");
        }




        [HttpGet]
        public async Task<IActionResult> AdminPersonelList()
        {
            ICollection<Personel> personels = await _personelService.GettAllIncludeBranch();
            return View(personels);
        }

        public async Task<IActionResult> AdminPersonelDelete(int PersonelId)
        {
            var personelUser = await _kalayciUserService.GetAsync(x => x.personelId==PersonelId);
            if (personelUser !=null)
            {
                TempData["Message"]= "Bu personelin Kullanıcısı mevcut Önce Kullanıcıyı Siliniz";
                TempData["MessageColor"]="alert-danger";
                return RedirectToAction("AdminPersonelList");
            }
            Personel personel = await _personelService.GetAsync(x => x.Id == PersonelId);
            await _personelService.DeleteAsync(personel);


            TempData["Message"]= $"{personel.Name} {personel.LastName} Adlı Personel Başarıyla Silinmiştir.";
            TempData["MessageColor"]="alert-success";
            return RedirectToAction("AdminPersonelList");
        }













        private async Task<ICollection<Branch>> GetBranchList()
        {
            return await _branchService.GetBranchesAsyncOrderByName();
        }
        private async Task<ICollection<Personel>> GetPersonelList()
        {
            return await _personelService.GettAllIncludeBranch();
        }





    }
}
