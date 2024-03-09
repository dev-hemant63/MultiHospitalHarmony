using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Extentions;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Controllers
{
    [Authorize]
    public class BedManagementController : Controller
    {
        private readonly IBadManagementService _advertisingService;
        public BedManagementController(IBadManagementService badManagementService)
        {
            _advertisingService = badManagementService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(BadsReq badsReq)
        {
            var response = await _advertisingService.Save(User.GetLogingID<int>(),badsReq);
            return Ok(response);
        }
    }
}
