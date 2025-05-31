using Kalayci.Data.Abstract;
using Kalayci.Data.Abstract.Entities;
using Kalayci.Entities.Concrete;
using Kalayci.Entities.Dto;
using Kalayci.Services.Abstract.Entities;
using Kalayci.Shared.Data.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        protected IKalayciUserRepository _kalayciUserRepository;

        // kullanııcıyı bulma


        public KalayciUserService(IEntityRepository<KalayciUser> repository, IUnitOfWork unitOfWork, UserManager<KalayciUser> userManager, SignInManager<KalayciUser> signInManager, RoleManager<KalayciRole> roleManager, IKalayciUserRepository kalayciUserRepository) : base(unitOfWork, repository)
        {
            this._kalayciUserRepository= kalayciUserRepository;
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
                PasswordBackUp=model.Password,
                PhoneNumber = model.Phone,
                personelId = model.PersonelId,

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

        public async Task<ICollection<KalayciUser>> GetAllUser()
        {
            return await _userManager.Users.Include(p => p.personel).ThenInclude(b => b.branch)
                .ToListAsync();
        }

   
        public async Task<ICollection<KalayciUser>> GetEngineerList()
        {
            ICollection<KalayciUser> users = await _kalayciUserRepository.GetAllIncludePersonelThenIncludeBranch();
            ICollection<KalayciUser> engiierlist = new List<KalayciUser>();

            foreach (var user in users)
            {
                if (user.personel.branchId==2)
                {
                    engiierlist.Add(user);
                }
            }

            return engiierlist;
        }

        public async Task<KalayciUser> IncludePersonelThenIncludeBranch(string UserID)
        {
            return await _kalayciUserRepository.IncludePersonelThenIncludeBranch(UserID);

        }

        public async Task<ICollection<KalayciUser>> GetAllIncludePersonelThenIncludeBranch()
        {
            return await _kalayciUserRepository.GetAllIncludePersonelThenIncludeBranch();

        }
    }
}
