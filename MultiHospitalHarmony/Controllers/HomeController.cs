using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Enum;
using MultiHospitalHarmony.Extentions;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using System.Diagnostics;

namespace MultiHospitalHarmony.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICommonService _commonService;

		public HomeController(ILogger<HomeController> logger, ICommonService commonService)
        {
            _logger = logger;
			_commonService = commonService;

		}
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
		[Authorize]
		[HttpPost]
        public async Task<IActionResult> menus()
        {
            var res = new MinusVM
            {
                MasterMinus = new List<MasterMinus>(),
                MasterModule = new List<MasterModule>(),
            };
			var list = await _commonService.GetModules(User.GetLogingID<int>());
            var subMinus = await _commonService.GetSubMinus(User.GetLogingID<int>());
            res.MasterMinus = subMinus.Data;
            res.MasterModule = list.Data;
            res.Role = (AppRole)User.GetRoleId<int>();
            return View(res);
		}
        [Authorize]
        [HttpPost(nameof(GetDetailsByPincode))]
        public async Task<IActionResult> GetDetailsByPincode(int pincode)
        {
            var res = await _commonService.GetDetailsByPincode(pincode);
            return Json(res);
        }
        [Authorize]
        [HttpPost(nameof(GetCity))]
        public async Task<IActionResult> GetCity()
        {
            var resCity = await _commonService.GetCity();
            return Json(resCity);
        }
        [Authorize]
        [HttpPost(nameof(GetState))]
        public async Task<IActionResult> GetState()
        {
            var res = await _commonService.GetState();
            return Json(res);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
