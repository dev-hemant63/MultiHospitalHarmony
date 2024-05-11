using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Enum;
using MultiHospitalHarmony.Extentions;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.DTOs;
using Newtonsoft.Json;
using System.Security.Claims;

namespace MultiHospitalHarmony.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private ICommonService _commonService;
        public AccountController(IAccountService accountService, ICommonService commonService)
        {
            _accountService = accountService;
            _commonService = commonService;
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            var WId = HttpContext.Request.Headers["WId"].ToString();
            return View("Login", Convert.ToInt32(WId));
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest,string redirectURL)
        {
            var response = await _accountService.Login(loginRequest);
            if (response.Success)
            {
                var res = new MinusVM
                {
                    MasterMinus = new List<MasterMinus>(),
                    MasterModule = new List<MasterModule>(),
                };
                var list = await _commonService.GetModules(response.Data.Id);
                var subMinus = await _commonService.GetSubMinus(response.Data.Id);
                res.MasterMinus = subMinus.Data;
                res.MasterModule = list.Data;
                res.Role = (AppRole)response.Data.RoleId;
                var userclaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,response.Data.FullName??string.Empty),
                    new Claim(ClaimTypes.UserData,response.Data.Email),
                    new Claim("UserId",response.Data.Id.ToString()),
                    new Claim("WID",response.Data.WId.ToString()),
                    new Claim(ClaimTypes.Role,response.Data.Role),
                    new Claim("RoleId",response.Data.RoleId.ToString()),
                    new Claim("Menus",JsonConvert.SerializeObject(res)),
                    new Claim("Balance",response.Data.Balance.ToString()),
                    new Claim("HospitalId",response.Data.HospitalId.ToString()),
                    new Claim("DoctorId",response.Data.DoctorId.ToString()),
                };
                var identity = new ClaimsIdentity(userclaims, CookieAuthenticationDefaults.AuthenticationScheme);
                var properties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.AddYears(1)
                };
                response.Data.RedirectURL = string.IsNullOrEmpty(redirectURL)?$"/dashboard/{response.Data.Role.ToLower()}": redirectURL;
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
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordReq passwordReq)
        {
			passwordReq.HospitalId = User.GetHospitalId();
            passwordReq.WID = User.GetWID<int>();
			var res = await _accountService.ChangePassword(User.GetLogingID<int>(), passwordReq);
            return Json(res);

		}
	}
}
