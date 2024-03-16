using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Enum;
using MultiHospitalHarmony.Extentions;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Infrastructure.Services;
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
        [HttpPost]
        public async Task<IActionResult> List()
        {
            var data = await _advertisingService.List(User.GetLogingID<int>());
            if (data.Success)
            {
                return PartialView(data.Data);
            }
            return PartialView("~/home/recordnotfound");
        }
        [HttpPost]
        public async Task<IActionResult> GetById(int Id)
        {
            var data = await _advertisingService.GetById(User.GetLogingID<int>(),Id);
            return Json(data);
        }
    }
}
