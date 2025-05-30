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
    opt.UseMySql(connetionstring,version);
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



app.MapAreaControllerRoute(name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=AdminIndex}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
