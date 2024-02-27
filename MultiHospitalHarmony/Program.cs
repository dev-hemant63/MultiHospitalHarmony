using Microsoft.AspNetCore.Authentication.Cookies;
using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Infrastructure.Services;
using MultiHospitalHarmony.Static;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
DBConnection.SqlConnection = builder.Configuration.GetConnectionString("SqlConnection");

builder.Services.AddSingleton<IDapperContext, DapperContext>();
builder.Services.AddSingleton<IAccountService, AccountService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.AccessDeniedPath = "/Home/Error";
    option.LoginPath = "/Account/Login";
    option.LogoutPath = "/Account/Logout";
});
builder.Services.AddHttpContextAccessor();

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
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
