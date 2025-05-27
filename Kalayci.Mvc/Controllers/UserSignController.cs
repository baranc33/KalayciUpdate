using Kalayci.Entities.Dto;
using Kalayci.Mvc.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Kalayci.Mvc.Controllers
{
    public class UserSignController : Controller
    {



        [HttpPost]
        public IActionResult SignInUser(LoginDto model)
        {

            if (!ModelState.IsValid) return View();





            return View();
        }




    }
}
