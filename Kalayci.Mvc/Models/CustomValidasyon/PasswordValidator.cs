using Kalayci.Entities.Concrete;
using Microsoft.AspNetCore.Identity;

namespace Kalayci.Mvc.Models.CustomValidasyon
{
    public class PasswordValidator : IPasswordValidator<KalayciUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<KalayciUser> manager, KalayciUser user, string password)
        {


            var errors = new List<IdentityError>();
            if (password!.ToLower().Contains(user.UserName!.ToLower()))
            {
                errors.Add(new() { Code = "PasswordContainUserName", Description = "Şifre alanı kullanıcı adı içeremez" });
            }

            if (password!.ToLower().StartsWith("1234"))
            {
                errors.Add(new() { Code = "PasswordContain1234", Description = "Şifre alanı ardışık sayı içeremez" });
            }

            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

            return Task.FromResult(IdentityResult.Success);


        }
    }
}