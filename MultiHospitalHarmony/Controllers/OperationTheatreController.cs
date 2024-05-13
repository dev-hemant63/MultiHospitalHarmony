using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Extentions;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Controllers
{
    public class OperationTheatreController : Controller
    {
        private readonly IOperationTheatreService _operationTheatreService;
        public OperationTheatreController(IOperationTheatreService operationTheatreService)
        {
            _operationTheatreService = operationTheatreService;
        }
        [HttpGet]
        public async Task<IActionResult> Surgeries()
        {
            var res = await _operationTheatreService.GetSurgeries(User.GetLogingID<int>(),new GetSurgeriesReq
            {
                HospitalId = User.GetHospitalId(),
                WID = User.GetWID<int>()
            });
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> SaveSurgeries(SaveSurgeriesReq surgeriesReq)
        {
            surgeriesReq.HospitalId = User.GetHospitalId();
            surgeriesReq.WID = User.GetWID<int>();
            var res = await _operationTheatreService.SaveSurgeries(User.GetLogingID<int>(), surgeriesReq);
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> GetSurgerieById(GetSurgeriesReq surgeriesReq)
        {
            surgeriesReq.HospitalId = User.GetHospitalId();
            surgeriesReq.WID = User.GetWID<int>();
            var res = await _operationTheatreService.GetSurgeriesById(User.GetLogingID<int>(), surgeriesReq);
            return Json(res);
        }
    }
}
