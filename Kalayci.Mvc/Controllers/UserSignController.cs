using Kalayci.Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Kalayci.Mvc.Controllers
{
    public class UserSignController : Controller
    {



        [HttpGet]
        public IActionResult SaveUser()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SaveUser(UserSaveDto model )
        {
            if (model.SignInPassword!="l@G:YsrjT062-7U-"  )
            {
                TempData["ErrorMessage"] = "Kayıt şifresi yanlış Bilgi işleme başvurunuz.";
                return View();
            }
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Lütfen formu eksiksiz doldurunuz.";
                return View(model);
            }


            return View();
        }


    }
}
