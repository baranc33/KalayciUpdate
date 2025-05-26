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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();




var config = builder.Configuration;
var connetionstring = config.GetConnectionString("mysql");
//var version = new MySqlServerVersion(new Version(5, 5, 38));

builder.Services.AddDbContext<KalayciContext>(opt =>
{
    opt.UseMySQL(connetionstring);
    //opt.UseMySql(connetionstring, version);
});



builder.Services.AddIdentity<KalayciUser, KalayciRole>(opt =>
{
    //opt.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<KalayciContext>()// ef hangisini kullanacak belirtiyoruz.
    ;


//builder.Services.AddAutoMapper(typeof(CategoryProfile), typeof(ArticleProfile));
builder.Services.LoadMyServices();


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
