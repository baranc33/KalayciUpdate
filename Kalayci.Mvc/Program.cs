using Kalayci.Data.Concrete.EntityFrameWork.Context;
using Kalayci.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();




var config = builder.Configuration;
var connetionstring = config.GetConnectionString("mysql");
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
