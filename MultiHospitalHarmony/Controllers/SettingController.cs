using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Extentions;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;

namespace MultiHospitalHarmony.Controllers
{
    [Authorize]
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;
        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }
        [HttpGet]
        public async Task<IActionResult> Module()
        {
            var response = await _settingService.GetModuleList(User.GetLogingID<int>());
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> SaveModule(Module request)
        {
            var response = await _settingService.SaveModule(User.GetLogingID<int>(), request);
            return Json(response);
        }
        [HttpPost]
        public async Task<IActionResult> GetModuleById(int Id)
        {
            var response = await _settingService.GetModuleById(Id);
            return Json(response);
        }
        [HttpPost]
        public async Task<IActionResult> AssignPage(int id)
        {
            var response = await _settingService.GetPageList(id);
            return PartialView(response);
        }
        [HttpGet]
        public IActionResult General()
        {
            return View();
        }
    }
}
