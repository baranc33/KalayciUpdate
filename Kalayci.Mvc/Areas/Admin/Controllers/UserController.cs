using Kalayci.Entities.Concrete;
using Kalayci.Entities.Dto;
using Kalayci.Mvc.Areas.Admin.Models.ViewModel;
using Kalayci.Mvc.Extentions.Identity;
using Kalayci.Services.Abstract.Entities;
using Kalayci.Shared.Utilitis.Result.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Kalayci.Mvc.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class UserController : Controller
    {

        private IKalayciUserService _kalayciUserService;
        private IPersonelService _personelService;
        private IKalayciRoleService _kalayciRoleService;
        protected UserManager<KalayciUser> _userManager;
        protected SignInManager<KalayciUser> _signInManager;

        private RoleManager<KalayciRole> _roleManager;
        public UserController(IKalayciUserService kalayciUserService, IPersonelService personelService, IKalayciRoleService kalayciRoleService,
            RoleManager<KalayciRole> roleManager, UserManager<KalayciUser> userManager, SignInManager<KalayciUser> signInManager
            )
        {

            _personelService= personelService;
            _kalayciUserService= kalayciUserService;
            _personelService=personelService;
            _kalayciRoleService=kalayciRoleService;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(string UserId)
        {

            KalayciUser user = await _kalayciUserService.GettAllIncludePersonelThenIncludeBranch(UserId);
            UpdateUserViewModel model = new UpdateUserViewModel
            {
                Kalayci = user,

                Personels= await _personelService.GettAllIncludeBranch()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserViewModel model)
        {

            if (ChectEngelishCharacter(model.Kalayci.UserName)|| ChectEngelishCharacter(model.Kalayci.Email))
            {
                TempData["ErrorMessage"]="Türkçe Karakter Kullanmayınız. Örnek: i,ğ,ü,ş,ç,ö";
                return RedirectToAction("UpdateUser", new { UserId = model.Kalayci.Id.ToString() });
            }
            if (!ModelState.IsValid)
            {
                return View(model.Kalayci.Id.ToString());
            }
            var LoginUser = await _userManager.FindByNameAsync(User.Identity!.Name!);

            string PersonelIdString = "";
            for (int i = 0; i < model.PersonelId.Length; i++)
            {
                if (model.PersonelId[i]=='-')
                {
                    break;
                }
                PersonelIdString+=model.PersonelId[i];
            }




            KalayciUser user = await _kalayciUserService.GetAsync(x => x.Id== model.Kalayci.Id);

            user.UserName = model.Kalayci.UserName;
            user.Linkedin= model.Kalayci.Linkedin;
            user.personelId= Convert.ToInt32(PersonelIdString);
            user.Email=model.Kalayci.Email;
            user.ModifiedByName= LoginUser.UserName;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {

                // ModelState.AddModelErrorList
                //(result.Errors.Select(x => x.Description).ToList());
                return View(model.Kalayci.Id);
            }
            var currentUser = await _userManager.FindByNameAsync(model.Kalayci.UserName);
            await _userManager.UpdateSecurityStampAsync(currentUser);


            TempData["SuccessMessage"] = $"{model.Kalayci.UserName} Kullanıcının Üye bilgileri başarıyla değiştirilmiştir";


            return RedirectToAction("Index");

        }




        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var curUser = await _userManager.GetUserAsync(HttpContext.User);


            ICollection<KalayciUser> users = await _kalayciUserService.GetAllUser();
            return View(users);
        }


        [HttpGet]
        public async Task<IActionResult> AddUser()
        {
            AddUserAdminViewModel modelView = await GetPersonelList();

            return View(modelView);
        }


        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserAdminViewModel model)
        {
            AddUserAdminViewModel modelView = await GetPersonelList();
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Gerekli Alanları Doldurunuz";
                return View(modelView);

            }


            string PersonelIdString = "";
            for (int i = 0; i < model.PersonelD.Length; i++)
            {


                if (model.PersonelD[i]=='-')
                {
                    break;
                }
                PersonelIdString+=model.PersonelD[i];
            }


            int personelD = Convert.ToInt32(PersonelIdString);
            var PersonelNew = await _personelService.GetAsync(x => x.Id==personelD);
            IdentityResult result = await _kalayciUserService.CreateUser(
                new UserSaveDto
                {
                    UserName = model.UserSaveDto.UserName,
                    Password = model.UserSaveDto.Password,
                    PasswordConfirm=model.UserSaveDto.PasswordConfirm,
                    PersonelId = personelD,
                    Email=model.UserSaveDto.Email,
                    Phone=PersonelNew.Phone,

                });

            if (result.Succeeded)
            {
                TempData["SuccessMessage"]="üyelik başarılı";
                return RedirectToAction("Index");

            }

            ModelState.AddModelErrorList
                (result.Errors.Select(x => x.Description).ToList());
            return View(modelView);
        }








        [HttpGet]
        public async Task<IActionResult> AssignRoleToUser(string id)
        {
            var currentUser = await _userManager.FindByIdAsync(id);
            ViewBag.UserID=id;
            var roles = await _kalayciRoleService.GetAllAsync();

            var roleViewModel = new List<AssignRoleToUserViewModel>();

            var userRoles = await _userManager.GetRolesAsync(currentUser);
            foreach (var role in roles)
            {
                var assignRoleToUserViewModel = new AssignRoleToUserViewModel
                {
                    Id = role.Id,
                    Name = role.Name,
                };
                if (userRoles.Contains(role.Name))
                {
                    assignRoleToUserViewModel.Exist = true;
                }

                roleViewModel.Add(assignRoleToUserViewModel);
            }

            return View(roleViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRoleToUser(List<AssignRoleToUserViewModel> requestList, string Id)
        {

            var User = await _userManager.FindByIdAsync(Id);

            foreach (var item in requestList)
            {
                if (item.Exist)
                {
                    await _userManager.AddToRoleAsync(User, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(User, item.Name);
                }
            }

            return RedirectToAction("Index");
        }






        public async Task<IActionResult> RemoveUser(string UserId)
        {
            var user = await _userManager.FindByIdAsync(UserId);

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Kullanıcı başarıyla silindi.";
            }
            else
            {
                TempData["ErrorMessage"] = "Kullanıcı silinirken bir hata oluştu.";
            }
            return RedirectToAction("Index");
        }



        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }



        public IActionResult PasswordChange()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswordChange(PasswordChangeViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var currentUser = (await _userManager.FindByNameAsync(User.Identity!.Name!))!;

            var checkOldPassword = await _userManager.CheckPasswordAsync(currentUser, request.PasswordOld);

            if (!checkOldPassword)
            {
                ModelState.AddModelError(string.Empty, "Eski şifreniz yanlış");
                return View();
            }

            var resultChangePassword = await _userManager.ChangePasswordAsync(currentUser, request.PasswordOld, request.PasswordNew);

            //if (!resultChangePassword.Succeeded)
            //{
            //    ModelState.AddModelErrorList(resultChangePassword.Errors);
            //    return View();
            //}

            await _userManager.UpdateSecurityStampAsync(currentUser);
            await _signInManager.SignOutAsync();
            await _signInManager.PasswordSignInAsync(currentUser, request.PasswordNew, true, false);

            TempData["SuccessMessage"] = "Şifreniz başarıyla değiştirilmiştir";

            return View();
        }

        public bool ChectEngelishCharacter(string keyword)
        {
            if (
                keyword.Contains("ı")|| keyword.Contains("ö")||keyword.Contains("ğ")||
                keyword.Contains("ü")|| keyword.Contains("ş")||keyword.Contains("ç")||
                keyword.Contains("Ü")|| keyword.Contains("Ş")||keyword.Contains("Ç")||
                keyword.Contains("Ğ")|| keyword.Contains("Ö")||keyword.Contains("İ")
                )
                return true;
            else
                return false;

        }

        public async Task<AddUserAdminViewModel> GetPersonelList()
        {
            ICollection<Personel> personels = await _personelService.GettAllIncludeBranch();
            AddUserAdminViewModel modelView = new AddUserAdminViewModel
            {
                personels = personels.OrderBy(p => p.Name).ToList()
            };
            return modelView;
        }
    }
}
