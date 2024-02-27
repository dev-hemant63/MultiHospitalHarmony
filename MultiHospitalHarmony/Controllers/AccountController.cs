using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models.DTOs;
using System.Security.Claims;

namespace MultiHospitalHarmony.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest,string redirectURL)
        {
            var response = await _accountService.Login(loginRequest);
            if (response.Success)
            {
                var userclaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,response.Data.FirstName??string.Empty),
                    new Claim(ClaimTypes.UserData,response.Data.Email),
                    new Claim("UserId",response.Data.Id.ToString()),
                    new Claim(ClaimTypes.Role,response.Data.Role),
                    new Claim("Profile",response.Data.Photo),
                };
                var identity = new ClaimsIdentity(userclaims, CookieAuthenticationDefaults.AuthenticationScheme);
                var properties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.AddYears(1)
                };
                response.Data.RedirectURL = string.IsNullOrEmpty(redirectURL)?$"/Dashboard/{response.Data.Role}": redirectURL;
                await HttpContext.SignInAsync(new ClaimsPrincipal(identity), properties);
            }
            return Json(response);
        }
		[HttpGet]
		public async Task<IActionResult> Logout(string returnUrl = "/Account/Login")
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");
			HttpContext.Response.Cookies.Delete(".AspNetCore.Identity.Application");
			return LocalRedirect(returnUrl);
		}
	}
}
