using Microsoft.AspNetCore.Identity;

namespace Kalayci.Mvc.Models.LanguageSetting
{
    public class LocalizationIdentityErrorDescriber : IdentityErrorDescriber
    {

        public override IdentityError DuplicateUserName(string userName)
        {

            return new() { Code = "DuplicateUserName", Description = $"{userName} daha önce başka bir kullanıcı tarafından alınmıştır" };

            //return base.DuplicateUserName(userName);
        }


        public override IdentityError DuplicateEmail(string email)
        {

            return new() { Code = "DuplicateEmail", Description = $"{email} daha önce başka bir kullanıcı tarafından alınmıştır" };

        }

        public override IdentityError PasswordTooShort(int length)
        {


            return new() { Code = "PasswordTooShort", Description = $"Şifre en az 6 karakterli olmalıdır" };

        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new() { Code = "PasswordNeedUpperCase", Description = $"Şifre en 1 büyük karakter olmalıdır" };
        }


        public override IdentityError PasswordRequiresLower()
        {
            return new() { Code = "PasswordRequiresLower", Description = $"Şifre en az 1 küçük karakter olmalıdır" };
        }


        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new() { Code = "PasswordRequiresNonAlphanumeric", Description = $"Şifre en az bir tane özel karakter içermelidir" };
        }



    }
}