using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpsPolicy;
using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Infrastructure.Services;
using MultiHospitalHarmony.Middleware;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Static;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
AppSettings appSettings = new AppSettings();
builder.Configuration.Bind(appSettings);
builder.Services.AddSingleton(appSettings);
DBConnection.SqlConnection = builder.Configuration.GetConnectionString("SqlConnection");

builder.Services.AddSingleton<IDapperContext, DapperContext>();
builder.Services.AddSingleton<IAccountService, AccountService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IApiUtilityService, ApiUtilityService>();
builder.Services.AddSingleton<ICommonService, CommonService>();
builder.Services.AddSingleton<IRequestInfo, RequestInfo>();
builder.Services.AddSingleton<IFileUploadService, FileUploadService>();
builder.Services.AddSingleton<ISMSService, SMSService>();
builder.Services.AddSingleton<IAlertService, AlertService>();
builder.Services.AddSingleton<ITransactionService, TransactionService>();
builder.Services.AddSingleton<IBadManagementService, BadManagementService>();
builder.Services.AddSingleton<ISettingService, SettingService>();
builder.Services.AddSingleton<ICommissionService, CommissionService>();

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
app.UseMiddleware(typeof(VerifyHost));

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
