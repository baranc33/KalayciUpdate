using DocumentFormat.OpenXml.Office2016.Excel;
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
        private IProjectService _projectService;
        private IPersonelProjectService _personelProjectService;
        public PersonelController(IPersonelService personelService, IBranchService branchService,
            IKalayciUserService kalayciUserService,
            IPersonelProjectService personelProjectService,
            IProjectService projectService)
        {
            _personelProjectService=personelProjectService;
            _projectService =projectService;
            _kalayciUserService = kalayciUserService;
            _branchService =branchService;
            _personelService = personelService;
        }




        [HttpGet]
        public async Task<IActionResult> PersonelUpdate(int PersonelId)
        {
            Personel personel = await _personelService.GetAsync(x => x.Id==PersonelId, m => m.ManagerUser, b => b.branch, p => p.points, e => e.employeeExits, pr => pr.PersonelProjects);
            PersonelProject personelProject = await _personelProjectService.ActivePersonelProjectInculude(PersonelId);

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
            if (personelProject != null)
            {
                model.ProjectId = personelProject.ProjectId;
                model.Projects=await _projectService.GetAllAsync(x => x.IsDeleted==false, s => s.shipYard);
            }


            return View(model);
        }




        [HttpPost]
        public async Task<IActionResult> PersonelUpdate(PersonelUpdateViewModel request)
        {
            if (!ModelState.IsValid)
            {
                string Message = "";

                if (request.ProjectId==0) Message+="Çalıştığı Projeyi Giriniz.    ";

                if (request.ManagerId==null) Message+="Personel Şefini Giriniz.   ";

                TempData["Message"]=Message;

                return RedirectToAction("PersonelUpdate", new { PersonelId = request.PersonelId });
            }

            Personel RequestPersonel = await _personelService.GetAsync(x => x.Id==request.PersonelId);

            bool checkChangeManagerUserId = false;
            if (RequestPersonel.ManagerUserId!=request.ManagerId)
            {
                checkChangeManagerUserId=true;
            }


            RequestPersonel.BirthDay = request.BirthDay;
            RequestPersonel.WorkStartDate = request.WorkStartDate;
            RequestPersonel.Name = request.Name.ToUpper().Trim();
            RequestPersonel.LastName = request.LastName.ToUpper().Trim();
            RequestPersonel.SgkRegistrationNumber = request.SgkRegistrationNumber;
            RequestPersonel.TcNumber = request.TcNumber;
            RequestPersonel.branchId = request.branchId;
            RequestPersonel.Gender = request.Gender;
            RequestPersonel.IsDeleted = false;
            RequestPersonel.Phone = request.Phone;
            RequestPersonel.ManagerUserId = request.ManagerId;
            RequestPersonel.ModifiedByName = User.Identity.Name;
            RequestPersonel.ModifiedDate = DateTime.Now;
            RequestPersonel.WorkStartDate = request.WorkStartDate;
            RequestPersonel.Picture = request.Picture;


            (Personel, bool, string) UpdateModel = await _personelService.UpdatePersonelWithProjectsAsync(RequestPersonel, request.ProjectId, checkChangeManagerUserId);


            if (UpdateModel.Item2==true)
            {
                TempData["Message"] = $"{RequestPersonel.Name} {RequestPersonel.LastName} Adlı kişinin Bilgileri Güncellendi";
                TempData["MessageColor"] = "alert-success";
            }
            else
            {
                TempData["Message"] = UpdateModel.Item3;
                TempData["MessageColor"] = "alert-danger";
            }



            return RedirectToAction("PersonelUpdate", new { PersonelId = request.PersonelId });
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
                branches= await GetBranchList(),
                Manager= await _kalayciUserService.GetAllIncludePersonelThenIncludeBranch(),
                Projects= await _projectService.GetAllAsync(x=>x.IsDeleted==false,s=>s.shipYard)
                
            };


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonel(PersonelAddViewModels request)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"]="Gerekli Alanları Doldurunuz Hatalı Giriş Yapıyorsunuz";
                TempData["MessageColor"] = "alert-danger";
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
                Picture = request.Picture,
                ManagerUserId = request.ManagerId,
                
            };

            await _personelService.AddAsync(personel);
            // personeli ekledikten hemen sonra personelProject tablosunuda oluşturalım
            KalayciUser user = await _kalayciUserService.GetAsync(x => x.Id==request.ManagerId,p=>p.personel);
            PersonelProject personelProject = new PersonelProject
            {
                PersonelId = personel.Id,
                ProjectId = request.ProjectId,
                IsActiveWork = true,
                CreatedByName = User.Identity.Name,
                CreatedDate = DateTime.Now,
                ModifiedByName = User.Identity.Name,
                ModifiedDate = DateTime.Now,
                BranchId=request.branchId,
                StartDate=DateTime.Now,
                ManagerName=user.personel.Name+" "+user.personel.LastName,
                IsDeleted=false

            };
                await _personelProjectService.AddAsync(personelProject);

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
