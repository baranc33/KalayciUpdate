using Kalayci.Entities.Concrete;
using Kalayci.Entities.Dto;
using Kalayci.Mvc.Areas.Admin.Models.ViewModel;
using Kalayci.Mvc.Extentions.Identity;
using Kalayci.Mvc.Models.ViewModel;
using Kalayci.Services.Abstract.Entities;
using Kalayci.Services.Concrete.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Kalayci.Mvc.Controllers
{
    public class UserSignController : Controller
    {

        private IPersonelService _personelService;
        protected UserManager<KalayciUser> _userManager;
        private IKalayciUserService _kalayciUserService;

        public UserSignController(IPersonelService personelService, IKalayciUserService kalayciUserService, UserManager<KalayciUser> userManager)
        {
            _userManager=userManager;
            _kalayciUserService =kalayciUserService;
            _personelService = personelService;
        }
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddUser()
        {

            AddUserForAdminViewModel modelView = await GetPersonelList();

            return View(modelView);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserForAdminViewModel model)
        {
            if (!ModelState.IsValid)
            {
                AddUserForAdminViewModel modelView = await GetPersonelList();
                return View(modelView);

            }
            if (model.UserSaveDto.SignInPassword!="l@G:YsrjT062-7U-")
            {
                AddUserForAdminViewModel modelView = await GetPersonelList();
                TempData["ErrorMessage"] = "Kaydetme Şifresi Yanlış. Bilgi işlemden Alınız.";
                return View(modelView);
            }

            int personelD = Convert.ToInt32(model.PersonelD);
            IdentityResult result = await _kalayciUserService.CreateUser(
                new UserSaveDto
                {
                    UserName = model.UserSaveDto.UserName,
                    Password = model.UserSaveDto.Password,
                    PasswordConfirm=model.UserSaveDto.PasswordConfirm,
                    PersonelId = personelD,
                    Email=model.UserSaveDto.Email,
                    Phone=model.UserSaveDto.Phone,
                    UserNameLastName=model.UserSaveDto.UserNameLastName
                });

            if (result.Succeeded)
            {
                TempData["SuccessMessage"]="üyelik başarılı";
                return View("Index");

            }

            ModelState.AddModelErrorList
                (result.Errors.Select(x => x.Description).ToList());

            return View();
        }

        public async Task<AddUserForAdminViewModel> GetPersonelList()
        {
            ICollection<Personel> personels = await _personelService.GetAllAsync();
            AddUserForAdminViewModel modelView = new AddUserForAdminViewModel
            {
                personels = personels.OrderBy(p => p.Name).ToList()
            };
            return modelView;
        }


    }
}
