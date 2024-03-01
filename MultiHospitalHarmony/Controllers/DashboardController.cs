using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Enum;
using MultiHospitalHarmony.Extentions;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;

namespace MultiHospitalHarmony.Controllers
{
    public class DashboardController : Controller
    {
        private ICommonService _commonService;
        public DashboardController(ICommonService commonService)
        {
            _commonService = commonService;

        }
        [Authorize (Roles ="SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> SuperAdmin()
        {
            return View();
        }
        [Authorize (Roles = "Distributor")]
        [HttpGet]
        public async Task<IActionResult> Distributor()
        {
            return View();
        }
        [Authorize (Roles = "Agent")]
        [HttpGet]
        public async Task<IActionResult> Agent()
        {
            return View();
        }
        [Authorize (Roles = "SuperDistributor")]
        [HttpGet]
        public async Task<IActionResult> SuperDistributor()
        {
            return View();
        }
        [Authorize (Roles = "Hospital")]
        [HttpGet]
        public async Task<IActionResult> Hospital()
        {
            return View();
        }
    }
}
