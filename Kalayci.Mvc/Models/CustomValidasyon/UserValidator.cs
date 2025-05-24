using Kalayci.Entities.Concrete;
using Microsoft.AspNetCore.Identity;

namespace Kalayci.Mvc.Models.CustomValidasyon
{
    public class UserValidator : IUserValidator<KalayciUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<KalayciUser> manager, KalayciUser user)
        {
            var errors = new List<IdentityError>();
            var isDigit = int.TryParse(user.UserName![0].ToString(), out _);
            // ilk değer numerikmi diye kontrol ediyoruz , ikinci parametre değeri dönüyor fakat biz kullanmıyoruz

            if (isDigit)
            {
                errors.Add(new() { Code = "UserNameContainFirstLetterDigit", Description = "Kullanıcı adının ilk karekteri sayısal bir karakter içeremez" });
            }

            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}