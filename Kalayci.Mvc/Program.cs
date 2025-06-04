using Kalayci.Data.Concrete.EntityFrameWork.Context;
using Kalayci.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Kalayci.Services;
using Kalayci.Services.Concrete;
using Kalayci.Services.Extentions;
using System;
using Kalayci.Data.Abstract.Entities;
using Kalayci.Data.Concrete.EntityFrameWork.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Kalayci.Mvc.Extentions.Programcs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();




var config = builder.Configuration;
var connetionstring = config.GetConnectionString("mysql");
var version = new MySqlServerVersion(new Version(10, 6, 18));

builder.Services.AddDbContext<KalayciContext>(opt =>
{
    opt.UseMySql(connetionstring, version);
    //opt.UseMySql(connetionstring, version);
});

CustomIdentitySettings.AddIdentityWitjExtentions(builder.Services);

//builder.Services.AddIdentity<KalayciUser, KalayciRole>(opt =>
//{
//    //opt.User.RequireUniqueEmail = true;
//})
//.AddEntityFrameworkStores<KalayciContext>()// ef hangisini kullanacak belirtiyoruz.
//    ;


//builder.Services.AddAutoMapper(typeof(CategoryProfile), typeof(ArticleProfile));
builder.Services.LoadMyServices();
builder.Services.ConfigureApplicationCookie(opt =>
{
    var cookieBuilder = new CookieBuilder();

    cookieBuilder.Name = "KalayciCoocki";// cookie ismi
    opt.LoginPath = new PathString("/Home/Login");// giriþ yapmadýysa yönlendirilecek sayfa
    opt.LogoutPath = new PathString("/Home/logout");
    opt.AccessDeniedPath = new PathString("/Home/AccessDenied");
    opt.Cookie = cookieBuilder;
    opt.ExpireTimeSpan = TimeSpan.FromDays(30);// cookie süresi
    opt.SlidingExpiration = true;// giriþ yaptýðý sürece time span sýfýrlanýr
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute("AdminManagment", "Hakan-Baran-Cakirin-Admin-Ozel-Sayfasi", new { area = "Admin", controller = "AdminManagment", action = "Index" });

app.MapControllerRoute("AllPersonelList", "Kalayci-Denizcilik-Personellerin-Bilgileri-Sayfasi/MpsGroup/", new { area = "Admin", controller = "Home", action = "AllPersonelList" });
app.MapControllerRoute("AllPersonelList", "Kalayci-Denizcilik-Personellerin-Puan-Detay-Sayfasii/MpsGroup/", new { area = "Admin", controller = "Home", action = "AddPointAdmin" });
app.MapControllerRoute("MemberLogin", "Kalayci-Denizcilik-Yetkili-Personel-sitesi/MpsGroup/", new { area = "Admin", controller = "Home", action = "AdminIndex" });
app.MapControllerRoute("PersonelList", "Kalayci-Denizcilik-Size-Atanmis-Personel-Listesi/MpsGroup/", new { area = "Admin", controller = "Home", action = "MyPersonelList" });
app.MapControllerRoute("PersonelPointDetail", "Kalayci-Denizcilik-Personel-Puan-Detay-Sayfasi/MpsGroup/", new { area = "Admin", controller = "Home", action = "AddPoint"  } );
app.MapControllerRoute("ShipYards", "Kalayci-Denizcilik-Tersaneler/MpsGroup/", new { area = "Admin", controller = "ShipYard", action = "Index" } );
app.MapControllerRoute("ShipYardsUpdate", "Kalayci-Denizcilik-Tersane/MpsGroup/", new { area = "Admin", controller = "ShipYard", action = "ShipYardUpdates" } );
app.MapControllerRoute("CircutList", "Kalayci-Denizcilik-Proje-Devre-Listeleri/MpsGroup/", new { area = "Admin", controller = "CircuitList", action = "Index" } );
app.MapControllerRoute("Branchs", "Kalayci-Denizcilik-Meslekler/MpsGroup/", new { area = "Admin", controller = "Branch", action = "Index" });
app.MapControllerRoute("BranchPersonel", "Kalayci-Denizcilik-Meslekteki-Personeller/MpsGroup/", new { area = "Admin", controller = "Branch", action = "ListBranchPersonel" });
app.MapControllerRoute("BranchUpdate", "Kalayci-Denizcilik-Meslek/MpsGroup/", new { area = "Admin", controller = "Branch", action = "UpdateBranch" });
app.MapControllerRoute("ShipyardProject", "Kalayci-Denizcilik-Tersane-Proje-Listesi/MpsGroup/", new { area = "Admin", controller = "Project", action = "Index" });
app.MapControllerRoute("ProjectList", "Kalayci-Denizcilik-Proje-Personel-Listesi/MpsGroup/", new { area = "Admin", controller = "Project", action = "ProjectPersonelList" });
app.MapControllerRoute("ProjectUpdate", "Kalayci-Denizcilik-Proje/MpsGroup/", new { area = "Admin", controller = "Project", action = "UpdateProject" });
app.MapControllerRoute("Personels", "Kalayci-Denizcilik-Personeller/MpsGroup/", new { area = "Admin", controller = "Personel", action = "Index" });
app.MapControllerRoute("PersonelAdd", "Kalayci-Denizcilik-Personel-Ekleme-Sayfasi/MpsGroup/", new { area = "Admin", controller = "Personel", action = "AddPersonel" });
app.MapControllerRoute("PersonelUpdate", "Kalayci-Denizcilik-Personel-Bilgileri-Sayfasi/MpsGroup/", new { area = "Admin", controller = "Personel", action = "PersonelUpdate" });




app.MapAreaControllerRoute(name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=AdminIndex}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
