using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Controllers
{
    public class CommissionController : Controller
    {
        private readonly ICommissionService _commissionService;
        public CommissionController(ICommissionService commissionService)
        {
            _commissionService = commissionService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _commissionService.GetList());
        }
        [HttpPost]
        public async Task<IActionResult> Save(CommissionReq commissionReq)
        {
            var response = await _commissionService.Save(commissionReq);
            return Json(response);
        }
        [HttpPost]
        public async Task<IActionResult> GetById(int Id)
        {
            var response = await _commissionService.GetById(Id);
            return Json(response);
        }
    }
}
