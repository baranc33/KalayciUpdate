using Kalayci.Entities.Concrete;
using Kalayci.Entities.Dto;
using Kalayci.Mvc.Areas.Admin.Models.ViewModel;
using Kalayci.Mvc.Extentions.Identity;
using Kalayci.Services.Abstract.Entities;
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
        public async Task<IActionResult> Index()
        {
            var curUser = await _userManager.GetUserAsync(HttpContext.User);


            ICollection<KalayciUser> users = await _kalayciUserService.GetAllUser();
            return View(users);
        }


        [HttpGet]
        public async Task<IActionResult> AddUser()
        {
            AddUserViewModel modelView = await GetPersonelList();

            return View(modelView);
        }


        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                AddUserViewModel modelView = await GetPersonelList();
                return View(modelView);

            }
            if (model.UserSaveDto.SignInPassword!="l@G:YsrjT062-7U-")
            {
                AddUserViewModel modelView = await GetPersonelList();
                TempData["ErrorMessage"] = "Kaydetme Şifresi Yanlış. Bilgi işlemden Alınız.";
                return View(modelView);
            }

            IdentityResult result = await _kalayciUserService.CreateUser(
                new UserSaveDto
                {
                    UserName = model.UserSaveDto.UserName,
                    Password = model.UserSaveDto.Password,
                    PasswordConfirm=model.UserSaveDto.PasswordConfirm,
                    PersonelId = model.PersonelD,
                    Email=model.UserSaveDto.Email,
                    Phone=model.UserSaveDto.Phone
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








        [HttpGet]
        public async Task<IActionResult> AssignRoleToUser(string id)
        {
            var currentUser = await _userManager.FindByIdAsync(id);
            ViewBag.UserID=id;
            var roles = await _kalayciRoleService.GetAllAsync();

            var roleViewModel = new List<AssignRoleToUserViewModel>();

            var userRoles =await _userManager.GetRolesAsync(currentUser);
            foreach (var role in roles)
            {
                var assignRoleToUserViewModel= new AssignRoleToUserViewModel
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
        public async Task<IActionResult> AssignRoleToUser(List<AssignRoleToUserViewModel> requestList,string Id)
        {

            var User= await _userManager.FindByIdAsync(Id);

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










        public async Task<AddUserViewModel> GetPersonelList()
        {
            ICollection<Personel> personels = await _personelService.GetAllAsync();
            AddUserViewModel modelView = new AddUserViewModel
            {
                personels = personels.OrderBy(p => p.Name).ToList()
            };
            return modelView;
        }
    }
}
