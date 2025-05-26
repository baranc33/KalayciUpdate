using Kalayci.Data.Concrete.EntityFrameWork.Context;
using Kalayci.Entities.Concrete;
using Kalayci.Mvc.Models.CustomValidasyon;
using Kalayci.Mvc.Models.LanguageSetting;
using Microsoft.AspNetCore.Identity;
using System;

namespace Kalayci.Mvc.Extentions.Programcs
{
    public static class CustomIdentitySettings
    {
        public static void AddIdentityWitjExtentions(this IServiceCollection services)
        {



            services.AddIdentity<KalayciUser, KalayciRole>(opt =>
            { // user ve role için kurallar
                opt.User.RequireUniqueEmail = true; // Id Zorunlu
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";// kullanılabilecek karakterler


                opt.Password.RequiredLength = 6; // Şifre uzunluğu
                opt.Password.RequireDigit = true; // Şifre rakam içermeli
                opt.Password.RequireLowercase = true; // Şifre küçük harf içermeli
                opt.Password.RequireUppercase = true; // Şifre büyük harf içermeli
                opt.Password.RequireNonAlphanumeric = false; // Şifre özel karakter içermelimi
                opt.Password.RequireDigit = false; // Şifre rakam içermelimi
                //opt.SignIn.RequireConfirmedEmail = false; // E-posta onayı zorunlu mu
                opt.SignIn.RequireConfirmedPhoneNumber = false; // Telefon onayı zorunlu mu
                //opt.Lockout.AllowedForNewUsers = false; // Yeni kullanıcılar için kilitleme
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(60); // Kilitleme süresi
                opt.Lockout.MaxFailedAccessAttempts = 5; // Maksimum deneme sayısı



            })
                .AddPasswordValidator<PasswordValidator>()// custom password validasyonumuz
                .AddUserValidator<UserValidator>()
                .AddErrorDescriber<LocalizationIdentityErrorDescriber>() // hata mesajlarını türkçeleştirmek için localization kullanıyoruz
                .AddEntityFrameworkStores<KalayciContext>();// ef hangisini kullanacak belirtiyoruz.

        }
    }
}
