using Kalayci.Data.Abstract;
using Kalayci.Entities.Concrete;
using Kalayci.Entities.Dto;
using Kalayci.Services.Abstract.Entities;
using Kalayci.Shared.Data.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Services.Concrete.Entities
{
    public class KalayciUserService : GenericService<KalayciUser>, IKalayciUserService
    {
        protected UserManager<KalayciUser> _userManager { get; }
        protected SignInManager<KalayciUser> _signInManager { get; }

        protected RoleManager<KalayciRole>? _roleManager { get; }

        // kullanııcıyı bulma

 
        public KalayciUserService(IEntityRepository<KalayciUser> repository, IUnitOfWork unitOfWork, UserManager<KalayciUser> userManager, SignInManager<KalayciUser> signInManager, RoleManager<KalayciRole> roleManager) : base(unitOfWork, repository)
        {

            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;



        }

        public async Task<IdentityResult> CreateUser(UserSaveDto model)
        {

            KalayciUser user = new KalayciUser()
            {
                UserName = model.UserName,
                Email = model.Email,
            };


            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            return result;
        }

        public async Task<string> Login(LoginDto model)
        {
            KalayciUser user = new();
            if (model.UserName.Contains("@"))
                user = await _userManager.FindByEmailAsync(model.UserName);
            else
                user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                if (await _userManager.IsLockedOutAsync(user)) // true dönerse kitlidir
                {
                    return "Hesabınız Bir Süreliğine kitlenmiştir bir süre sonra tekrar deneyiniz";
                }
                else
                {
                    await _signInManager.SignOutAsync();

                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        await _userManager.ResetAccessFailedCountAsync(user);
                        return "Success";
                    }
                    else
                    {
                        await _userManager.AccessFailedAsync(user);// hhatalı girişi 1 arttır
                        int fail = await _userManager.GetAccessFailedCountAsync(user);// hatalı girişleri getir

                        if (fail == 3)
                        {// 3 başarısız giriş yapmak
                            await _userManager.SetLockoutEndDateAsync(user, new DateTimeOffset(DateTime.Now.AddMinutes(5)));
                            return "Hesabınız 5 dk boyunca kitlendi.";
                        }
                        // hatalı giriş mesajı
                        return $"{fail} Hatalı Giriş Yaptınız";

                    }
                }
            }
            else
            {
                return "Geçersiz kullanıcı adı veya  şifresi";
            }
        }
    }
}
