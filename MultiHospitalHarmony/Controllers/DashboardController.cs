using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Enum;
using MultiHospitalHarmony.Extentions;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using Newtonsoft.Json;

namespace MultiHospitalHarmony.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private ICommonService _commonService;
        private readonly IDashboardServices _dashboardServices;
        public DashboardController(ICommonService commonService, IDashboardServices dashboardServices)
        {
            _commonService = commonService;
            _dashboardServices = dashboardServices;
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> SuperAdmin()
        {
            return View();
        }
        [Authorize(Roles = "Distributor")]
        [HttpGet]
        public async Task<IActionResult> Distributor()
        {
            return View();
        }
        [Authorize(Roles = "Agent")]
        [HttpGet]
        public async Task<IActionResult> Agent()
        {
            return View();
        }
        [Authorize(Roles = "SuperDistributor")]
        [HttpGet]
        public async Task<IActionResult> SuperDistributor()
        {
            return View();
        }
        [Authorize(Roles = "Hospital")]
        [HttpGet]
        public async Task<IActionResult> Hospital()
        {
            return View();
        }
        [Authorize(Roles = "Doctor")]
        [HttpGet]
        public async Task<IActionResult> Doctor()
        {
            return View();
        }
        [Authorize(Roles = "Reception")]
        [HttpGet]
        public async Task<IActionResult> Reception()
        {
            return View();
        }
        [Authorize(Roles = "PharmacyAdmin")]
        [HttpGet]
        public async Task<IActionResult> PharmacyAdmin()
        {
            var res = await _dashboardServices.GetPharmacyDashboardData(User.GetLogingID<int>(), new Models.DTOs.GetPharmacyDashboardDataReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>()
            });
            if (!string.IsNullOrEmpty(res.Data.SaleInfoJson))
            {
                res.Data.SaleInfo = JsonConvert.DeserializeObject<List<SaleInfo>>(res.Data.SaleInfoJson);
            }

            return View(res);
        }
    }
}
